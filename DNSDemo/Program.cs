using System.Net;

namespace DNSDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('*', 30));

            // Get host entry by domain name
            var domainEntry = Dns.GetHostEntry("www.contoso.com");
            Console.WriteLine(domainEntry.HostName);
            foreach (var ip in domainEntry.AddressList)
            {
                Console.WriteLine(ip);
            }

            Console.WriteLine(new string('*', 30));

            // Get host entry by IP address
            var domainEntryByAddress = Dns.GetHostEntry("127.0.0.1");
            Console.WriteLine(domainEntryByAddress.HostName);
            foreach (var ip in domainEntryByAddress.AddressList)
            {
                Console.WriteLine(ip);
            }

            Console.ReadLine();
        }
    }
}
