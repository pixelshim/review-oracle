using Api.Models;

namespace Api.Services;

public interface IReportService
{
    IReadOnlyList<Report> GetAll();
    Report? GetById(Guid id);
    Report Create(string title, string summary);
}
