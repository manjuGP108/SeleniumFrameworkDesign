using System.IO;
using System.Xml.XPath;

namespace SeleniumFrameWorkDesign.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            XPathItem aut;
            XPathItem testtype;
            XPathItem islog;
            XPathItem isreport;
            XPathItem buildname;
            XPathItem logPath;

            var strFilename = @"C:\\GIT clone repository\\SeleniumFramework\\SeleniumFrameWorkDesign\\Config\\GlobalConfig.xml";
            var stream = new FileStream(strFilename, FileMode.Open);
            var document = new XPathDocument(stream);
            var navigator = document.CreateNavigator();

            //Get XML Details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("EAAutoFramework/RunSettings/AUT");
            buildname = navigator.SelectSingleNode("EAAutoFramework/RunSettings/BuildName");
            testtype = navigator.SelectSingleNode("EAAutoFramework/RunSettings/TestType");
            islog = navigator.SelectSingleNode("EAAutoFramework/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("EAAutoFramework/RunSettings/IsReport");
            logPath = navigator.SelectSingleNode("EAAutoFramework/RunSettings/LogPath");

            //Set XML Details in the property to be used accross framework
            Settings.AUT = aut.Value;
            Settings.BuildName = buildname.Value;
            Settings.TestType = testtype.Value;
            Settings.IsLog = islog.Value;
            Settings.IsReporting = isreport.Value;
            Settings.LogPath = logPath.Value;
        }
    }
}