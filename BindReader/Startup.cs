﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BindReader
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                //var con = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                //Configuration = con.Build();
                var myClass = new Class();
               
                Configuration.Bind(myClass);
                Console.WriteLine($"name:{myClass.Name}");
                Console.WriteLine();
                for (int i = 0; i < myClass.Items.Count; i++)
                {
                    await context.Response.WriteAsync($"language:{myClass.Items[i].Language}");
                    await context.Response.WriteAsync($"tool:{myClass.Items[i].Tool}");
                }
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
