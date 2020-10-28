using System.Linq;
using AutoMapper;
using WebApi.Business.ViewModels;
using WebApi.Data.Entities;

namespace WebApi.Business
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Book, BookViewModel>();

      CreateMap<BookViewModel, Book>();

      CreateMap<Genre, GenreViewModel>()
        .ForMember(mem => mem.Books, 
          cfg => cfg.MapFrom(genre => genre.Books.Select(book => book.Id)));

      CreateMap<GenreViewModel, Genre>()
        .ForMember(genre => genre.Books, cfg => cfg.Ignore());
    }
  }
}
