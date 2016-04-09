using System.Threading.Tasks;

namespace Aurora.Web.Services.Interfaces
{
    public interface IHttpService
    {
        Task<byte[]> GetByteArrayAsync(string url);
    }
}