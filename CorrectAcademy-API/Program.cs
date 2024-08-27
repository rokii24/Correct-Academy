using Microsoft.AspNetCore.Identity;
using Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Persistence.ExternalConfigurations;
using Persistence.Reposetories.ExternalRepository;
using Domain.IRepositories.ExternalRepositories;
using Domain.IRepositories.DataRepository;
using Persistence.Repositories.DataRepository;
using Service.Abstraction.IExternalServices;
using Service.ExternalServices;
using CorrectAcademy_API.Hubs;
using Persistence.Reposetories.ExternalRepositories;
using Persistence.Reposetories;

namespace CorrectAcademy_API
{
    public class Program
    {
        public static async void AddRoles(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                await RolesIdentity.EnsureRolesAsync(serviceProvider);
            }
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Db Context
            var connection = builder.Configuration.GetConnectionString("MohCon");
            builder.Services
                .AddDbContext<CorrectAcademyContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("Persistence")));

            builder.Services.AddIdentity<CorrectUser, CorrectRole>()
                .AddEntityFrameworkStores<CorrectAcademyContext>()
                .AddDefaultTokenProviders();
            #endregion
            #region JWT Auth
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                //op.RequireHttpsMetadata = false;
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    //RequireExpirationTime = true,
                    //ValidateActor = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                };
            });
            builder.Services.AddAuthorization();
            #endregion
            #region Configurations
          //  builder.Services.Configure<JWTConfiguration>(builder.Configuration.GetSection("Jwt"));
            var jwtConfig = builder.Configuration.GetSection("Jwt").Get<JWTConfiguration>();
            builder.Services.AddSingleton(jwtConfig);
            //  builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));
            builder.Services.Configure<GoogleConfiguration>(builder.Configuration.GetSection("Google"));
            //builder.Services.Configure<BraintreeSetting>(builder.Configuration.GetSection("Payment"));
            #endregion
            #region  Scopes
            builder.Services.AddScoped<IExternalRepository, ExternalRepositorie>();
            builder.Services.AddScoped<IAdminDataRepository, AdminDataRepository>();
          
           // builder.Services.AddScoped<IAdminDataService, AdminDataService>();
            builder.Services.AddScoped<IExternalService, ExternalService>();
            //   builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<CorrectHub>();
            #endregion

            var app = builder.Build();
            AddRoles(app);
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.MapHub<CorrectHub>("Hub");
            app.Run();
        }
    }
}
