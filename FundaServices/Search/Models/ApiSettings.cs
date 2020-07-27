using System;

namespace PropertyServices.Search
{
    public class ApiSettings
    {
        public Uri BaseUrl { get; set; }
        public string ApiPath { get; set; }
        public string ApiKey { get; set; }
        public int MaxPageSize { get; set; }
    }
}