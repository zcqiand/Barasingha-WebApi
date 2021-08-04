using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Text;
using UltraNuke.Barasingha.PermissionManagement.API.Application.Mappers;
using UltraNuke.Barasingha.PermissionManagement.API.Application.Queries;
using UltraNuke.Barasingha.PermissionManagement.Infrastructure;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Middlewares;

namespace UltraNuke.Barasingha.PermissionManagement.API
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
            services.AddCustomMvc()
                .AddCustomMediatR(Configuration)
                .AddCustomSwagger(Configuration)
                .AddCustomAuthentication(Configuration)
                .AddCustomConfiguration(Configuration)
                .AddCustomDbContext(Configuration)
                .AddCustomAutoMapper(Configuration)
                .AddCustomIntegrations(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomSwagger();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCustomApiLog();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireAuthorization("ApiScope");
            });
        }
    }

    static class CustomExtensionsServiceCollection
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            // Add framework services.
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(opt =>
            {
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var xmls = Directory.GetFiles(basePath, "*.xml");
                foreach (var xml in xmls)
                {
                    opt.IncludeXmlComments(xml, includeControllerXmlComments: true);
                }
            });
            services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = configuration["IdentityUrl"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                    options.RequireHttpsMetadata = bool.Parse(configuration["RequireHttpsMetadata"] ?? "false");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "PermissionManagement.API");
                });
            });

            return services;
        }

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PermissionManagementContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PermissionManagementContext"),
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               sqlOptions.MigrationsAssembly("UltraNuke.Barasingha.PermissionManagement.API");
                           });
            });

            return services;
        }

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DTOToDTOProfile));

            return services;
        }

        public static IServiceCollection AddCustomMediatR(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Program).Assembly);

            return services;
        }

        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            var constr = configuration.GetConnectionString("PermissionManagementContext");

            services.AddTransient<IRepository>(provider =>
            {
                return new Repository(provider.GetService<PermissionManagementContext>(), provider.GetService<IMediator>());
            });

            services.AddTransient<MenuQueries>(provider =>
            {
                return new MenuQueries(constr, provider.GetService<IMapper>());
            });
            services.AddTransient<RoleQueries>(provider =>
            {
                return new RoleQueries(constr);
            });
            services.AddTransient<UserQueries>(provider =>
            {
                return new UserQueries(constr);
            });

            return services;
        }
    }

    static class CustomExtensionsApplicationBuilder
    {
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PermissionManagement.API V1");
            });
            return app;
        }

        public static IApplicationBuilder UseCustomApiLog(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiLogMiddleware>();
            return app;
        }
    }
}
