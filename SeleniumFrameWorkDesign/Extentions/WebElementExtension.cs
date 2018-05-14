using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumFrameWorkDesign.Base;

namespace SeleniumFrameWorkDesign.Extentions
{
    public static class WebElementExtension
    {
        public static void SelectDDL(this IWebElement element, string value)
        {
            var ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        public static void Hover(this IWebElement element)
        {
            var action = new Actions(DriverContext.Driver);
            action.MoveToElement(element).Perform();
        }

        public static void HoverAndClick(this IWebElement elementToHover, IWebElement elementToClick)
        {
            var action = new Actions(DriverContext.Driver);
            action.MoveToElement(elementToHover).Click(elementToClick).Build().Perform();
        }

        public static string GetText(IWebElement element)
        {
            return element.Text;
        }


        public static string GetSelectedDropDown(IWebElement element)
        {
            var ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }


        public static IList<IWebElement> GetSelectedListOptions(IWebElement element)
        {
            var ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }


        /// <summary>
        ///     Check if the element exist
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                var b = element.Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Assert if the Element is present
        /// </summary>
        /// <param name="element"></param>
        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new AssertFailedException("AssertElementNotPresent exception");
        }
    }
}