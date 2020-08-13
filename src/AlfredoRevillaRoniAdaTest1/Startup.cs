using AlfredoRevillaRoniAdaTest1.Ef;
using AlfredoRevillaRoniAdaTest1.Models;
using AlfredoRevillaRoniAdaTest1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AlfredoRevillaRoniAdaTest1
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
            services.AddApplicationInsightsTelemetry();

            services.AddMappingExpression(c =>
            {
                c.CreateMap<JobServiceModel, JobModel>()
                .ForMember(d => d.RoomTypeName, o => o.MapFrom(s => s.RoomType.Name));
                c.CreateMap<JobSummaryItemServiceModel, JobSummaryItemModel>()
                .ForMember(d => d.RoomTypeName, o => o.MapFrom(s => s.RoomType.Name));
            });

            services.AddCoreServices();
            services.AddEfServices(b => b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/error");

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