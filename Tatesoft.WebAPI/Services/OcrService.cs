using System.Text.Json;
using Tatesoft.WebAPI.Entities;
using Tatesoft.WebAPI.Interfaces;
namespace Tatesoft.WebAPI.Services;

public class OcrService : IOcrService
{
    private string pathToHardcodedOcrResult = Directory.GetCurrentDirectory(); // "[TODO: Provide file path]";

    public async Task<Page?> ProcessFile(Stream fileStream)
    {
        var filePath = Path.Combine(pathToHardcodedOcrResult, "ocrResult.json");
        if (!File.Exists(filePath))
        {
            throw new ArgumentOutOfRangeException("Du har glemt at angive file path til ocrResult.json filen");
        }

        return JsonSerializer.Deserialize<Page>(await File.ReadAllTextAsync(Path.Combine(pathToHardcodedOcrResult,
            "ocrResult.json")));
    }

    public string CleanAndFormatOcrText(string ocrText)
    {
        // Split the text into lines
        var lines = ocrText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        // Trim each line and ensure it's not just whitespace
        var cleanedLines = lines.Select(line => line.Trim()).Where(line => !string.IsNullOrWhiteSpace(line));

        // Join the cleaned lines with a single newline character
        return string.Join(Environment.NewLine, cleanedLines);
    }

}