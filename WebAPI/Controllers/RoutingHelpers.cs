using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public static class RoutingHelpers
    {

        internal const string v1_0 = "1.0";
        internal const string VersionControllerRoute = "api/v{version:apiVersion}/[controller]";
        internal const string APIVersion = "v1.0.0";

    }
}
