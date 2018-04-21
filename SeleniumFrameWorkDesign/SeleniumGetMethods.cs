using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFrameWorkDesign
{
    public static class SeleniumGetMethods
    {

        // Extention Methods.
        // We can make methods as extention methods by making class as Public Static and using the Keyword this with 
        // IWebElement for the WebElement Parameter in the methods.
        // it avoids creating Objects to this class and these methods can be directly used as other methods of IWebElement
        // these methods becomes the extended methods of the IWebElement driver class.
        // https://www.youtube.com/watch?v=iKHNV2Je9-E&list=PL6tu16kXT9PqKSouJUV6sRVgmcKs-VCqo&index=11
        public static string GetTextBoxText(this IWebElement textBoxTextElement)
        {
            var textBoxText = textBoxTextElement.GetAttribute("value");
            return textBoxText;
        }

        public static string GetDropDownListSelectedValue(this IWebElement dropDownElement)
        {
            var dropDownSelectElement = new SelectElement(dropDownElement);
            return dropDownSelectElement.SelectedOption.Text;
        }

        public static List<string> GetDropDownListElements(this IWebElement dropDownElement)
        {
            var dropDownElements = new List<string>();
            var dropDownSelectElement = new SelectElement(dropDownElement);
            foreach (var elements in dropDownSelectElement.Options)
                dropDownElements.Add(elements.Text);
            return dropDownElements;
        }

        public static List<string> GetTableHeaders(this IWebElement tableHeader)
        {
            var tableHeaderElements = new List<IWebElement>(tableHeader.FindElements(By.TagName("th")));
            var tableHeaderElementValues = new List<string>();
            foreach (var item in tableHeaderElements)
            {
                tableHeaderElementValues.Add(item.Text);
            }
            return tableHeaderElementValues;
        }
    }
}