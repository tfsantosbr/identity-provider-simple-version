using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Provider
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer(opt => opt.IssuerUri = "http://identity.provider")
                .AddDeveloperSigningCredential()
                .AddCorsPolicyService<InMemoryCorsPolicyService>()
                .AddInMemoryApiResources(Configuration.GetApiResources())
                .AddInMemoryClients(Configuration.GetClients());

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            app.UseIdentityServer();
        }
    }
}