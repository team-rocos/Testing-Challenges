using System;
using System.Threading;
using Polly;
using ROCO.Specflow.PortalWeb.Contexts;

namespace ROCO.Specflow.PortalWeb.Helpers
{
    class RetryHelper
    {
        public static void WaitFor(Func<Boolean> func, int count)
        {
            var retryPolicy = Policy.Handle<Exception>()
                .Retry(count, (exception, i) =>
                {
                    Thread.Sleep(1000);
                });

            retryPolicy.Execute(func);
        }
    }
}