using Api.Services;

namespace Api.Tests;

public sealed class ReportServiceTests
{
    [Fact]
    public void GetAll_ReturnsSeedReports()
    {
        var service = new InMemoryReportService();
        Assert.True(service.GetAll().Count >= 2);
    }
}
