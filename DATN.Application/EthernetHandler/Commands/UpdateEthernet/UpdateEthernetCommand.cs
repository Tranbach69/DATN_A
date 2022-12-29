using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.EthernetRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EthernetHandler.Commands.UpdateEthernet
{
    public class UpdateEthernetCommand : IRequest<BResult>
    {
        public string Imei { get; set; }
        public int DriverType { get; set; }
        public int DriverEn { get; set; }
        public int BringUpdownEn { get; set; }
        public int IpStaticEn { get; set; }
        public string IpAddr { get; set; }
        public string Netmask { get; set; }


    }

    public class UpdateEthernetCommandHandler : IRequestHandler<UpdateEthernetCommand, BResult>
    {
        private readonly IEthernetRepository _ethernetRepository;

        public UpdateEthernetCommandHandler(IEthernetRepository ethernetRepository)
        {
            _ethernetRepository = ethernetRepository;
        }

        public async Task<BResult> Handle(UpdateEthernetCommand request, CancellationToken cancellationToken)
        {
            var entity = EthernetMapper.Mapper.Map<Ethernet>(request);
            var result = await _ethernetRepository.BUpdateAsync(entity);
            if (result == null)
            {
                if (request.Imei == "")
                {
                    return BResult.Failure("Imei phải có giá trị");
                }
                else return BResult.Failure("Imei không tồn tại");

            }
            //const int PORT_NO = 3023;
            //const string SERVER_IP = "localhost";

            //string s =  "2"+ JsonConvert.SerializeObject(request);

            //string textToSend = s;

 
            //TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            //NetworkStream nwStream = client.GetStream();
            //byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

 
            //nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //client.Close();
            return BResult.Success();
        }
    }
}
