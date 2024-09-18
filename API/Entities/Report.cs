using System.Text.Json.Serialization;

namespace API.Entities;

public class Report(string title, List<string> sections)
{
    public string Title { get; private set; } = title;

    public List<string> Sections { get; private set; } = sections;
}