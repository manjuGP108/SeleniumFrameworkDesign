using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Windows.Automation;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFrameWorkDesign
{
    public static class SeleniumSetMethods
    {
        public static void EnterTextBoxText(this IWebElement textBoxWebElement, string textBoxValue)
        {
            try
            {
                if (textBoxWebElement.Enabled)
                {
                    textBoxWebElement.Clear();
                    textBoxWebElement.SendKeys(textBoxValue);
                }
                else
                {
                    throw new ElementNotEnabledException();
                }
            }
            catch (Exception textBoxException)
            {
                Console.WriteLine("Not able to enter value into the text box. The exception type is "+textBoxException);
                throw;
            }
        }

        public static void SelectDropDownListByValue(this IWebElement dropDownElement, string dropDownListText)
        {
            SelectElement dropDownSelectElement = new SelectElement(dropDownElement);
            dropDownSelectElement.SelectByText(dropDownListText);
        }

        public static void SelectDropDownListByIndex(this IWebElement dropDownElement, int index)
        {
            SelectElement dropDownSelectElement = new SelectElement(dropDownElement);
            dropDownSelectElement.SelectByIndex(index);
        }

        public static void SendKeys(this IWebElement textBoxElement, string text)
        {
            textBoxElement.Click();
            textBoxElement.Clear();
            textBoxElement.SendKeys(text);
        }
    }
}
