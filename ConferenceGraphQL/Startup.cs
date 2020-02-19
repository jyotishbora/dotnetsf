using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conference.Data;
using Conference.Data.Entities;
using ConferenceGraphql.Core.Schema;
using ConferenceGraphql.Core.Schema.Queries;
using ConferenceGraphql.Core.Schema.Types;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
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
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
#endif

            // Register DepedencyResolver; this will be used when a GraphQL type needs to resolve a dependency
            services.AddSingleton<IDependencyResolver>(c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            services.AddSingleton<IConferenceRepository, ConferenceRepository>();
            services.AddDbContext<ConferenceDbContext>(builder => { builder.UseSqlServer(Configuration.GetConnectionString("ConfDbConnectionString")); });

            // Query, Mutation and Subscription
            services.AddSingleton<Query>();

            // Types
            services.AddSingleton<SpeakerType>();
            services.AddSingleton<SessionType>();
            services.AddSingleton<CommentType>();
            // Schema
            services.AddSingleton<ConferenceSchema>();
            // Register GraphQL services
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            }).AddWebSockets();

            services.AddControllers();
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


            // Allow to display UI
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // This will enable WebSockets in Asp.Net core
            app.UseWebSockets();

            // Enable endpoint for websockets (subscriptions)
            app.UseGraphQLWebSockets<ConferenceSchema>("/graphql");
            // Enable endpoint for querying
            app.UseGraphQL<ConferenceSchema>("/graphql");

            // use graphiQL middleware at default url / graphiql
            app.UseGraphiQLServer(new GraphiQLOptions());
            // use voyager middleware at default url /ui/voyager
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
