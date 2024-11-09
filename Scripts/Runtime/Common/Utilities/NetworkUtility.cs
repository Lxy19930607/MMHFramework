using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace MMHFramework
{
    public static class NetworkUtility
    {
        public static string GetLocalIP()
        {
            IPAddress[] addresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for(int i = 0; i < addresses.Length; i++)
            {
                if(addresses[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    return addresses[i].ToString();
                }
            }
            return IPAddress.Any.ToString();
        }

        public static string[] GetLocalIPs()
        {
            IPAddress[] addresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            List<string> result = new List<string>();
            for(int i = 0; i < addresses.Length; i++)
            {
                if(addresses[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    result.Add(addresses[i].ToString());
                }
            }
            return result.ToArray();
        }

        public static string GetLocalIPv6()
        {
            IPAddress[] addresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for(int i = 0; i < addresses.Length; i++)
            {
                if(addresses[i].AddressFamily == AddressFamily.InterNetworkV6)
                {
                    return addresses[i].ToString();
                }
            }
            return IPAddress.IPv6Any.ToString();
        }

        public static string[] GetLocalIPv6s()
        {
            IPAddress[] addresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            List<string> result = new List<string>();
            for(int i = 0; i < addresses.Length; i++)
            {
                if(addresses[i].AddressFamily == AddressFamily.InterNetworkV6)
                {
                    result.Add(addresses[i].ToString());
                }
            }
            return result.ToArray();
        }
    }
}