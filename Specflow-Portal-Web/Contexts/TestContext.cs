using System;
using Microsoft.Extensions.Configuration;

namespace ROCO.Specflow.PortalWeb.Contexts
{
    public static class TestContext
    {
        private static string _testDirectory;
        public static string TestDirectory => _testDirectory ?? (_testDirectory = AppDomain.CurrentDomain.BaseDirectory);
        public static IConfiguration Configuration;
    }
}