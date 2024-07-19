
using Microsoft.EntityFrameworkCore;
using Data.AppDbContext;
using Core.StudentServices;

namespace PracticeProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            var connString = builder.Configuration.GetConnectionString("StudentDatabase");
            builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(connString));
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
