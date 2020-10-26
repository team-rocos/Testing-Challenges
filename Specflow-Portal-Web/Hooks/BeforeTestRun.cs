using System.IO;
using BoDi;
using Microsoft.Extensions.Configuration;
using ROCO.Specflow.PortalWeb.Contexts;
using ROCO.Specflow.PortalWeb.Drivers;
using ROCO.Specflow.PortalWeb.Drivers.Interfaces;
using TechTalk.SpecFlow;

namespace ROCO.Specflow.PortalWeb.Hooks
{
    [Binding]
    public class BeforeTestRun
    {
        [BeforeTestRun(Order = 1)]
        public static void RegisterDependencies(IObjectContainer objectContainer)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(TestContext.TestDirectory, "appsettings.json"), optional: true, reloadOnChange: true)
                .Build();

            objectContainer.RegisterInstanceAs(config);
            TestContext.Configuration = config;

            objectContainer.RegisterTypeAs<SignUpDriver, ISignUpDriver>();
        }
    }
}