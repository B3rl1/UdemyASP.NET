using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNetTest.Dtos;
using ASPNetTest.Models;
using AutoMapper;

namespace ASPNetTest.App_Start
{
	public class MappingProfile : Profile
	{
		public IMapper Mapper;
		public MappingProfile()
		{
			var config = new MapperConfiguration(cfg =>
			{
				CreateMap<User, UserDto>();
				CreateMap<UserDto, User>();
			});

			Mapper = config.CreateMapper();
		}
	}
}