using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api
{    
    
    public class Startup : IStartup // extrai a interface criada "IStartup"
    {
        // construtor de nome Startup para setar as configurações de inicialização contidas 
        // na interface IConfiguration (Microsoft.Extensions)
        // a propriedade Configuration estava apenas como get, então foi preciso setar ela dentro do construtor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // declara que vai pegar as propriedades da interface IConfiguration
        // e passar para "Configuration"
        public IConfiguration Configuration { get; }

        // configura as services
        public void ConfigureServices(IServiceCollection services)
        {
            // adiciona as controllers ao esquema do app
            services.AddControllers();

            // db connection
            var connectionString = Configuration.GetConnectionString("conexaoMySql");
            services.AddDbContext<DataContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configures the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder WebAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), WebAppBuilder.Configuration) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

            startup.ConfigureServices(WebAppBuilder.Services);

            var app = WebAppBuilder.Build();
            startup.Configure(app, app.Environment);

            app.Run();
            return WebAppBuilder;
        }
    }
}