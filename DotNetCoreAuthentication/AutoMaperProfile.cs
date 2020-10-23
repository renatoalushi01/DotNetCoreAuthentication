using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotNetCoreAuthentication.Models;
using DotNetCoreAuthentication.ViewModels;

namespace DotNetCoreAuthentication
{
    public class AutoMaperProfile : Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<MailBoxDto, MailBox>().ReverseMap();
        }
    }
}
