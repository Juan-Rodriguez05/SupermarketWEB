// Below is the corrected Program.cs file:

using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;

// Below is the corrected Program.cs file:

namespace SupermarketWEB
{
    internal static class ProgramHelpers
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<SupermarketContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SupermarketDB"))
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}