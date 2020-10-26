using System;

namespace ROCO.Specflow.PortalWeb.Contexts
{
    public class TestRunContext
    {

        public string Hostname => GetAppSetting("BaseUrl", "");
        public string Browser => GetAppSetting("Browser", "");
        public TimeSpan Timeout => TimeSpan.FromSeconds(double.Parse(GetAppSetting("TimeoutInSeconds", "")));
        public int Retry => int.Parse(GetAppSetting("Retry", "10"));

        private string GetAppSetting(string key, string defaultValue)
        {
            var value = TestContext.Configuration[key];
            if (value == null || string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }
            return value;
        }
    }
}