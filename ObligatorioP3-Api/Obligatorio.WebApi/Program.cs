using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Obligatorio.Infraestructura.AccesoDatos.EF;
using Obligatorio.LogicaAplicacion.CasosUso;
using Obligatorio.LogicaAplicacion.CasosUso.CuObjCeleste;
using Obligatorio.LogicaAplicacion.CasosUso.CuObservacion;
using Obligatorio.LogicaAplicacion.CasosUso.CuPrestamo;
using Obligatorio.LogicaAplicacion.CasosUso.CuUsuario;
using Obligatorio.LogicaAplicacion.CasosUso.Equipo;
using Obligatorio.LogicaAplicacion.Dtos.Equipo;
using Obligatorio.LogicaAplicacion.Dtos.Observacion;
using Obligatorio.LogicaAplicacion.Dtos.Prestamo;
using Obligatorio.LogicaAplicacion.Dtos.Usuario;
using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using Obligatorio.WebApi.ModelIA;
using Obligatorio.WebApi.Service;
using System.Reflection;
using System.Text;

namespace Obligatorio.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Repositorio
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
            builder.Services.AddScoped<IRepositorioPrestamo, RepositorioPrestamo>();
            builder.Services.AddScoped<IRepositorioObservacion, RepositorioObservacion>();
            builder.Services.AddScoped<IRepositorioObjCeleste, RepositorioObjCeleste>();
            builder.Services.AddDbContext<ObservatorioContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Observatorio"));
            });

            // Registrar el seeder para poblar datos de prueba
            builder.Services.AddScoped<SeedData>();

            // Casos de uso
            //Usuarios
            builder.Services.AddScoped<ICUAlta<AltaUsuarioDTO>, AltaUsuario>();
            builder.Services.AddScoped<ICUGetAll<AltaUsuarioDTO>, ListarUsuarios>();
            builder.Services.AddScoped<ICULogin<LoginUsuarioDTO>, LoginUsuario>();
            //Equipos
            builder.Services.AddScoped<ICUAlta<AltaTelescopioDTO>, AltaEquipo>();
            builder.Services.AddScoped<ICUAlta<AltaCamaraDTO>, AltaEquipo>();
            builder.Services.AddScoped<ICUAlta<AltaMonturaDTO>, AltaEquipo>();
            builder.Services.AddScoped<ICUAlta<AltaOcularDTO>, AltaEquipo>();
            builder.Services.AddScoped<ICUGetAll<AltaMonturaDTO>, ListarEquipos>();
            builder.Services.AddScoped<ICUGetAll<AltaOcularDTO>, ListarEquipos>();
            builder.Services.AddScoped<ICUGetAll<AltaTelescopioDTO>, ListarEquipos>();
            builder.Services.AddScoped<ICUGetAll<AltaCamaraDTO>, ListarEquipos>();
            builder.Services.AddScoped<ICUUpdate<AltaCamaraDTO>, UpdateEquipo>();
            builder.Services.AddScoped<ICUUpdate<AltaTelescopioDTO>, UpdateEquipo>();
            builder.Services.AddScoped<ICUUpdate<AltaOcularDTO>, UpdateEquipo>();
            builder.Services.AddScoped<ICUUpdate<AltaMonturaDTO>, UpdateEquipo>();
            builder.Services.AddScoped<ICUGetEquipoById, GetEquipoById>();
            builder.Services.AddScoped<ICUDelete<int>, DeleteEquipo>();
            //Prestamos
            builder.Services.AddScoped<ICUAlta<AltaPrestamoDTO>, AltaPrestamo>();
            builder.Services.AddScoped<ICUGetAll<PrestamoListadoDTO>, ListarPrestamos>();
            builder.Services.AddScoped<ICUUpdate<DevolverPrestamoDTO>, DevolverPrestamo>();
            builder.Services.AddScoped<ICUGetTById<SocioListadoDTO>, SocioXTelescopio>();
            builder.Services.AddScoped<ICUGetTById<AuditoriaPrestamoDTO>, ListAudiById>();
            builder.Services.AddScoped<ICUGetById<PrestamoListadoDTO>, PrestamosById>();
            builder.Services.AddScoped<ICUGetById<PrestamoIADTO>, PrestamoIAService>();//Para la IA Gemini
            builder.Services.AddHttpClient<IGeminiService, GeminiService>();//IA
            //ObjCeleste
            builder.Services.AddScoped<ICUGetAll<RankinObjCelesteDTO>, RankingObjCeleste>();
            builder.Services.AddScoped<ICUGetAll<ObjCelesteListadoDTO>, ListarObjCelestes>();
            builder.Services.AddScoped<ICUGetById<ObjCelesteListadoDTO>, GetObjCelesteById>();
            //Observaciones
            builder.Services.AddScoped<ICUAlta<AltaObservacionDTO>, AltaObservacion>();

            builder.Services.AddScoped<SeedData>();

            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);

                options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingrese el token JWT"
                });

                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [
                        new OpenApiSecuritySchemeReference("bearer", document)
                    ] = []
                });
            });

            // Para darle seguridad a la API
            // 1. Obtener configuración JWT desde appsettings.json
            var jwtSection = builder.Configuration.GetSection("Jwt");
            builder.Services.Configure<JwtSettings>(jwtSection);
            var jwtSettings = jwtSection.Get<JwtSettings>();
            builder.Services.AddSingleton(jwtSettings);

            builder.Services.AddScoped<IJwtGenerator<Usuario>, JwtGenerator>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);

            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false; // ?? poner en true para producción
                  options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = false,   // podés poner en true si usás Issuer
                      ValidateAudience = false, // podés poner en true si usás Audience
                  };
              }
           );


            /*Alta Prestamo SCRIPT que interactua con la API Personal*/
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            if (string.IsNullOrWhiteSpace(app.Configuration["Gemini:ApiKey"]))
            {
                app.Logger.LogWarning(
                    "Gemini:ApiKey no está configurada: el endpoint api/IA/evaluar va a fallar. Ver README.");
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                using (var scope = app.Services.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<SeedData>();
                    seeder.Run();
                }
            }

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }


            app.UseHttpsRedirection();

            // CORS debe estar registrado antes de la autorización para permitir las peticiones
            // (incluyendo OPTIONS / preflight) sin que la política de auth las bloquee.
            app.UseCors("AllowFrontend"); //Para el SCRIPT de ALTA PRESTAMO

            // Habilitar autenticación antes de la autorización
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
