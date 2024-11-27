using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Layer.Business;
using Layer.Dao;
using Layer.Dao.IRepository;
using Layer.Dao.Repository;
using Layer.Entity;
using Layer.Entity.Dto;
using Layer.Entity.Menu;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Layer.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly IOptions<MyConfig> config;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region ----- AUTOMAPPER -----

            services.AddAutoMapper(configuration =>
            {
                //Master to Dto
                configuration.CreateMap<Country, CountryDto>();
                configuration.CreateMap<City, CityDto>();
                configuration.CreateMap<Client, ClientDto>();
                configuration.CreateMap<Layer.Entity.Profile, ProfileDto>();
                configuration.CreateMap<User, UserDto>();
                configuration.CreateMap<Bot, StatusDto>();
                configuration.CreateMap<Client, ClientDto>();
                configuration.CreateMap<Layer.Entity.Profile, ProfileDto>();
                configuration.CreateMap<Node, NodeDto>();
                configuration.CreateMap<Navigation, NavigationDto>();
                configuration.CreateMap<Bot, BotDto>();
                configuration.CreateMap<Broker, BrokerDto>();
                configuration.CreateMap<Indicator, IndicatorDto>();
                configuration.CreateMap<GroupFinancialAsset, GroupFinancialAssetDto>();
                configuration.CreateMap<FinancialAsset, FinancialAssetDto>();
                configuration.CreateMap<Config, ConfigDto>();
                configuration.CreateMap<UserBroker, UserBrokerDto>();
                configuration.CreateMap<BotInstance, BotInstanceDto>();
                configuration.CreateMap<FinancialBroker, FinancialBrokerDto>();

                //Dto to Master
                configuration.CreateMap<CountryDto, Country>();
                configuration.CreateMap<CityDto, City>();
                configuration.CreateMap<ClientDto, Client>();
                configuration.CreateMap<ProfileDto, Layer.Entity.Profile>();
                configuration.CreateMap<StatusDto, Bot>();
                configuration.CreateMap<ClientDto, Client>();
                configuration.CreateMap<BotDto, Bot>();
                configuration.CreateMap<BrokerDto, Broker>();
                configuration.CreateMap<IndicatorDto, Indicator>();
                configuration.CreateMap<GroupFinancialAssetDto, GroupFinancialAsset>();
                configuration.CreateMap<FinancialAssetDto, FinancialAsset>();
                configuration.CreateMap<ConfigDto, Config>();
                configuration.CreateMap<UserBrokerDto, UserBroker>();
                configuration.CreateMap<BotInstanceDto, BotInstance>();
                configuration.CreateMap<FinancialBrokerDto, FinancialBroker>();
            
                //Creation to Master
                configuration.CreateMap<UserCreationDto, User>();

            }, typeof(Startup));
            #endregion

            #region ----- CORS CONFIGURATION -----
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .Build();
                });
            });
            #endregion

            #region ----- CONECTION DATA CONFIGURATION -----
            //services.AddDbContext<DataContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:DataContext"]));
            services.AddDbContext<DataContext>(opts => opts.UseNpgsql(Configuration["ConnectionString:DataContextPos"]));
            #endregion

            #region ----- REPOSITORY CONFIGURATION -----
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IOpcionMenuRepository, OpcionMenuRepository>();
            services.AddScoped<IBotRepository, BotRepository>();
            services.AddScoped<IBrokerRepository, BrokerRepository>();
            services.AddScoped<IIndicatorRepository, IndicatorRepository>();
            services.AddScoped<IGroupFinancialRepository, GroupFinancialRepository>();
            services.AddScoped<IFinancialRepository, FinancialRepository>();
            services.AddScoped<IConfigRepository, ConfigRepository>();
            services.AddScoped<IUserBrokerRepository, UserBrokerRepository>();
            services.AddScoped<IBotInstanceRepository, BotInstanceRepository>();
            services.AddScoped<IFinancialBrokerRepository, FinancialBrokerRepository>();
            //services.AddScoped<IUsuarioPerfilRepository, UsuarioPerfilRepository>();
            #endregion

            #region ----- SECURITY ACCESS CONFIGURATION -----
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "https://localhost:4200/",
                        ValidAudience = "https://localhost:4200/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["MyConfig:StringPassword"]))
                    };
                });
            #endregion

            //services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            AddSwagger(services);

        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"DataControlPro {groupName}",
                    Version = groupName,
                    Description = "DataControlPro API",
                    Contact = new OpenApiContact
                    {
                        Name = "DataControlPro",
                        Email = "Hcarra90@gmail.com",
                        Url = new Uri("https://www.DataControlPro.com/"),
                    },


                });

                options.AddSecurityDefinition("token", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = HeaderNames.Authorization,
                    Scheme = "Bearer",
                    BearerFormat = "Jwt"
                    
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,
                          },
                         new string[] {}
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //IHostingEnvironment env
            var cultureInfo = new CultureInfo("es-CL");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Configure the HTTP request pipeline.
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DataControlPro API V1");
            });

            app.UseCors("CorsPolicy");
            app.UseCors("EnableCORS");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseMvc();
        }
    }
}
