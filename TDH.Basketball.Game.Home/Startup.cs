using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TDH.Basketball.Game.EF.Core;
using TDH.Basketball.Game.EF.Manager.Manager;
using TDH.Basketball.Game.EF.Manager.Interface;
using TDH.Basketball.Game.EF.Repository;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.Home
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
 
            services.AddScoped(typeof(IGenericRepository<Attendee>), typeof(AttendeeRepository));
            services.AddScoped(typeof(IGenericRepository<Event>), typeof(EventRepository));
            services.AddScoped(typeof(IGenericRepository<NotificationBoard>), typeof(NotificationBoardRepository));
            services.AddScoped(typeof(IGenericRepository<Player>), typeof(PlayerRepository));
            services.AddScoped(typeof(IGenericRepository<Term>), typeof(TermRepository));
            services.AddScoped(typeof(IGenericRepository<Transaction>), typeof(TransactionRepository));
            services.AddScoped(typeof(IGenericRepository<BasketballCentre>), typeof(BasketballCentreRepository));
            services.AddScoped(typeof(IGenericRepository<CourtRentFee>), typeof(CourtRentFeeRepository));

            services.AddScoped<IAttendeeManager, AttendeeManager> ();
            services.AddScoped<IEventManager, EventManager>();
            services.AddScoped<INotificationBoardManager, NotificationBoardManager>();
            services.AddScoped<IPlayerManager, PlayerManager>();
            services.AddScoped<ITermManager, TermManager>();
            services.AddScoped<ITransactionManager, TransactionManager>();
            services.AddScoped<IBasketballCentreManager, BasketballCentreManager>();
            services.AddScoped<ICourtRentFeeManager, CourtRentFeeManager>();

            services.AddMvc();
            services.AddDbContext<TDHDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TDH_DbString"), optBuilder => optBuilder.MigrationsAssembly("TDH.Basketball.Game.Home")));


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
