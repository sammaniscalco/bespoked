using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeSpoked.Repo;
using BeSpoked.Repo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BeSpoked.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //set up context for DI
            services.AddDbContext<BeSpokedContext>(opt => opt.UseInMemoryDatabase("BeSpoked"));

            //setup repositories for DI
            services.AddTransient<BaseRepository<Customer>>()
                .AddTransient<BaseRepository<Discount>>()
                .AddTransient<BaseRepository<Product>>()
                .AddTransient<BaseRepository<Sale>>()
                .AddTransient<BaseRepository<Salesperson>>()
                .AddTransient<SaleRepository>()
                .AddTransient<BeSpokedRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
