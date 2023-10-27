using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaCompraVentaDeCriptomonedas.DataAccess;
using SistemaCompraVentaDeCriptomonedas.Extensions;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace SistemaCompraVentaDeCriptomonedas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var AllowSpecificOrigins = "";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins, policy =>
                {
                    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                });
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient("useApi", config =>
            {
                config.BaseAddress = new Uri(builder.Configuration["ServiceUrl:ApiUrl"]);
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trabajo Integrador Sofftek", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autorizacion JWT",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type= ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }, new string[]{ }
                    }
                });

            });

            //Conexion a la base de datos
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("name=DefaultConnection");
            });

            builder.Services.AddAuthorization(option =>
            {
                option.AddPolicy("ADMINISTRADOR", policy =>

                {
                    policy.RequireClaim(ClaimTypes.Role, "1");
                });
                option.AddPolicy("CLIENTE", policy =>

                {
                    policy.RequireClaim(ClaimTypes.Role, "2");

                });
            });


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false
            }); ;

            builder.Services.AddService();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();
                
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(AllowSpecificOrigins);
            app.MapControllers();
          
            app.Run();
        }
    }
}