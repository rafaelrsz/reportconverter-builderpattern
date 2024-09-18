using System.Text;
using API.Interfaces;

namespace API.Implementations;

public class HtmlReportBuilder : IReportBuilder
{
    private readonly StringBuilder _header = new();
    private readonly StringBuilder _body = new();
    
    public void ConvertTitle(string title)
    {
        if (!_header.ToString().Contains("<title>"))
            _header.Append($"<title>{title}</title>\n");
    }

    public void ConvertSection(string section)
    {
        _body.Append($"<p>{section}</p>\n");
    }

    public string GetHtml()
    {
        return
            "<!DOCTYPE html>\n<html>\n" +
            "<head>\n" + _header.ToString() + "\n</head>\n" +
            "<body>\n" + _body.ToString() + "\n</body>\n" +
            "</html>";
    }
}