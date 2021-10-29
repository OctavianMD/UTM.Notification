using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IFetchDataClient
    {
        Task<string> FetchSenders();
        Task<string> FetchReceivers();
    }
}
