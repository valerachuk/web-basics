using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using web_basics.business.ViewModels;

namespace web_basics.business
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<data.Entities.Account, ViewModels.Account>();
      CreateMap<ViewModels.Account, data.Entities.Account>();
      CreateMap<data.Entities.Cat, ViewModels.Cat>();
      CreateMap<data.Entities.Owner, ViewModels.Owner>();
      CreateMap<business.ViewModels.Role, data.Entities.Role>();
      CreateMap<Login, data.Entities.Account>();
    }
  }
}
