using Microsoft.EntityFrameworkCore;
using RestAPI.Data;

namespace RestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Manual add db 
            /*string st = "server=LAPTOP-LO0UV06V\\SQLEXPRESS; database=demo1; trusted_connection=true; Encrypt=False";
            builder.Services.AddDbContext<APIdbcontext>(o => o.UseSqlServer(st));
            */

            // db add by appssetting 
            builder.Services.AddDbContext<APIdbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnection")));



            // Add services to the container.

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