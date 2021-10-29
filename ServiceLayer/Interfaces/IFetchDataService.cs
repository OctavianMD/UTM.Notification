using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IFetchDataService
    {
        Task<int> FetchSenders();
        Task<int> FetchReceivers();
    }
}
