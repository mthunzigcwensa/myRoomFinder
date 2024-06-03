using Microsoft.EntityFrameworkCore;
using RoomFinder.Core.Services.IServices;
using RoomFinder.Core.Services;
using RoomFinder.DataAccess.Repository.IRepository;
using RoomFinder.DataAccess.Repository;
using RoomFinder.DataAccess;

namespace RoomFinder.Web
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
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IStudyRoomService, StudyRoomService>();
            services.AddScoped<IStudyRoomRepository, StudyRoomRepository>();
            services.AddScoped<IStudyRoomBookingService, StudyRoomBookingService>();
            services.AddScoped<IStudyRoomBookingRepository, StudyRoomBookingRepository>();

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
