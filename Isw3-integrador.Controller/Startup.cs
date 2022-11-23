
using Isw3.Dao.Implementation;
using Isw3.Dao.Interface;
using Isw3.models;
using Isw3_Integrador.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Integrador_Isw3
{
    public class Startup
    {

        private static readonly string _MyCors = "MyCors";


        public static WebApplication initializeApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);


            return app;
        }


        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            IServiceCollection services = new ServiceCollection();
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            // Duplicate here any configuration sources you use.
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            services.Configure<MyConfiguration>(configuration.GetSection("myConfiguration"));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
             
              builder.Services.AddTransient<IAlumnoDao,AlumnoDao>();
             



            services.AddCors();

            /* services.AddCors(options =>{
                 options.AddPolicy(name: _MyCors, builder =>
                 {
                     builder.SetIsOriginAllowed(origin => new Uri(origin).AbsoluteUri == "http://localhost:8000/").AllowAnyHeader()
                         .AllowAnyMethod();
                 });
         });*/


            

            builder.Services.AddDbContext<contexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Isw3")));

        }



        private static void Configure(WebApplication app)
        {
            MyConfiguration mc = new MyConfiguration();

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            // Duplicate here any configuration sources you use.
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:8000");
                options.AllowAnyMethod();
                options.AllowAnyHeader();

            }

            );
            /*  app.UseCors(builder =>
               {
                   builder.WithOrigins(configuration.GetValue<string>("myConfiguration:allowedOrigins"))
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
               });*/




        }
    }
}
