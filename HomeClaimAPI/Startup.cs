using HomeClaimAPI.Repository;
using HomeClaimAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeClaimAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddScoped<IHomeClaimContext, HomeClaimContext>();
            services.AddScoped<IHomeClaimService, Service.HomeClaimService>();
            services.AddScoped<IHomeClaimRepository, HomeClaimDBRepository>();
            IHomeClaimRepository _homeClaimRepository = new HomeClaimDBRepository();
            _homeClaimRepository.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
