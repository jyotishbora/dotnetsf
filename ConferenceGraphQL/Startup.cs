using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conference.Data;
using Conference.Data.Entities;
using ConferenceGraphql.Core.Schema;
using ConferenceGraphql.Core.Schema.Mutation;
using ConferenceGraphql.Core.Schema.Queries;
using ConferenceGraphql.Core.Schema.Types;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConferenceGraphQLApi
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

            // If using Kestrel:
#if NETCOREAPP3_1
            // Workaround until GraphQL can swap off Newtonsoft.Json and onto the new MS one.
            // Depending on whether you're using IIS or Kestrel, the code required is different
            // See: https://github.com/graphql-dotnet/graphql-dotnet/issues/1116
            services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(options => { options.AllowSynchronousIO = true; });
#endif


            services.AddScoped<IConferenceRepository, ConferenceRepository>();
            services.AddDbContext<ConferenceDbContext>(builder => { builder.UseSqlServer(Configuration.GetConnectionString("ConfDbConnectionString")); });


            // Register DepedencyResolver; this will be used when a GraphQL type needs to resolve a dependency
            services.AddScoped<IDependencyResolver>(c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            // Schema
            services.AddCors();
            services.AddScoped<ConferenceSchema>();
            // Register GraphQL services
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = true;
                })
                .AddGraphTypes(typeof(ConferenceSchema).Assembly, ServiceLifetime.Scoped)
                .AddUserContextBuilder(context => context.User)
                .AddWebSockets();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            // Allow to display UI
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
            });
            // This will enable WebSockets in Asp.Net core
            app.UseWebSockets();

            // Enable endpoint for websockets (subscriptions)
            app.UseGraphQLWebSockets<ConferenceSchema>("/graphql");
            // Enable endpoint for querying
            app.UseGraphQL<ConferenceSchema>("/graphql");

            // use graphiQL middleware at default url / graphiql
            app.UseGraphiQLServer(new GraphiQLOptions());
            // use graphql-playground middleware at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            // use voyager middleware at default url /ui/voyager
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions());

            
        }
    }
}
