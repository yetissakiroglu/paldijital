using System;
using System.Collections.Generic;
using System.Text;

namespace Pal.Core.EmailServices
{
    public class StmpOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
