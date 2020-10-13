using System.Net.Mail;
using System.Text.Json;
using ContactFormAPI.DTOS;
using ContactFormAPI.Repositories;
using ContactFormAPI.Services;
using ContactFormAPI.Validators;
using FluentEmail.Core;
using FluentEmail.Core.Interfaces;
using FluentEmail.Smtp;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContactFormAPI
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
            services.AddControllers()
                .AddFluentValidation()
                .AddJsonOptions(options => 
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddSingleton<IMessageRepository, MemoryMessageRepository>();
            services.AddSingleton<IMessageRetrieverService, MessageRetrieverService>();
            services.AddSingleton<IMessageCreatorService, MessageCreatorService>();
            services.AddSingleton<IMessageSender, FluentEmailMessageSender>();
            services.AddTransient<IValidator<MessageDto>, MessageValidator>();

            var smtpClient = new SmtpClient();
            smtpClient.Host = "localhost";
            smtpClient.Port = 25;
            services
                .AddFluentEmail("defaultsender@test.test")
                .AddSmtpSender(smtpClient);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
