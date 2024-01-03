using Tatesoft.WebAPI.DTO;

namespace Tatesoft.WebAPI.Services
{
    public class DtoServices
    {
        public PlainTextDto GetPlainTextDto(int customerId, int pageId, string text) 
        { 
            PlainTextDto plainTextDto = new PlainTextDto { 
              CustomerId = customerId,
              PageId = pageId,  
              PlainText = text
            };
          
            return plainTextDto;
        }   
    }
}
