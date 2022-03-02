using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PDFGenerator.Web.AssemblyLoader;
using PDFGenerator.Web.Services;
using PDFGenerator.Web.Services.Interfaces;
using System.IO;
using System.Runtime.InteropServices;

namespace PDFGenerator.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ViewRender>();
            services.AddSingleton<IPDFGenerator, Services.PDFGenerator>();
            services.AddSingleton<IReceiptGenerator, Services.ReceiptGenerator>();
            var libraryFileName = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "libwkhtmltox.so" : "libwkhtmltox.dll";
            var wkHtmlToPdfBinaries = Path.Combine(Directory.GetCurrentDirectory(), libraryFileName);
            var context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(wkHtmlToPdfBinaries);
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));




            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
