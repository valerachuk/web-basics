using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using web_basics.business;
using web_basics.Common;
using web_basics.data;

namespace web_basics
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();
      // In production, the Angular files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/dist";
      });

      var authOptionsConfiguration = Configuration.GetSection("Auth");
      services.Configure<AuthOptions>(authOptionsConfiguration);

      var authOptions = authOptionsConfiguration.Get<AuthOptions>();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
            options.RequireHttpsMetadata = true;
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
              ValidateIssuer = false,
                    //ValidIssuer = authOptions.Issuer

                    ValidateAudience = false,
                    //ValidAudience = authOptions.Audience

                    ValidateLifetime = true,

              IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
              ValidateIssuerSigningKey = true
            };
          });

      services.AddDbContext<WebBasicsDBContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddTransient<data.Repositories.Account>();
      services.AddTransient<data.Repositories.Cat>();
      services.AddTransient<data.Repositories.Owner>();

      services.AddTransient<business.Domains.Account>();
      services.AddTransient<business.Domains.Cat>();
      services.AddTransient<business.Domains.Owner>();

      var mapConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
      services.AddSingleton(mapConfig.CreateMapper());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      if (!env.IsDevelopment())
      {
        app.UseSpaStaticFiles();
      }

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller}/{action=Index}/{id?}");
      });

      app.UseSpa(spa =>
      {
              // To learn more about options for serving an Angular SPA from ASP.NET Core,
              // see https://go.microsoft.com/fwlink/?linkid=864501

              spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseAngularCliServer(npmScript: "start");
        }
      });
    }
  }
}
