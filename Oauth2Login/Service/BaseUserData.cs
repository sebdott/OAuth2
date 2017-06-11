using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oauth2Login.Core;

namespace Oauth2Login.Service
{
    public abstract class BaseUserData
    {
        protected BaseUserData(ExternalAuthServices authService)
        {
            AuthService = authService;
        }

        public abstract string UserId { get; }
        public abstract string Email { get; }
        public abstract string PhoneNumber { get; }
        public abstract string FullName { get; }

        public string OAuthToken { get; set; }
        public string OAuthTokenSecret { get; set; }
        public ExternalAuthServices AuthService { get; private set; }
    }
}
