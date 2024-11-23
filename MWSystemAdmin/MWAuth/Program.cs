using MWAuth.CustomConverters;
using MWAuth.Helpers;
using MWAuth.Models;
using CommonLib;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Web;
using System.Diagnostics;
using System.Reflection;
using MWAuth.BackgroundWokers;
using Business.Core.Startups;
using DataAccess.Auth.Startups;
using System.Text;


try
{
    var guid = Utils.GenGuidStringN();

    var builder = WebApplication.CreateBuilder(args);
    builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
    {
        var path = Path.Combine("./ConfigApp", "appsettings.json");
        config.AddJsonFile(path, optional: false, reloadOnChange: true);
        config.AddEnvironmentVariables();
    });

    // Init log
    NLog.LogManager.LoadConfiguration(Path.Combine("./ConfigLog/nlog.config"));
    builder.Host.UseNLog();

    
    AuthDAStartup.ConfigureServices(builder.Services);
    AuthBLStartup.ConfigureServices(builder.Services);

    #region LOG STARTING

    string runMode = string.Empty;
    Version version = Assembly.GetEntryAssembly().GetName().Version;

#if DEBUG
    runMode = "DEBUG";
#elif RELEASE
    runMode = "RELEASE";
#endif

    Logger.log.Info($"[{guid}] [LIFE CYCLE] Start on [{runMode}] mode - Build version [{version}] - Platform [{Environment.OSVersion.VersionString}] - ProcessId [{Process.GetCurrentProcess().Id}] - CurrentTime [{DateTime.Now:O}]");

    #endregion

    ConfigDataAuth.Init(builder.Configuration);

 

    builder.Services.AddHostedService<UserLoginWorker>(); // Co dung ILoginClient nen de sau khi Client init

    // Config auth
    #region Config auth
    //builder.Services.AddSingleton<IAuthorizationHandler, CustomAuthorizationHandler>();
    builder.Services.Configure<Audience>(ConfigDataAuth.Audience);
    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredUniqueChars = 3;

        // Lockout settings
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
        options.Lockout.MaxFailedAccessAttempts = 10;
        options.Lockout.AllowedForNewUsers = true;
        // User settings
        //options.User.RequireUniqueEmail = true;
    });
    ConfigureJwtAuthService(builder.Services);

    #endregion

    // End - Add Service connect to BO Grpc
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "JWTToken_Auth_API",
            Version = "v1"
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
    });

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Insert(0, new CustomDateTimeConverter());
        options.JsonSerializerOptions.Converters.Insert(0, new CustomNullableDateTimeConverter());
        options.JsonSerializerOptions.Converters.Insert(0, new CustomDoubleConverter());
        options.JsonSerializerOptions.Converters.Insert(0, new CustomInt32Converter());
        options.JsonSerializerOptions.Converters.Insert(0, new CustomInt64Converter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });


    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "AllowLocal",
          policy =>
          {
              policy
                  .AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .WithExposedHeaders("Content-Disposition");
          });
    });

    //builder.Environment.ContentRootPath

    var app = builder.Build();

    //app.UseCors("AllowLocal");

    app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapGet("/healthcheck", () =>
    {
        return DateTime.Now;
    })
      .WithName("HealthCheck");

    app.MapControllers();

    app.UseAuthentication();
    app.UseAuthorization();

    //
    app.UseWebSockets(new WebSocketOptions()
    {
        KeepAliveInterval = TimeSpan.FromSeconds(10),
    });


    Logger.log.Info($"[{guid}] [LIFE CYCLE] Init configs, services successfully. CurrentTime [{DateTime.Now:O}]");

    app.Run();

    Logger.log.Info($"[{guid}] [LIFE CYCLE] Shutting down. CurrentTime [{DateTime.Now:O}");

    //
  
    void ConfigureJwtAuthService(IServiceCollection services)
    {
        var audienceConfig = ConfigDataAuth.Audience;
        //var signingKey = JWTHelper.GetSecretInfo();
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
        var tokenValidationParameters = new TokenValidationParameters
        {
            // The signing key must match!
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,

            // Validate the JWT Issuer (iss) claim
            ValidateIssuer = true,
            ValidIssuer = audienceConfig["Iss"],

            // Validate the JWT Audience (aud) claim
            ValidateAudience = true,
            ValidAudience = audienceConfig["Aud"],

            // Validate the token expiry
            ValidateLifetime = true,

            ClockSkew = TimeSpan.Zero,
        };

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o =>
        {
            //o.Authority = "";
            //o.Audience = "";
            o.TokenValidationParameters = tokenValidationParameters;
        });
    }
}
finally
{
    NLog.LogManager.Shutdown();
}