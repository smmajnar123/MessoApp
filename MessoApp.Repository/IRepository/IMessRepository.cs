using MessoApp.DTO.RequestModels;
using MessoApp.DTO.ResponseModels;

namespace MessoApp.Repository.IRepository
{
    public interface IMessRepository
    {
        Task<List<MessResponse>> GetAllAsyn(int adminId);

        Task<int> AddAsyn(MessRequestModel model);

        Task<int> UpdateAsyn(int messId, MessRequestModel model);
    }
}
