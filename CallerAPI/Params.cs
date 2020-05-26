using System.Net;

namespace CallerAPI
{
    public class Params
    {
        // URI request.
        public string URI { internal get; set; }

        // Method request.
        public string Method { internal get; set; }

        // Result status code request.
        public HttpStatusCode HttpStatusCode { internal get; set; } = HttpStatusCode.OK;

        // Headers request.
        public WebHeaderCollection Headers { internal get; set; } = new WebHeaderCollection();

        // Contnt request.
        public byte[] Content { internal get; set; } = new byte[] { };

        // Content type request.
        public string ContentType { internal get; set; }
    }
}
