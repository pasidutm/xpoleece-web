using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Listing.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ListingService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<XpoliDbContext>(opt => opt.UseInMemoryDatabase("ListingList"), ServiceLifetime.Singleton);
            services.AddResponseCaching();
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
            })
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //The Configure method is used to specify how the app responds to HTTP requests.
        //The request pipeline is configured by adding middleware components to an IApplicationBuilder instance.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseResponseCaching();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
