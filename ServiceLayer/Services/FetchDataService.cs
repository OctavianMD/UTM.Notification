using System.Threading.Tasks;
using BusinessLayer.Helpers;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services 
{
    public class FetchDataService: IFetchDataService
    {
        private readonly IFetchDataClient _fetchDataClient;
        private readonly SenderHelper _senderHelper;
        private readonly ReceiverHelper _receiverHelper;


        public FetchDataService(
            IFetchDataClient fetchDataClient,
            SenderHelper senderHelper,
            ReceiverHelper receiverHelper)
        {
            _fetchDataClient = fetchDataClient;
            _senderHelper = senderHelper;
            _receiverHelper = receiverHelper;
        }
            
        public async Task<int> FetchSenders()
        {
            var result = await _fetchDataClient.FetchSenders();
            return await _senderHelper.ProcessFetchedData(result);
        }

        public async Task<int> FetchReceivers()
        {
            var result = await _fetchDataClient.FetchReceivers();
            return await _receiverHelper.ProcessFetchedData(result);
        }
    }
}
