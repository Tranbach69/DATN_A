using AutoMapper;
using DATN.Application.DeviceHandler.Commands.CreateDevice;
using DATN.Application.DeviceHandler.Commands.UpdateDevice;

using DATN.Application.DeviceHandler.Queries.GetDevice;
using DATN.Application.DeviceHandler.Queries.GetDeviceByImei;
using DATN.Application.DeviceHandler.Queries.GetDevicePaging;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
	public class DeviceMapperProfile: Profile
    {
        public DeviceMapperProfile()
        {
            CreateMap<Device, CreateDeviceCommand>().ReverseMap();           
            CreateMap<Device, UpdateDeviceCommand>().ReverseMap();
            CreateMap<Device, GetDeviceResponse>().ReverseMap();
            CreateMap<Device, GetDevicePagingResponse>().ReverseMap();
            CreateMap<Account, GetDeviceByImeiResponse>().ReverseMap();
        }
    }
}
