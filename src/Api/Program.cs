using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IReportRepository, InMemoryReportRepository>();

var authority = builder.Configuration["Auth:Authority"] ?? throw new InvalidOperationException("Auth:Authority is required");
var audience = builder.Configuration["Auth:Audience"] ?? throw new InvalidOperationException("Auth:Audience is required");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = authority;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidAudience = audience,
            ValidateAudience = true,
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();

var allowedOrigin = builder.Configuration["Cors:AllowedOrigin"] ?? "http://localhost:3000";
builder.Services.AddCors(options =>
{
    options.AddPolicy("web", policy =>
        policy.WithOrigins(allowedOrigin)
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("web");
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/api/reports", (IReportRepository repo) => Results.Ok(repo.GetAll()));
app.MapGet("/api/reports/{id:int}", (int id, IReportRepository repo) =>
{
    var report = repo.GetById(id);
    return report is null ? Results.NotFound() : Results.Ok(report);
});

app.MapPost("/api/reports", [Authorize] (CreateReportRequest request, IReportRepository repo) =>
{
    var created = repo.Create(request.Title, request.Summary);
    return Results.Created($"/api/reports/{created.Id}", created);
});

app.Run();

public record Report(int Id, string Title, string Summary, DateTime CreatedAtUtc);
public record CreateReportRequest(string Title, string Summary);

public interface IReportRepository
{
    IReadOnlyList<Report> GetAll();
    Report? GetById(int id);
    Report Create(string title, string summary);
}

public class InMemoryReportRepository : IReportRepository
{
    private readonly List<Report> _reports =
    [
        new(1, "Quarterly revenue", "Q1 revenue and trend breakdown.", DateTime.UtcNow.AddDays(-10)),
        new(2, "System incident recap", "Summary of April production incidents.", DateTime.UtcNow.AddDays(-3))
    ];

    public IReadOnlyList<Report> GetAll() => _reports.OrderByDescending(r => r.CreatedAtUtc).ToList();

    public Report? GetById(int id) => _reports.SingleOrDefault(r => r.Id == id);

    public Report Create(string title, string summary)
    {
        var id = _reports.Max(r => r.Id) + 1;
        var report = new Report(id, title, summary, DateTime.UtcNow);
        _reports.Add(report);
        return report;
    }
}
