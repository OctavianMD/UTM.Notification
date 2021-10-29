using System.Threading.Tasks;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class FetchDataService: IFetchDataService
    {
        private readonly IFetchDataClient _fetchDataClient;

        public FetchDataService(IFetchDataClient fetchDataClient)
        {
            _fetchDataClient = fetchDataClient;
        }

        public async Task<int> FetchSenders()
        {
            var result = await _fetchDataClient.FetchSenders();
            // ToDO implement logic
            return 1;
        }

        public async Task<int> FetchReceivers()
        {
            var result = await _fetchDataClient.FetchReceivers();
            // ToDO implement logic
            return 1;
        }
    }
}
