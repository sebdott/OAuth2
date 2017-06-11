using Oauth2Login.Configuration;
using Oauth2Login.Core;
using Oauth2Login.Service;

namespace Oauth2Login.Client
{
    public class WindowsLiveClient : AbstractClientProvider
    {
        public WindowsLiveClient()
        {
        }

        public WindowsLiveClient(OAuthWebConfigurationElement ccRoot, OAuthConfigurationElement ccOauth)
            : base(ccRoot, ccOauth)
        {
            //ServiceType = typeof (WindowsLiveService);
        }

        public class Emails
        {
            public string Preferred { get; set; }
            public string Account { get; set; }
            public string Personal { get; set; }
            public string Business { get; set; }
        }

        public class UserProfile
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string First_name { get; set; }
            public string Last_name { get; set; }
            public string Link { get; set; }
            public string Gender { get; set; }
            public Emails Emails { get; set; }
        }
    }
}