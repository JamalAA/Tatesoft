using Tatesoft.WebAPI.Entities;

namespace Tatesoft.WebAPI.Interfaces;

public interface IOcrService
{
    Task<Page?> ProcessFile(Stream fileStream);
}
