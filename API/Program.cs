using API.Entities;
using API.Implementations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ShortURL",
        Version = "v1",
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapPost("/html-converter", (Report report) =>
{
    ReportReader reader = new(report);
    HtmlReportBuilder htmlBuilder = new();
    
    reader.ParseReport(htmlBuilder);

    return Results.Content(htmlBuilder.GetHtml(), "text/html");
});

app.MapPost("/pdf-converter", (Report report) =>
{
    ReportReader reader = new(report);
    PdfReportBuilder pdfBuilder = new();
    
    reader.ParseReport(pdfBuilder);

    return Results.File(pdfBuilder.GetPdf(), "application/pdf", $"{report.Title}.pdf");
});

app.Run();