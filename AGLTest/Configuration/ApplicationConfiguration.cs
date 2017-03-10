using AGLTest.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLTest.Configuration
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public ApplicationConfiguration()
        {
            JsonWebServiceBaseUrl = ConfigurationManager.AppSettings["Json.WebService.BaseURL"];
            JsonWebServiceRequestUri = ConfigurationManager.AppSettings["Json.WebService.RequestUri"];
        }
        public string JsonWebServiceBaseUrl { get; }
        public string JsonWebServiceRequestUri { get; }
    }
}
