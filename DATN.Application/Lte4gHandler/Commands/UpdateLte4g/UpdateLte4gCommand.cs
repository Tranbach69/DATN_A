using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.Lte4gHandler.Commands.UpdateLte4g
{
    public class UpdateLte4gCommand : IRequest<BResult>
    {
        public string Imei { get; set; }
        public int CardStatus { get; set; }
        public int Apptype { get; set; }
        public int AppState { get; set; }
        public int Pin { get; set; }
        public string SimIccid { get; set; }
        public string SimImsi { get; set; }
        public string SystemMode { get; set; }
        public string OperationMode { get; set; }
        public string MobileCountryCode { get; set; }
        public string MobileNetworkCode { get; set; }
        public string LocationAreaCode { get; set; }
        public string ServiceCellId { get; set; }
        public string FreqBand { get; set; }
        public string Current4GData { get; set; }
        public string Afrcn { get; set; }
        public string PhoneNumber { get; set; }
        public int Rssi4G { get; set; }
        public int NetworkMode { get; set; }
    }

    public class UpdateLte4gCommandHandler : IRequestHandler<UpdateLte4gCommand, BResult>
    {
        private readonly ILte4gRepository _lte4gRepository;

        public UpdateLte4gCommandHandler(ILte4gRepository lte4gRepository)
        {
            _lte4gRepository = lte4gRepository;
        }

        public async Task<BResult> Handle(UpdateLte4gCommand request, CancellationToken cancellationToken)
        {
            var entity = Lte4gMapper.Mapper.Map<Lte4g>(request);
            var result = await _lte4gRepository.BUpdateAsync(entity);
            if (result == null)
            {
                if (request.Imei == "")
                {
                    return BResult.Failure("Imei phải có giá trị");
                }
                else return BResult.Failure("Imei không tồn tại");

            }
            const int PORT_NO = 3023;
            const string SERVER_IP = "localhost";

            string s = "1"+JsonConvert.SerializeObject(request);
            //---data to send to the server---
            string textToSend = s;

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            ////---read back the text---
            //byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            //int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            //Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            //Console.ReadLine();
            client.Close();
            return BResult.Success();
        }
    }
}
