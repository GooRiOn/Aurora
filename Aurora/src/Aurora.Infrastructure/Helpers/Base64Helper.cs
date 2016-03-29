using System;
using System.Text;

namespace Aurora.Infrastructure.Helpers
{
    public static class Base64Helper
    {
        public static string Encode(string content)
        {
            var tokenBytes = Encoding.ASCII.GetBytes(content);
            return Convert.ToBase64String(tokenBytes);
        }

        public static string Decode(string content)
        {
            var tokenBytes = Convert.FromBase64String(content);
            return Encoding.ASCII.GetString(tokenBytes);
        }
    }
}
