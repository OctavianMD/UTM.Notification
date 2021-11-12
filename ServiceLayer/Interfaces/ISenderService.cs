using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface ISenderService
    {
        Task<SenderViewModel> Get(int id);
        Task<List<SenderViewModel>> GetAll();
        Task Create(SenderViewModel model);
        Task Update(SenderViewModel model);
        Task Remove(int id);
    }
}
