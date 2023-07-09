using System;
using System.Management;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace UnitTestProject1.Framework
{
    public static class KeyFunctions
    {
        public static string _currentDateTime;
        public static string screen;
        public static string strProjectDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
        public static string strObjRepPath = Path.Combine(strProjectDir, "ObjectRepository", "ObjRep.csv");
        public static string strTestDataPath = Path.Combine(strProjectDir, "Data", "TestData.csv");
        public static string strTestCasePath = Path.Combine(strProjectDir, "TestCase", "Testcases.csv");
        public static string strConfigPath = Path.Combine(strProjectDir, "Config", "Config.csv");
        public static string strTestResultsPath = Path.Combine(strProjectDir, "Results");
        public static string CurrentTestCaseResultPath;
        //public static string strScreenShotPolicy = GetConfigData("ScreenShotPolicy");
        

        //public static string GetConfigData(string strConfigName)
        //{
        //    string strException;
        //    //string strException;
        //    return Utilities.GetDatafromCsv(strConfigPath, "ConfigName", strConfigName, "ConfigValue", out strException);
        //}
    }
}