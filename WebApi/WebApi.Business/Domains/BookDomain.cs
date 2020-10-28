using System.Collections.Generic;
using AutoMapper;
using WebApi.Business.Domains.Interfaces;
using WebApi.Business.ViewModels;
using WebApi.Data.Entities;
using WebApi.Data.Repositories.Interfaces;

namespace WebApi.Business.Domains
{
  public class BookDomain : IBookDomain
  {
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookDomain(IBookRepository bookRepository, IMapper mapper)
    {
      _bookRepository = bookRepository;
      _mapper = mapper;
    }

    public IEnumerable<BookViewModel> Get()
      => _mapper.Map<IEnumerable<BookViewModel>>(_bookRepository.Get());

    public BookViewModel Get(int id)
      => _mapper.Map<BookViewModel>(_bookRepository.Get(id));

    public int Add(BookViewModel book)
    {
      var bookEntity = _mapper.Map<Book>(book);
      _bookRepository.Add(bookEntity);
      return bookEntity.Id;
    }

    public void Update(BookViewModel book)
    {
      var bookEntity = _mapper.Map<Book>(book);
      _bookRepository.Update(bookEntity);
    }

    public void Delete(int id)
      => _bookRepository.Delete(id);
  }
}
