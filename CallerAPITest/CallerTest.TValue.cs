using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallerAPITest
{
    // Tests all methods of request with deserialize result to a model object without to deserialize the errors to a model object.

    public partial class CallerAPITest
    {
        // Here is tested:
        // - if status result is equal with a certain value set by user.
        // - if result is same with an object which was set for deserialize.

        // Test GET method.
        [TestMethod]
        [DataRow("", HttpStatusCode.OK)]
        public async Task Get_TValue_AsyncTest(string url, HttpStatusCode statusCode)
        {
            var headers = new WebHeaderCollection();

            var result = await _caller.RequestJSONAsync<object>(x =>
            {
                x.URI = url;
                x.Method = "GET";
                x.HttpStatusCode = statusCode;
                x.Headers = headers;
            });

            Assert.AreEqual(statusCode, result.Status);
            Assert.AreSame(typeof(object), result.Value.GetType());
        }

        // Test POST method.
        [TestMethod]
        [DataRow("", HttpStatusCode.OK, "")]
        public async Task Post_TValue_AsyncTest(string url, HttpStatusCode statusCode, string contentType)
        { 
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] content = encoding.GetBytes("");

            var headers = new WebHeaderCollection();

            var result = await _caller.RequestJSONAsync<object>(x =>
            {
                x.URI = url;
                x.Method = "POST";
                x.HttpStatusCode = statusCode;
                x.Headers = headers;
                x.ContentType = contentType;
                x.Content = content;
            });

            Assert.AreEqual(statusCode, result.Status);
            Assert.AreSame(typeof(object), result.Value.GetType());
        }

        // Test PUT method.
        [TestMethod]
        [DataRow("", HttpStatusCode.OK, "")]
        public async Task Put_TValue_AsyncTest(string url, HttpStatusCode statusCode, string contentType)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] content = encoding.GetBytes("");

            var headers = new WebHeaderCollection();

            var result = await _caller.RequestJSONAsync<object>(x =>
            {
                x.URI = url;
                x.Method = "PUT";
                x.HttpStatusCode = statusCode;
                x.Headers = headers;
                x.ContentType = contentType;
                x.Content = content;
            });

            Assert.AreEqual(statusCode, result.Status);
            Assert.AreSame(typeof(object), result.Value.GetType());
        }

        // Test PATCH method.
        [TestMethod]
        [DataRow("", HttpStatusCode.OK, "")]
        public async Task Patch_TValue_AsyncTest(string url, HttpStatusCode statusCode, string contentType)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] content = encoding.GetBytes("");

            var headers = new WebHeaderCollection();

            var result = await _caller.RequestJSONAsync<object>(x =>
            {
                x.URI = url;
                x.Method = "PATCH";
                x.HttpStatusCode = statusCode;
                x.Headers = headers;
                x.ContentType = contentType;
                x.Content = content;
            });

            Assert.AreEqual(statusCode, result.Status);
            Assert.AreSame(typeof(object), result.Value.GetType());
        }

        // Test DELETE method.
        [TestMethod]
        [DataRow("", HttpStatusCode.OK, "")]
        public async Task Delete_TValue_AsyncTest(string url, HttpStatusCode statusCode)
        {
            var headers = new WebHeaderCollection();

            var result = await _caller.RequestJSONAsync<object>(x =>
            {
                x.URI = url;
                x.Method = "DELETE";
                x.HttpStatusCode = statusCode;
                x.Headers = headers;
            });

            Assert.AreEqual(statusCode, result.Status);
            Assert.AreSame(typeof(object), result.Value.GetType());
        }
    }
}
