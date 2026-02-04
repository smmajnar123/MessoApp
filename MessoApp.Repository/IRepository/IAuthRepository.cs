using MessoApp.DTO.ResponseModels;
using MessoApp.Helper.Common.Enums;

namespace MessoApp.Repository.IRepository
{
    public interface IAuthRepository
    {
        Task<AuthResponseModel> AuthenticateAsync(string mobile, string passwordHash, Role role);
    }
}
