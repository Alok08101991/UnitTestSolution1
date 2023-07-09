using System;
using System.IO;
using CsvHelper;
using OpenQA.Selenium;
using System.Drawing;

namespace UnitTestProject1.Framework
{
    class Utilities
    {
        public static string GetDatafromCsv(string csvFilePath, string uniqueFieldname,string uniqueFieldValue,string targetFieldName, string strException)
        {
            try
            {
                var reader = File.OpenText(csvFilePath);
                var csv = new CsvReader(reader);

                while(csv.Read())
                {
                    if(csv.GetField<string>(uniqueFieldname)==uniqueFieldValue)
                    {
                        strException = null;
                        return csv.GetField<string>(targetFieldName);
                    }                    
                }
                strException = null;
                return null;
            }
            catch(Exception e)
            {
                strException = e.ToString();
                return null;
            }
        }

        public static void ScreenCapture(IWebDriver driver, string path, string fileName)
        {
            path = Path.Combine(path, "Screenshots");

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            ss.SaveAsFile(path + "\\" + fileName + ".png", ScreenshotImageFormat.Png);
        }
    }
}
