using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Web;
using System.Web.Caching;

namespace svcLogin
{
    public class janrainData
    {
        public string token { get; set; }

        public static string janrainId(string token)
        {
            var rpx = new Rpx("38b726baa689dd1afdcb82e91f905101e660d73a", "https://rpxnow.com");
            var authInfo = rpx.AuthInfo(token);
            var doc = XDocument.Load(new XmlNodeReader(authInfo));
            string identifier = doc.Root.Descendants("identifier").First().Value;
            return identifier;
        }
    }
}