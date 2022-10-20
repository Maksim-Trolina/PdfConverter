using PuppeteerSharp;

namespace PDF_Converter.Common
{
    /// <summary>
    /// Convert to PDF file with PuppeteerSharp 
    /// </summary>
    public class PuppeteerSharpPdfConverter : IPdfConverter
    {
        /// <summary>
        /// Convert html file to pdf file
        /// </summary>
        /// <param name="htmlFile">HTML file to convert</param>
        /// <param name="cancellationToken"></param>
        /// <returns>PDF file</returns>
        public async Task<Stream> HtmlToPdf(Stream htmlFile, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var readFromHtmlFileTask = new StreamReader(htmlFile).ReadToEndAsync();

            using var browserFetcher = new BrowserFetcher();
            cancellationToken.ThrowIfCancellationRequested();
            await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);

            cancellationToken.ThrowIfCancellationRequested();
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            cancellationToken.ThrowIfCancellationRequested();
            var page = await browser.NewPageAsync();
            var html = await readFromHtmlFileTask;

            cancellationToken.ThrowIfCancellationRequested();
            await page.SetContentAsync(html);

            cancellationToken.ThrowIfCancellationRequested();
            return await page.PdfStreamAsync();
        }
    }
}
