using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CallerAPI
{
    internal class RequestAPI
    {
        public RequestAPI(Uri baseAddress)
        {
            BaseAddress = baseAddress;
        }

        // Http status code.
        public HttpStatusCode StatusCode { get; private set; }

        // Result content like text.
        public string TextResult { get; private set; }

        // Result exception content like text.
        public string ExceptionTextResult { get; private set; }

        // Set base address.
        private Uri BaseAddress { get; set; }

        /// <summary>
        /// Request a web service.
        /// </summary>
        /// <param name="action">Set params for request.</param>
        public async Task RequestAPIAsync(Params @params)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(BaseAddress + @params.URI) as HttpWebRequest;
                request.Method = @params.Method;
                request.Headers = @params.Headers;

                if (@params.Content.Length > 0)
                {
                    request.ContentType = @params.ContentType;
                    request.ContentLength = @params.Content.Length;

                    using (Stream dataStream = request.GetRequestStream())
                        dataStream.Write(@params.Content, 0, @params.Content.Length);
                }

                HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    TextResult = await reader.ReadToEndAsync();
                    StatusCode = response.StatusCode;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;

                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    ExceptionTextResult = await reader.ReadToEndAsync();
                    StatusCode = (ex.Response as HttpWebResponse).StatusCode;
                }
            }
        }
    }
}
