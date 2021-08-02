using AutoMapper;
using MassTransit;
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
using UltraNuke.Barasingha.AlarmManagement.API.Application.Mappers;
using UltraNuke.Barasingha.AlarmManagement.API.Application.Queries;
using UltraNuke.Barasingha.AlarmManagement.Infrastructure;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Middlewares;

namespace UltraNuke.Barasingha.AlarmManagement.API
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
                .AddCustomConfiguration(Configuration)
                .AddCustomIntegrations(Configuration)
                .AddCustomMediatR(Configuration)
                .AddCustomDbContext(Configuration)
                .AddCustomAutoMapper(Configuration)
                .AddCustomEventBus(Configuration)
                .AddCustomSwagger(Configuration)
                .AddCustomAuthentication(Configuration);
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
                endpoints.MapControllers();
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

        public static IServiceCollection AddCustomEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMassTransit(x =>
            //{
            //    //x.AddConsumer<TodoUpdatedIntegrationEventHandler>();

            //    x.UsingRabbitMq((context, cfg) =>
            //    {
            //        cfg.ReceiveEndpoint("event-listener", e =>
            //        {
            //            //e.ConfigureConsumer<TodoUpdatedIntegrationEventHandler>(context);
            //        });
            //    });
            //});
            //services.AddMassTransitHostedService();
            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,//是否调用对签名securityToken的SecurityKey进行验证
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["TokenSecret"])),//签名秘钥
            //        ValidateIssuer = true,//是否验证颁发者
            //        ValidIssuer = configuration["TokenIssuer"], //颁发者
            //        ValidateAudience = true, //是否验证接收者
            //        ValidAudience = configuration["TokenAudience"],//接收者
            //        ValidateLifetime = true,//是否验证失效时间
            //    };
            //});

            return services;
        }

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AlarmManagementContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AlarmManagementContext"),
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               sqlOptions.MigrationsAssembly("UltraNuke.Barasingha.AlarmManagement.API");
                           });
            });

            return services;
        }

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDTOProfile));

            return services;
        }

        public static IServiceCollection AddCustomMediatR(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Program).Assembly);

            return services;
        }

        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRepository>(provider =>
            {
                return new Repository(provider.GetService<AlarmManagementContext>(), provider.GetService<IMediator>());
            });

            services.AddTransient<AlarmQueries>(provider =>
            {
                return new AlarmQueries(configuration.GetConnectionString("AlarmManagementContext"));
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlarmManagement.API V1");
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
