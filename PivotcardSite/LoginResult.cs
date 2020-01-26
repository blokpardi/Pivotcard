using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PivotcardSite
{
    public class LoginResult
    {
        public string status { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }
}