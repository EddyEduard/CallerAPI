using CallerAPI;
using System;

namespace CallerAPITest
{
    public partial class CallerAPITest
    {
        // Set the base address for request.
        private Uri Uri = new Uri("");

        public CallerAPITest()
        {
            _caller = new Caller(Uri);
        }

        private Caller _caller { get; set; }
    }
}
