
using TokenService.Models;
using TokenService.Services;
using Microsoft.Extensions.Configuration;
namespace TokenService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var jwtOptions = new JwtOptions();
            builder.Configuration.Bind("Jwt",jwtOptions);

            builder.Services.AddSingleton(typeof(JwtOptions), jwtOptions!);

            builder.Services.AddTransient<ITokenGenerator,JwtTokenGenerator>();
            builder.Services.AddTransient<IAuthenticationService,AuthenticationService>();

            builder.Services.AddCors(setup => {
                setup.AddPolicy("policy1", config => {

                    config.WithOrigins("http://localhost:4200","http://localhost:8082");
                    config.AllowAnyHeader();
                    config.AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("policy1");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
