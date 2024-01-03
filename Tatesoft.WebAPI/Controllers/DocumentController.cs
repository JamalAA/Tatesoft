using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Tatesoft.WebAPI.Context;
using Tatesoft.WebAPI.DTO;
using Tatesoft.WebAPI.Entities;
using Tatesoft.WebAPI.Exceptions;
using Tatesoft.WebAPI.Services;
using Customer = Tatesoft.WebAPI.Services.Customer;

namespace Tatesoft.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {

        private readonly OcrService _ocrService;
        private readonly LoggedInUser _loggedInUser;
        private readonly TatesoftBackendDbContext _backendDbContext;
        private readonly CustomerService _customerService;
        private readonly DtoServices _dtoServices;


        public DocumentController(LoggedInUser loggedInUser, OcrService ocrService, TatesoftBackendDbContext tatesoftBackendDbContext, CustomerService customerService, DtoServices dtoServices)
        {
            _loggedInUser = loggedInUser;
            _ocrService = ocrService;
            _backendDbContext = tatesoftBackendDbContext;
            _customerService = customerService;
            _dtoServices = dtoServices;
        }

        [HttpPost]
        public async Task<ActionResult<PlainTextDto>> UploadDocument(IFormFile file, int CustomerId)
        {
            User currentUser = _loggedInUser.User;
            if (currentUser == null)
            {
                return Unauthorized("No user is logged in.");
            }

            try
            {
                Customer? customer = _customerService.GetCustomer(CustomerId);

                if (file == null || file.Length == 0) return BadRequest("No file uploaded.");

                using var stream = file.OpenReadStream();
                Page? ocrResult = await _ocrService.ProcessFile(stream);

                if (ocrResult == null) return BadRequest("OCR processing failed or returned no result.");
                ocrResult.CustomerId = CustomerId;
                _backendDbContext.Pages.Add(ocrResult);
                await _backendDbContext.SaveChangesAsync();

                string formattedOcrText = _ocrService.CleanAndFormatOcrText(ocrResult.Text);

                PlainTextDto plainTextDto = _dtoServices.GetPlainTextDto(CustomerId, ocrResult.Id, formattedOcrText);

                return Ok(plainTextDto);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound($"Customer with ID {CustomerId} not found. ${ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (JsonException ex)
            {
                return BadRequest("JSON deserialization error: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult<string>> UpdateDocument(int CustomerId, int DocumentId, string Text)
        {
            User currentUser = _loggedInUser.User;
            if (currentUser == null)
            {
                return Unauthorized("No user is logged in.");
            }

            try
            {
                Customer? customer = _customerService.GetCustomer(CustomerId);

                bool pageExist = await _backendDbContext.Pages.AnyAsync(p => p.Id == DocumentId && p.CustomerId == CustomerId);

                if (!pageExist)
                {
                    return NotFound($"No page found with Document ID {DocumentId} for Customer ID {CustomerId}");
                }

                // Her ville jeg havde lavet en OCR service metode som generere en ny Page med de nye ændringer
                // derefter ville jeg opdatere databasen og revision.

                return Ok("The file has been saved successfully");
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"Customer with ID {CustomerId} not found.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (JsonException ex)
            {
                return BadRequest("JSON deserialization error: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<PlainTextDto>> GetDocument(int CustomerId, int DocumentId)
        {

            User currentUser = _loggedInUser.User;
            if (currentUser == null)
            {
                return Unauthorized("No user is logged in.");
            }

            try
            {
                Customer? customer = _customerService.GetCustomer(CustomerId);

                Page? document = await _backendDbContext.Pages.Where(p => p.Id == DocumentId && p.CustomerId == CustomerId).FirstOrDefaultAsync();

                if (document == null)
                {
                    return NotFound($"No page found with Document ID {DocumentId} for Customer ID {CustomerId}");
                }

                string formattedOcrText = _ocrService.CleanAndFormatOcrText(document.Text);

                return Ok(formattedOcrText);
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"Customer with ID {CustomerId} not found.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (JsonException ex)
            {
                return BadRequest("JSON deserialization error: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }

}


