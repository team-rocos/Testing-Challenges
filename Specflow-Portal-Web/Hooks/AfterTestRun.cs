using ROCO.Specflow.PortalWeb.Infrastructure;
using TechTalk.SpecFlow;

namespace ROCO.Specflow.PortalWeb.Hooks
{
    [Binding]
    public class AfterTestRun
    {
        [AfterTestRun(Order = 0)]
        public static void DisposeBrowser(BrowserDriver browserDriver)
        {
            browserDriver?.Dispose();
        }
    }
}