using Microsoft.AspNetCore.Mvc;
using PDF_Converter.Common;

namespace PDF_Converter.Controllers.API
{
    [Controller]
    public class PdfConvertController : Controller
    {
        const string pdfContentType = "application/pdf";

        readonly IPdfConverter pdfConverter;
        public PdfConvertController(IPdfConverter pdfConverter)
        {
            this.pdfConverter = pdfConverter;
        }
        /// <summary>
        /// Convert html file to pdf file
        /// </summary>
        /// <param name="htmlFile">HTML file to convert</param>
        /// <returns>PDF file</returns>
        [HttpPost]
        public async Task<IActionResult> ConvertToPdf(IFormFile htmlFile)
        {
            try
            {
                if (!HtmlFileChecker.IsHtmlFile(htmlFile))
                {
                    throw new BadHttpRequestException("Not html file sent.");
                }
                var html = htmlFile.OpenReadStream();
                var pdf = await pdfConverter.HtmlToPdf(html, HttpContext.RequestAborted);
                return new FileStreamResult(pdf, pdfContentType);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(499);
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
