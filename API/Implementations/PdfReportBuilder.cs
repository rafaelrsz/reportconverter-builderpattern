using API.Interfaces;
using MigraDocCore.DocumentObjectModel;
using MigraDocCore.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace API.Implementations;

public class PdfReportBuilder : IReportBuilder
{
    private readonly Document _document = new();
    private readonly Section _section;
    public PdfReportBuilder()
    {
        _section = _document.AddSection();
    }
    public void ConvertTitle(string title)
    {
        
    }

    public void ConvertSection(string section)
    {
        _section.AddParagraph(section);
    }

    public byte[] GetPdf()
    {
        PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
        pdfRenderer.Document = _document;
        pdfRenderer.RenderDocument();
        
        using MemoryStream stream = new();
        
        pdfRenderer.Save(stream, false);

        return stream.ToArray();
    }
}