using Tatesoft.WebAPI.Services;
using Xunit;
using System.Text;
using Tatesoft.WebAPI.Entities;

namespace Tatesoft.Test.UnitTests
{
    public class OcrServiceTests
    {
        [Fact]
        public async Task ProcessFile_ShouldReturnExpectedResult_WhenCalledWithValidDataAsyncWordCount()
        {

            var fileContent = "Mock file content";
            var byteArray = new UTF8Encoding().GetBytes(fileContent);
            using var stream = new MemoryStream(byteArray);
            var ocrService = new OcrService();

            Page? result = await ocrService.ProcessFile(stream);

            Assert.Equal(result.WordCount, 108);

        }
    }
}
