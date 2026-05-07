using Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Auth:Authority"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidAudience = builder.Configuration["Auth:Audience"],
            ValidateAudience = true
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddSingleton<IReportService, InMemoryReportService>();

var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/api/reports", (IReportService reports, ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger("Reports");
    logger.LogInformation("Listing reports");
    return Results.Ok(reports.GetAll());
});

app.MapGet("/api/reports/{id:guid}", (Guid id, IReportService reports) =>
{
    var report = reports.GetById(id);
    return report is null ? Results.NotFound() : Results.Ok(report);
});

app.MapPost("/api/reports", (CreateReportRequest request, IReportService reports) =>
{
    if (string.IsNullOrWhiteSpace(request.Title))
    {
        return Results.BadRequest(new { error = "Title is required." });
    }

    return Results.Created($"/api/reports/{Guid.NewGuid()}", reports.Create(request.Title, request.Summary));
}).RequireAuthorization();

app.Run();

public sealed record CreateReportRequest(string Title, string Summary);
