using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.GpsRepository;
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

namespace DATN.Application.GpsHandler.Commands.UpdateGps
{
    public class UpdateGpsCommand : IRequest<BResult>
    {
        public string Imei { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Altitude { get; set; }
        public string Speed { get; set; }
        public string Bearing { get; set; }
        public string Accuracy { get; set; }
        public string Time { get; set; }

    }

    public class UpdateGpsCommandHandler : IRequestHandler<UpdateGpsCommand, BResult>
    {
        private readonly IGpsRepository _gpsRepository;

        public UpdateGpsCommandHandler(IGpsRepository gpsRepository)
        {
            _gpsRepository = gpsRepository;
        }

        public async Task<BResult> Handle(UpdateGpsCommand request, CancellationToken cancellationToken)
        {
            var entity = GpsMapper.Mapper.Map<Gps>(request);
            var result = await _gpsRepository.BUpdateAsync(entity);
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

            string s = "3"+JsonConvert.SerializeObject(request);
            //---data to send to the server---
            string textToSend = s;

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            client.Close();
            return BResult.Success();
        }
    }
}
