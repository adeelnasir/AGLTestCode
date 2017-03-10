using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLTest.Configuration.Interfaces
{
    public interface IApplicationConfiguration
    {        
        string JsonWebServiceBaseUrl { get; }
        string JsonWebServiceRequestUri { get; }
    }
}
