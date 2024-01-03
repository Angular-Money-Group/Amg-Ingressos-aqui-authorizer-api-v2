using System.Text;
using Amg_Ingressos_aqui_authorizer_api_v2.Consts;
using Amg_Ingressos_aqui_authorizer_api_v2.Infra;
using Amg_Ingressos_aqui_authorizer_api_v2.Infra.Interfaces;
using Amg_Ingressos_aqui_authorizer_api_v2.Model;
using Amg_Ingressos_aqui_authorizer_api_v2.Repository;
using Amg_Ingressos_aqui_authorizer_api_v2.Repository.Interfaces;
using Amg_Ingressos_aqui_authorizer_api_v2.Services;
using Amg_Ingressos_aqui_authorizer_api_v2.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.Configure<AuthDatabaseSettings>(
    builder.Configuration.GetSection("AuthDatabase"));
builder.Services.Configure<ServicesSettings>(
    builder.Configuration.GetSection("ServicesSettings"));

builder.Services.Configure<MvcOptions>(options =>
{
    options.ModelMetadataDetailsProviders.Add(
        new SystemTextJsonValidationMetadataProvider());
});

// injecao de dependencia
//services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
//repository
builder.Services.AddScoped<ICrudRepository<User>, CrudRepository<User>>();
//infra
builder.Services.AddScoped<IDbConnection, DbConnection>();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseStaticFiles(); // Certifique-se de ter essa linha
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<AuthExceptionHandlerMiddleaware>();
app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());
app.Run();
