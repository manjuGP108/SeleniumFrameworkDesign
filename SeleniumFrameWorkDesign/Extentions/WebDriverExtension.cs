using System;
using System.Diagnostics;
using OpenQA.Selenium;
using SeleniumFrameWorkDesign.Base;
using SeleniumFrameWorkDesign.Config;

namespace SeleniumFrameWorkDesign.Extentions
{
    public static class WebDriverExtension
    {
        public static void WaitForDocumentLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(drv =>
            {
                var state = drv.ExecuteJs("return jQuery.active == 0");
                return state.ToString() == "True";
            }, Settings.Timeout);
        }

        internal static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                arg =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var sw = Stopwatch.StartNew();
            while (sw.Elapsed.Milliseconds < timeOut)
                if (execute(obj))
                    break;
        }

        internal static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }

        public static void WaitForJQuerryToBeFinished(this IWebDriver driver)
        {
            var sw = Stopwatch.StartNew();
            while (sw.Elapsed.Seconds < 120)
            {
                var state = DriverContext.Driver.ExecuteJs("return jQuery.active == 0");
                var a = state.ToString();
                if (state.ToString() == "True")
                    break;
            }
        }
    }
}