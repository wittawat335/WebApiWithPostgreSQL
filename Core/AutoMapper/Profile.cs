using AutoMapper;
using Core.Domain.Entities;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<address, AddressDTO>();




            CreateMap<AddressDTO, address>().ForMember(x => x.last_update, opt => opt.MapFrom(origin => DateTime.Now));
        }
    }
}
