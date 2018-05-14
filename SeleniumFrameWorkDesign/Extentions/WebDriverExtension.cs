using System;
using System.Diagnostics;
using OpenQA.Selenium;
using SeleniumFrameWorkDesign.Base;
using SeleniumFrameWorkDesign.Config;

namespace SeleniumFrameWorkDesign.Extentions
{
    public static class WebDriverExtension
    {
        internal static void WaitForDocumentLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(drv =>
            {
                var state = drv.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
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
            while (sw.ElapsedMilliseconds < timeOut)
                if (execute(obj))
                    break;
        }

        internal static object ExecuteJs(this IWebDriver driver, string script)
        {
            return (IJavaScriptExecutor)DriverContext.Driver;
        }
    }
}