using AutoMapper;

using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;
using web_basics.business.ViewModels;

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

    public void Update(ViewModels.Account account)
    {
      _repository.Update(_mapper.Map<data.Entities.Account>(account));
    }

    public bool Exists(string email) => _repository.Get().Any(account => account.Email == email);

    public void Add(Login login)
    {
      _repository.Create(_mapper.Map<data.Entities.Account>(login));
    }

    public void Delete(int id)
    {
      _repository.Delete(new data.Entities.Account{Id = id});
    }
  }
}
