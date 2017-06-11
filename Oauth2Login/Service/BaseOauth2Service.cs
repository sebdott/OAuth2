using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Oauth2Login.Client;
using Oauth2Login.Core;

namespace Oauth2Login.Service
{
    public abstract class BaseOauth2Service : IClientService
    {
        protected AbstractClientProvider _client;

        protected BaseOauth2Service(AbstractClientProvider oClient)
        {
            _client = oClient;
        }

        public void CreateOAuthClient(IOAuthContext oContext)
        {
            _client = oContext.Client;
        }

        public void CreateOAuthClient(AbstractClientProvider oClient)
        {
            _client = oClient;
        }

        protected string HttpGet(string url)
        {
            var header = new NameValueCollection
            {
                {"Accept-Language", "en-US"}
            };

            return RestfullRequest.Request(url, "GET", "application/x-www-form-urlencoded", header, null, _client.Proxy);
        }

        protected string HttpPost(string urlToPost, string postData)
        {
            var result = RestfullRequest.Request(urlToPost, "POST", "application/x-www-form-urlencoded",
                    null, postData, _client.Proxy);

            return result;
        }

        // oh you abstract base class, leave something for children to implement
        public abstract string BeginAuthentication();
        public abstract string RequestToken(HttpRequestBase request);
        public abstract void RequestUserProfile();

        // TODO: This looks horrible, refactor using generics
        public static BaseOauth2Service GetService(string id)
        {
            switch (id.ToLower())
            {
                case "google":
                    return new GoogleService(Oauth2LoginFactory.CreateClient<GoogleClient>("Google"));
                case "facebook":
                    return new FacebookService(Oauth2LoginFactory.CreateClient<FacebookClient>("Facebook"));
                // Need to transition WindowLive to new base class
                //case "windowslive":
                //    return new WindowsLiveService(Oauth2LoginFactory.CreateClient<WindowsLiveClient>("WindowsLive"));
                //    break;
                case "paypal":
                    return new PayPalService(Oauth2LoginFactory.CreateClient<PayPalClient>("PayPal"));
                case "twitter":
                    return new TwitterService(Oauth2LoginFactory.CreateClient<TwitterClient>("Twitter"));
                default:
                    return null;
            }
        }


        public string ValidateLogin(HttpRequestBase request)
        {
            // client token
            string tokenResult = RequestToken(request);
            if (tokenResult == OAuth2Consts.ACCESS_DENIED)
                return _client.FailedRedirectUrl;

            _client.Token = tokenResult;

            // client profile
            RequestUserProfile();

            UserData.OAuthToken = _client.Token;
            UserData.OAuthTokenSecret = _client.TokenSecret;

            return null;
        }

        public void ImpersonateUser(string oauthToken, string oauthTokenSecret)
        {
            _client.Token = oauthToken;
            _client.TokenSecret = oauthTokenSecret;
        }

        protected void ParseUserData<TData>(string json) where TData : BaseUserData
        {
            UserDataJsonSource = json;
            UserData = ParseJson<TData>(json);
        }

        protected T ParseJson<T>(string json)
        {
            return JsonConvert.DeserializeAnonymousType(json, (T)Activator.CreateInstance(typeof(T)));
        }

        public BaseUserData UserData { get; set; }
        public string UserDataJsonSource { get; set; }
    }
}
