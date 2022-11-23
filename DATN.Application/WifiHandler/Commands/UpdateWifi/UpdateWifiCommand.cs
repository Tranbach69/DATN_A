using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.WifiRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.WifiHandler.Commands.UpdateWifi
{
    public class UpdateWifiCommand : IRequest<BResult>
    {
		public int Id { get; set; }
		public string MacAddress { get; set; }
		public int WifiOfDeviceId { get; set; }
		public string Ssid { get; set; }
		public string Pwd { get; set; }
		public string BroadCast { get; set; }
		public string Iso { get; set; }
		public string AuthType { get; set; }
		public string EncryptMode { get; set; }
		public string Channel { get; set; }
		public string ChannelMode { get; set; }
		public string Mode { get; set; }
		public string DhcpHostIp { get; set; }
		public string DhcpStartIp { get; set; }
		public string DhcpEndIp { get; set; }
		public string DhcpTime { get; set; }
		public string MacAdd { get; set; }
		public string MacCount { get; set; }
		public string NatType { get; set; }
		public string Status { get; set; }
		public string CurrentAp { get; set; }
		public int ClientCount { get; set; }
		public string WpsEnable { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime TimingCreate { get; set; }
		public DateTime TimingUpdate { get; set; }
		public DateTime TimingDelete { get; set; }
	}

    public class UpdateWifiCommandHandler : IRequestHandler<UpdateWifiCommand, BResult>
    {
        private readonly IWifiRepository _wifiRepository;

        public UpdateWifiCommandHandler(IWifiRepository wifiRepository)
        {
            _wifiRepository = wifiRepository;
        }

        public async Task<BResult> Handle(UpdateWifiCommand request, CancellationToken cancellationToken)
        {
            var entity = WifiMapper.Mapper.Map<Wifi>(request);
            await _wifiRepository.BUpdateAsync(entity);
            return BResult.Success();
        }
    }
}
