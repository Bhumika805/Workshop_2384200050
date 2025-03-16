using AutoMapper;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserContactBook, UserModel>();
            CreateMap<UserContactBook, RegisterUserDTO>().ReverseMap();
            CreateMap<UserContactBook, UserModel>().ReverseMap();
            
        }
    }
}
