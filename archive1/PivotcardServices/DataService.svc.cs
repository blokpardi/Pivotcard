using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;
using System.Net;

namespace PivotcardServices
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DataService
    {
        [OperationContract]
        [WebGet(UriTemplate = "checkUser/{UserName}", ResponseFormat = WebMessageFormat.Xml)]
        public string checkUser(string UserName)
        {
           return UserData.checkUser(UserName);
        }

        [WebGet(UriTemplate = "loginUser/{UserName}/{Password}/{FirstName}", ResponseFormat = WebMessageFormat.Json)]
        public string loginUser(string UserName, string Password, string FirstName)
        {
            return UserData.loginUser(UserName, Password, FirstName);
        }

        [WebGet(UriTemplate = "janrainLogin/{token}", ResponseFormat = WebMessageFormat.Json)]
        public string janrainLogin(string token)
        {
            return UserData.janrainLogin(token);
        }
    }
}