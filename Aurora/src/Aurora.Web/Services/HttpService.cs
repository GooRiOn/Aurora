using System.Net.Http;
using System.Threading.Tasks;
using Aurora.Web.Services.Interfaces;

namespace Aurora.Web.Services
{
    public class HttpService : IHttpService
    {
        public async Task<byte[]> GetByteArrayAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetByteArrayAsync(url);
            }
        }
    }
}
