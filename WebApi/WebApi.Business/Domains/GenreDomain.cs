using System.Collections.Generic;
using AutoMapper;
using WebApi.Business.Domains.Interfaces;
using WebApi.Business.ViewModels;
using WebApi.Data.Entities;
using WebApi.Data.Repositories.Interfaces;

namespace WebApi.Business.Domains
{
  public class GenreDomain : IGenreDomain
  {
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public GenreDomain(IGenreRepository genreRepository, IMapper mapper)
    {
      _genreRepository = genreRepository;
      _mapper = mapper;
    }

    public IEnumerable<GenreViewModel> Get()
      => _mapper.Map<IEnumerable<GenreViewModel>>(_genreRepository.Get());

    public GenreViewModel Get(int id)
      => _mapper.Map<GenreViewModel>(_genreRepository.Get(id));

    public IEnumerable<BookViewModel> GetBooks(int genreId)
      => _mapper.Map<IEnumerable<BookViewModel>>(_genreRepository.GetBooks(genreId));

    public int Add(GenreViewModel genre)
    {
      var genreEntity = _mapper.Map<Genre>(genre);
      _genreRepository.Add(genreEntity);
      return genreEntity.Id;
    }

    public void Update(GenreViewModel genre)
    {
      var genreEntity = _mapper.Map<Genre>(genre);
      _genreRepository.Update(genreEntity);
    }

    public void Delete(int id)
      => _genreRepository.Delete(id);
  }
}
