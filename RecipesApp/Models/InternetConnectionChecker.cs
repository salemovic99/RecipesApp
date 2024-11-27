using System.Net.NetworkInformation;

namespace RecipesApp.Models
{
    public class InternetConnectionChecker
    {
        public static bool IsInternetAvailable()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("www.google.com");
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (PingException)
            {
                return false;
            }
        }
    }

}
