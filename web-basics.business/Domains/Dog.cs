using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace web_basics.business.Domains
{
  public class Dog
  {
    private data.Repositories.Dog _repository;
    private IMapper _mapper;

    public Dog(data.Repositories.Dog repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public IEnumerable<ViewModels.Dog> Get() => _repository.Get().Select(dog => _mapper.Map<ViewModels.Dog>(dog));
  }
}
