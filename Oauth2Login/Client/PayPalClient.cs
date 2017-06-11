using System;
using Oauth2Login.Configuration;
using Oauth2Login.Core;
using Oauth2Login.Service;

namespace Oauth2Login.Client
{
    public class PayPalClient : AbstractClientProvider
    {
        public PayPalClient()
        {
        }

        public PayPalClient(OAuthWebConfigurationElement ccRoot, OAuthConfigurationElement ccOauth)
            : base(ccRoot, ccOauth)
        {
            //ServiceType = typeof (PayPalService);
        }

    }
}