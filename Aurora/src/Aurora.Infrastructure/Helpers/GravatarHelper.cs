using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Aurora.Infrastructure.Helpers
{
    public static class GravatarHelper
    {
        public static string CreateGravatarUrl(string userName)
        {
            var md5 = MD5.Create();

            var userNameTextBytes = Encoding.UTF8.GetBytes(userName);
            var hashBytes = md5.ComputeHash(userNameTextBytes);

            var hashString = string.Concat(hashBytes.Select(h => h.ToString("x2"))).ToLower();

            return $"http://www.gravatar.com/avatar/{hashString}?size=56&d=retro";
        }
    }
}
