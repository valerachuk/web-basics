using AutoMapper;

using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;

namespace web_basics.business.Domains
{
  public class Owner
  {
    IMapper _mapper;
    data.Repositories.Owner _repository;

    public Owner(IMapper mapper, data.Repositories.Owner repository)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public IEnumerable<ViewModels.Owner> Get()
    {
      var owners = _repository.Get();
      return owners.Select(owner => _mapper.Map<data.Entities.Owner, ViewModels.Owner>(owner));
    }
  }
}
