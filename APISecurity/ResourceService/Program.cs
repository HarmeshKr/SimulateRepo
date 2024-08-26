
using ResourceService.Config;
using ResourceService.Infra;

namespace ResourceService
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

            builder.AddAppAuthentication(); //<-------------------------

            builder.Services.AddAuthorization(config => {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.Manager, Policies.ManagerPolicy());
                config.AddPolicy(Policies.Executive, Policies.ExecutivePolicy());
            });

            builder.Services.AddCors(setup => {
                setup.AddPolicy("policy1", config => {
                    config.AllowCredentials();
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
            app.UseAuthorization();

            app.MapControllers();
           
            app.Run();
        }
    }
}
