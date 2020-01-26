using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace svcLogin
{
    [ServiceContract, ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class login
    {
        //[OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        public string GetJanrainData(string token)
        {
            // TODO: Add the new instance of SampleItem to the collection
            //string iToken = formsData["token"];
            return token;// janrainData.janrainId(iToken).ToString();
        }
    }

}
