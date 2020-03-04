namespace WebServer.Http.Response
{
    using Enums;
    using Exceptions;

    public class FileResponse : HttpResponse
    {
        public FileResponse(HttpStatusCode statusCode, byte[] fileData, string mimeType)
        {
            this.ValidateStatusCode(statusCode);

            this.FileData = fileData;
            this.StatusCode = statusCode;

            this.Headers.Add(HttpHeader.ContentLength, this.FileData.Length.ToString());
            this.Headers.Add(HttpHeader.ContentDisposition, "attachment");
            this.Headers.Add(HttpHeader.ContentType, mimeType);
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int)statusCode;

            if (299 > statusCodeNumber && statusCodeNumber < 400)
            {
                throw new InvalidResponseException("File responses need a sattus code above 300 and below 400.");
            }
        }

        public byte[] FileData { get; }
    }
}