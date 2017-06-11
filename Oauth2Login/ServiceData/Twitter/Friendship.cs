using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oauth2Login.ServiceData.Twitter
{
    public class Friendship
    {
        public string name { get; set; }
        public string screen_name { get; set; }
        public long id { get; set; }
        public string id_str { get; set; }
        public List<string> connections { get; set; }
    }
}
