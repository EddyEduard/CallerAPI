using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallerAPITest
{
    // Tests all methods of request with simple result without to deserialize the result and errors to a model object.

    [TestClass]
    public partial class CallerAPITest
    {
        // Here is tested:
        // - if status result is equal with a certain value set by user.
        // - if result is null or empty.

        // Test GET method.
        [TestMethod]
        [DataRow("", HttpStatusCode.OK)]
        public async Task GetAsyncTest(string url, HttpStatusCode statusCode)
        {
            var headers = new WebHeaderCollection();

            var result = await _caller.RequestTextAsync(x =>
            {
                x.URI = url;
                x.Method = "GET";
                x.HttpStatusCode = statusCode;
                x.Headers = headers;
            });

            Assert.AreEqual(statusCode, result.Status);
            Assert.IsNotNull(result.Value);
        }

        // Test POST method.
        [TestMethod]
        [DataRow("", HttpStatusCode.OK, "")]
        public async Task PostAsyncTest(string url, HttpStatusCode statusCode, string contentType)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] content = encoding.GetBytes("");

            var headers = new WebHeaderCollection();

            var result = await _caller.RequestTextAsync(x =>
            {
                x.URI = url;
                x.Method = "POST";
                x.HttpStatusCode = statusCode;
                x.Headers = headers;
                x.ContentType = contentType;
                x.Content = content;
            });

            Assert.AreEqual(statusCode, result.Status);
            Assert.IsNotNull(result.Value);
        }

        // Test PUT method.
        [TestMethod]
        [DataRow("", HttpStatusCode.OK, "")]
        public async Task PutAsyncTest(string url, HttpStatusCode statusCode, string contentType)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] content = encoding.GetBytes("");

            var headers = new WebHeaderCollection();

            var result = await _caller.RequestTextAsync(x =>
            {
                x.URI = url;
                x.Method = "PUT";
                x.HttpStatusCode = statusCode;
                x.Headers = headers;
                x.ContentType = contentType;
                x.Content = content;
            });

            Assert.AreEqual(statusCode, result.Status);
            Assert.IsNotNull(result.Value);
        }

        // Test PATCH method.
        [TestMethod]
        [DataRow("", HttpStatusCode.OK, "")]
        public async Task PatchAsyncTest(string url, HttpStatusCode statusCode, string contentType)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] content = encoding.GetBytes("");

            var headers = new WebHeaderCollection();

            var result = await _caller.RequestTextAsync(x =>
            {
                x.URI = url;
                x.Method = "PATCH";
                x.HttpStatusCode = statusCode;
                x.Headers = headers;
                x.ContentType = contentType;
                x.Content = content;
            });

            Assert.AreEqual(statusCode, result.Status);
            Assert.IsNotNull(result.Value);
        }

        // Test DELETE method.
        [TestMethod]
        [DataRow("", HttpStatusCode.OK)]
        public async Task DeleteAsyncTest(string url, HttpStatusCode statusCode)
        {
            var headers = new WebHeaderCollection();

            var result = await _caller.RequestTextAsync(x =>
            {
                x.URI = url;
                x.Method = "DELETE";
                x.HttpStatusCode = statusCode;
                x.Headers = headers;
            });

            Assert.AreEqual(statusCode, result.Status);
            Assert.IsNotNull(result.Value);
        }
    }
}
