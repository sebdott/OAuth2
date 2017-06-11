using System;
using System.Collections;
using System.Configuration;
using Oauth2Login.Configuration;

namespace Oauth2Login.Core
{
    public class Oauth2LoginFactory
    {
        public static T CreateClient<T>(string configName) where T : AbstractClientProvider, new()
        {
            if (String.IsNullOrEmpty(configName))
                throw new Exception("Invalid configuration name");

            var ccRoot =
                ConfigurationManager.GetSection("oauth2.login.configuration") as OAuthConfigurationSection;

            if (ccRoot != null)
            {
                var ccWebElem = ccRoot.WebConfiguration;

                IEnumerator configurationReader = ccRoot.OAuthVClientConfigurations.GetEnumerator();

                OAuthConfigurationElement ccOauth = null;
                while (configurationReader.MoveNext())
                {
                    var currentOauthElement = configurationReader.Current as OAuthConfigurationElement;
                    if (currentOauthElement != null && currentOauthElement.Name == configName)
                    {
                        ccOauth = currentOauthElement;
                        break;
                    }
                }

                if (ccOauth != null)
                {
                    var constructorParams = new object[]
                    {
                        ccWebElem,
                        ccOauth
                    };
                    var client = (T) Activator.CreateInstance(typeof (T), constructorParams);

                    return client;
                }
                else
                {
                    throw new Exception("ERROR: [MultiOAuthFactroy] ConfigurationName is not found!");
                }

            }

            return default(T);
        }

        //public static T CreateClient<T>(string oClientId, string oClientSecret, string oCallbackUrl, string oScope,
        //    string oAcceptedUrl, string oFailedUrl, string oProxy) where T : AbstractClientProvider, new()
        //{
        //    var client = (T) Activator.CreateInstance(typeof (T), new object[]
        //    {
        //        oClientId,
        //        oClientSecret,
        //        oCallbackUrl,
        //        oScope,
        //        oAcceptedUrl,
        //        oFailedUrl,
        //        oProxy
        //    });
        //    return client;
        //}
    }
}