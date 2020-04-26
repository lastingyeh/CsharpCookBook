using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CookBook.Ch9
{
    public static class EX903
    {
        public static void Run()
        {
            Uri proxyURI = new Uri("http://webproxy:80");
            // Set default WebRequest proxy
            WebRequest.DefaultWebProxy = new WebProxy(proxyURI);
        }


        public static HttpWebRequest AddProxyInfoToRequest(HttpWebRequest request,
            Uri uri, string proxyId, string proxyPassword, string proxyDomain)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            WebProxy webProxy = new WebProxy();

            webProxy.Address = uri;
            webProxy.BypassProxyOnLocal = true;
            webProxy.Credentials = new NetworkCredential(proxyId, proxyPassword, proxyDomain);

            request.Proxy = webProxy;

            return request;
        }
    }
}
