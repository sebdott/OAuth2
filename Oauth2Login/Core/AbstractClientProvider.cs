using System;
using System.Collections.Generic;
using Oauth2Login.Client;
using Oauth2Login.Configuration;

namespace Oauth2Login.Core
{
    public abstract class AbstractClientProvider
    {
        protected AbstractClientProvider()
        {
        }

        protected AbstractClientProvider(OAuthWebConfigurationElement ccRoot, OAuthConfigurationElement ccOauth)
        {
            // TODO: This copying still feels wrong - config class and this client base class share data
            ClientId = ccOauth.ClientId;
            ClientSecret = ccOauth.ClientSecret;
            CallBackUrl = ccOauth.CallbackUrl;
            Scope = ccOauth.Scope;
            Endpoint = ccOauth.Endpoint;
            
            //AcceptedRedirectUrl = ccRoot.AcceptedRedirectUrl;
            FailedRedirectUrl = ccRoot.FailedRedirectUrl;
            Proxy = ccRoot.Proxy;
        }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string CallBackUrl { get; set; }
        public string Scope { get; set; }
        public string Endpoint { get; set; }

        //public string AcceptedRedirectUrl { get; set; }
        public string FailedRedirectUrl { get; set; }
        public string Proxy { get; set; }

        public string Token { get; set; }
        public string TokenSecret { get; set; }
    }
}