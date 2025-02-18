
using Login_Register.model;
using Microsoft.EntityFrameworkCore;

namespace Login_Register
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<UserContext>(options => {
                options.UseSqlServer("Server=DESKTOP-0M45M7S\\SQLEXPRESS;Database=UserDB;Trusted_Connection=True;TrustServerCertificate=True;");
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()  // Permite qualquer origem
                          .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc.)
                          .AllowAnyHeader(); // Permite qualquer cabeçalho
                });
            });
            builder.Services.AddScoped<UserStore>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
     
            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
