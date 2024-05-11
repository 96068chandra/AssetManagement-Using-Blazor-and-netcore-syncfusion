using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Autofac;

namespace AssetManagement
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
                .WriteTo.Async(c => c.Console())
                .CreateLogger();

            try
            {
                Log.Information("Starting AssetManagement.HttpApi.Host.");
                var builder = WebApplication.CreateBuilder(args);
                if (builder.Host == null) throw new Exception("builder.Host is null");
                builder.Host.AddAppSettingsSecretsJson()
                    .UseAutofac(builder.Services)
                    .UseSerilog();
                if (builder.Services == null) throw new Exception("builder.Services is null");
                await builder.Services.AddApplicationAsync<AssetManagementHttpApiHostModule>();
                if (builder == null) throw new Exception("builder is null");
                var app = builder.Build();
                if (app == null) throw new Exception("app is null");
                await app.InitializeApplicationAsync();
                if (app.Lifetime == null) throw new Exception("app.Lifetime is null");
                await app.Lifetime.RunAsync();
                return 0;
            }
            catch (Exception ex)
            {
                if (ex is HostAbortedException)
                {
                    throw;
              
