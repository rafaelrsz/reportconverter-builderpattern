using API.Entities;
using API.Interfaces;

namespace API.Implementations;

public class ReportReader(Report report)
{
    public Report Report { get; private set; } = report;

    public void ParseReport(IReportBuilder builder)
    {
        builder.ConvertTitle(report.Title);
        foreach (var sec in report.Sections)
        {
            builder.ConvertSection(sec);
        }
    }
}