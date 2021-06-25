using AutoMapper;
using edureka_sampleapp.Models;
using edureka_sampleapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.MappingProfile
{
    public class DomainMappingProfile :Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<Account, AccountEditModel>().ReverseMap() ;
            CreateMap<Account, AccountViewModel>().ReverseMap();
        }
    }
}
