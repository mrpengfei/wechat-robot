using System;
using System.Net;

namespace Wechat.tools
{
    public class MyWebclient : WebClient
    {
        public int TimeOut { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (TimeOut <= 0 || request == null)
            {
                return request;
            }
            request.Timeout = TimeOut;
            return request;
        }
    }
}