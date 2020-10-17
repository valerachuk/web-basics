using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace web_basics.business
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<data.Entities.Account, ViewModels.Account>();
      CreateMap<data.Entities.Cat, ViewModels.Cat>();
      CreateMap<data.Entities.Owner, ViewModels.Owner>();
    }
  }
}
