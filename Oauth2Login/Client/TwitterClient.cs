using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oauth2Login.Configuration;
using Oauth2Login.Core;
using Oauth2Login.Service;

namespace Oauth2Login.Client
{
    public class TwitterClient : AbstractClientProvider
    {
        public TwitterClient()
        {
        }

        public TwitterClient(OAuthWebConfigurationElement ccRoot, OAuthConfigurationElement ccOauth)
            : base(ccRoot, ccOauth)
        {
            //ServiceType = typeof(TwitterService);
        }
    }
}
