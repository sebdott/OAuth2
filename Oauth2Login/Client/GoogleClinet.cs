using Oauth2Login.Configuration;
using Oauth2Login.Core;
using Oauth2Login.Service;

namespace Oauth2Login.Client
{
    public class GoogleClient : AbstractClientProvider
    {
        public GoogleClient()
        {
        }

        public GoogleClient(OAuthWebConfigurationElement ccRoot, OAuthConfigurationElement ccOauth)
            : base(ccRoot, ccOauth)
        {
            //ServiceType = typeof (GoogleService);
        }
    }
}