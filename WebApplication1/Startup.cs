using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace MyWebAPIProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context => {
                    context.Response.WriteAsync("Hello!");
                    return Task.CompletedTask;
                });

                endpoints.MapPost("/encrypt", async context => {
                    string text = await new StreamReader(context.Request.Body).ReadToEndAsync();
                    string encryptedText = Encrypt(text);
                    await context.Response.WriteAsync(encryptedText);
                });

                endpoints.MapPost("/decrypt", async context => {
                    string text = await new StreamReader(context.Request.Body).ReadToEndAsync();
                    string decryptedText = Decrypt(text);
                    await context.Response.WriteAsync(decryptedText);
                });

                endpoints.MapControllers();
            });
        }

        // Lägg till din krypterings- och dekrypteringslogik här
        private string Encrypt(string text)
        {
            // Kryptera texten här och returnera den krypterade texten
            return text;
        }

        private string Decrypt(string text)
        {
            // Dekryptera texten här och returnera den dekrypterade texten
            return text;
        }
    }
}