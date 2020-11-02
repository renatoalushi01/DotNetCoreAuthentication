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