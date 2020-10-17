using AutoMapper;

using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;

namespace web_basics.business.Domains
{
  public class Account
  {
    IMapper _mapper;
    data.Repositories.Account _repository;

    public Account(IMapper mapper, data.Repositories.Account repository)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public IEnumerable<ViewModels.Account> Get()
    {
      var accounts = _repository.Get();
      return accounts.Select(account => _mapper.Map<data.Entities.Account, ViewModels.Account>(account));
    }
  }
}
