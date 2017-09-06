using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using Shop.Web.Models;
using Shop.Web.Models.Data;
using Shop.Web.Models.DataContext;
using Shop.Web.Models.Repository;
using Shop.Web.ViewModels;

namespace Shop.Web
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddDbContext<BookstoreContext>();
            services.AddTransient<BookstoreContextSeedData>();
            services.AddScoped<IBookstoreRepository, BookstoreRepository>();
            services.AddLogging();
            services.AddMvc()
                .AddJsonOptions(config =>
                { 
                           config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper, UrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory factory,
            BookstoreContextSeedData seeder)
        {
            Mapper.Initialize(config =>
                {
                    config.CreateMap<BookViewModel, Book>().ReverseMap();
                    config.CreateMap<AuthorViewModel, Author>().ReverseMap();                  
                    config.CreateMap<BookTypeViewModel, BookType>().ReverseMap();
                    config.CreateMap<PublisherViewModel, Publisher>().ReverseMap();
                    config.CreateMap<StorageViewModel, Storage>().ReverseMap();
                    config.CreateMap<CartItemViewModel, CartItem>().ReverseMap();
                });
                                 
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
                factory.AddDebug(LogLevel.Information);
            }
            else
            {
                factory.AddDebug(LogLevel.Error);
            }
            app.UseStaticFiles();
                   
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults : new { controller="App", action = "Index"});
            });

            seeder.EnsureSeedData().Wait();
        }
    }
}
