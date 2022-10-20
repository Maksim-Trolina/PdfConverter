
namespace PDF_Converter.Common
{
    /// <summary>
    /// Convert to pdf file
    /// </summary>
    public interface IPdfConverter
    {
        /// <summary>
        /// Convert html file to pdf file
        /// </summary>
        /// <param name="htmlFile">HTML file to convert</param>
        /// <param name="cancellationToken"></param>
        /// <returns>PDF file</returns>
        public Task<Stream> HtmlToPdf(Stream htmlFile, CancellationToken cancellationToken = default);
    }
}
