﻿//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DATN.Application.Mapper
//{
//	public class DeviceUserMapper
//	{
//        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
//        {
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
//                cfg.AddProfile<DeviceUserMapperProfile>();
//            });
//            var mapper = config.CreateMapper();
//            return mapper;
//        });
//        public static IMapper Mapper => Lazy.Value;

//    }
//}
