using MessoApp.DTO.ResponseModels;

namespace MessoApp.Repository.IRepository
{
    public interface IMessRepository
    {
        Task<List<MessResponse>> GetAllMessByAdminIdAsync(int adminId);
    }
}
