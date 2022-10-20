namespace PDF_Converter.Common
{
    /// <summary>
    /// Checks html file
    /// </summary>
    public static class HtmlFileChecker
    {
        const string htmlContentType = "text/html";
        /// <summary>
        /// Is the file an html file
        /// </summary>
        /// <param name="file"></param>
        /// <returns>True if the file is an html file</returns>
        public static bool IsHtmlFile(IFormFile file)
        {
            return file != null && file.ContentType == htmlContentType;
        }
    }
}
