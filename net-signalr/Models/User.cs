using System;
using System.Collections.Generic;

namespace net_signalr.Models
{
    public static class User
    {
        public static List<string> users = new List<string>();
        public static object lockObject = new Object();
    }
}