using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seguradora.src.Auth;
using Seguradora.src.User;
using Seguradora.src.User.Context;
using Swashbuckle.AspNetCore.Swagger;

namespace Seguradora {
    public class Startup {
        public Startup () {
            var configurationBuilder = new ConfigurationBuilder ()
                .AddJsonFile ("appsettings.json", optional : false, reloadOnChange : true)
                .AddEnvironmentVariables ();

            Configuration = configurationBuilder.Build ();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();
            services.Configure<AppConfig> (Configuration);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<MysqlContext> (opt => opt.UseInMemoryDatabase ("Seguradora"));
            services.AddScoped<AuthenticationFilter>();

            // services.AddDbContextPool<MySQLContext>(
            //     options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // ));

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1",
                    new Info {
                        Title = "Seguradora API",
                            Version = "v1",
                            Description = "Demonstração projeto .netcore 2.1",
                            Contact = new Contact {
                                Name = "Fernando Colnaghi Ribeiro",
                                Url = "https://github.com/fcolnaghi",
                                Email = "fernando.colnaghi@gmail.com"
                            }
                    });

            });
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            app.UseMvc ();

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seguradora API");
            });
        }
    }

}