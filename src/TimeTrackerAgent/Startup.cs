using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.EventLog;
using TimeTrackerAgent.Service;
using TimeTrackerAgent.Storage;
using TimeTrackerAgent.Storage.Repository;
using TimeTrackerAgent.Tracker.TrackerFactory;

namespace TimeTrackerAgent
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
            services.AddHostedService<MainWorker>()
                .Configure<EventLogSettings>(config =>
                {
                    config.LogName = "Time Tracker Agent";
                    config.SourceName = "Time Tracker Agent Source";
                });
            services.AddTransient<ITrackerFactory, TrackerFactory>();
            services.AddTransient<IStorageRepository, StorageRepository>();
            services.AddTransient<IStorageService, StorageService>();
            services.AddSingleton<ICurrentDay, CurrentDay>();

            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson();
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
