using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Entity;
using ModelLayer.Model;

namespace BusinessLayer.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<AddressBookEntry, AddressBookEntry>();
            CreateMap<RepositoryLayer.Entity.AddressBookEntity, AddressBookRequestDTO>();
        }
    }
}
