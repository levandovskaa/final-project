using OpenQA.Selenium;
using System;
using System.IO;

namespace FinalProject.Tools
{
    class MyScreenshot
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string path = Directory.GetParent(Environment.CurrentDirectory).ToString();
            ss.SaveAsFile(Path.GetFullPath(Path.Combine(path, @$"..\..\Screenshots\{GetTimestamp(DateTime.Now)}.png")));
        }

        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}
