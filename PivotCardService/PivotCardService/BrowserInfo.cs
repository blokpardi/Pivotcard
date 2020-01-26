using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TestHarness
{
    public class BrowserInfo
    {

        public string browserType { get; set; }
        public string browserName { get; set; }
        public string browserVersion { get; set; }
        public int browserMajorVersion { get; set; }
        public double browserMinorVersion { get; set; }
        public string browserPlatform { get; set; }
        public bool browserIsBeta { get; set; }
        public bool browserIsCrawler { get; set; }
        public bool browserIsAOL { get; set; }
        public bool browserIsWin16 { get; set; }
        public bool browserIsWin32 { get; set; }
        public bool browserSupportsFrames { get; set; }
        public bool browserSupportsTables { get; set; }
        public bool browserSupportsCookies { get; set; }
        public bool browserSupportsVB { get; set; }
        public string browserSupportsJavascript { get; set; }
        public bool browserSupportsJava { get; set; }
        public bool browserSupportsAX { get; set; }
        public string JavaScriptVersion { get; set; }
        public bool IsMobileDevice { get; set; }
        public bool SupportsHTML5 { get; set; }

        
        public BrowserInfo GetBrowserInfo(HttpRequest request)
        {
            bool detect = DetectForMobile(request);
            HttpBrowserCapabilities browser = request.Browser;

            bool html5 = DetectForHTML5(browser); 

            return new BrowserInfo
            {
                browserType = browser.Type,
                browserName = browser.Browser,
                browserVersion = browser.Version,
                browserMajorVersion = browser.MajorVersion,
                browserMinorVersion = browser.MinorVersion,
                browserPlatform = browser.Platform,
                browserIsBeta = browser.Beta,
                browserIsCrawler = browserIsCrawler,
                browserIsAOL = browser.AOL,
                browserIsWin16 = browser.Win16,
                browserIsWin32 = browser.Win32,
                browserSupportsFrames = browser.Frames,
                browserSupportsTables = browser.Tables,
                browserSupportsCookies = browser.Cookies,
                browserSupportsVB = browser.VBScript,
                browserSupportsJavascript = browser.EcmaScriptVersion.ToString(),
                browserSupportsJava = browser.JavaApplets,
                browserSupportsAX = browser.ActiveXControls,
                JavaScriptVersion = browser["JavaScriptVersion"],
                IsMobileDevice = detect,
                SupportsHTML5 = html5

            };
        }

        private bool DetectForMobile(HttpRequest request)
        {

            //http://code.google.com/p/mobileesp/source/browse/
            MDetectControl detect = new MDetectControl();
            detect.FireEvents(request); 
 
            if (detect.DetectWindowsPhone7() == true ||
                detect.DetectWindowsMobile() == true ||
                detect.DetectIphoneOrIpod() == true ||
                detect.DetectIphone() == true ||
                detect.DetectAndroidTablet() == true ||
                detect.DetectAndroidPhone() == true)
            {
                return true;  
            }

            return false; 
        }

        private bool DetectForHTML5(HttpBrowserCapabilities browser)
        {
            //http://www.html5test.com/results.html
            switch (browser.Browser)
            {
                case "IE":
                    if (browser.MajorVersion > 8) { return true; }
                    break;
                case "Firefox":
                    if (browser.MajorVersion > 3) { return true; } 
                    break;
                case "Chrome":
                    if (browser.MajorVersion > 3) { return true; }
                    break;
                case "Safari":
                    if (browser.MajorVersion > 3) { return true; }
                    break;
                case "Opera":
                    if (browser.MajorVersion > 10) { return true; }
                    break;
                default:
                    return false;
                     
            }

            return false;
        }
       

    }

    

}