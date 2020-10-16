using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace web_basics.business.Domains
{
  public class Cat
  {
    data.Repositories.Cat _repository;
    IMapper _mapper;

    public Cat(data.Repositories.Cat repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public IEnumerable<ViewModels.Cat> Get()
    {
      var cats = _repository.Get();
      return cats.Select(cat => _mapper.Map<data.Entities.Cat, ViewModels.Cat>(cat));
    }
  }
}
