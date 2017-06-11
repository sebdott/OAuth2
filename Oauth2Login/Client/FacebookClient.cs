using Oauth2Login.Configuration;
using Oauth2Login.Core;
using Oauth2Login.Service;

namespace Oauth2Login.Client
{
    public class FacebookClient : AbstractClientProvider
    {
        public FacebookClient()
        {
        }

        public FacebookClient(OAuthWebConfigurationElement ccRoot, OAuthConfigurationElement ccOauth)
            : base(ccRoot, ccOauth)
        {
            //ServiceType = typeof (FacebookService);
        }
    }
}