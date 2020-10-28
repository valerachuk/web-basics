using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Business;
using WebApi.Business.Domains;
using WebApi.Business.Domains.Interfaces;
using WebApi.Data;
using WebApi.Data.Repositories;
using WebApi.Data.Repositories.Interfaces;

namespace WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      services.AddDbContext<IWebApiDbContext, WebApiDbContext>(builder => 
        builder.UseSqlite("Data Source=./bookCatalog.db"));

      var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
      services.AddSingleton(mapperConfiguration.CreateMapper());

      services.AddTransient<IBookDomain, BookDomain>();
      services.AddTransient<IGenreDomain, GenreDomain>();

      services.AddTransient<IGenreRepository, GenreRepository>();
      services.AddTransient<IBookRepository, BookRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
