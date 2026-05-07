using Api.Models;

namespace Api.Services;

public sealed class InMemoryReportService : IReportService
{
    private readonly List<Report> _reports =
    [
        new() { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Title = "Q1 Availability", Summary = "Availability was 99.95% in Q1." },
        new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Title = "Incident Postmortem", Summary = "No customer data was impacted." }
    ];

    public IReadOnlyList<Report> GetAll() => _reports;

    public Report? GetById(Guid id) => _reports.FirstOrDefault(r => r.Id == id);

    public Report Create(string title, string summary)
    {
        var report = new Report { Title = title, Summary = summary };
        _reports.Add(report);
        return report;
    }
}
