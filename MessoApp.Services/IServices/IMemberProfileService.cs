using MessoApp.DTO.RequestModels;
using MessoApp.DTO.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Services.IServices
{
    public interface IMemberProfileService
    {
        Task<List<MemberProfileResponseModel>> GetAllAsyn(int adminId);
        Task<int> Add(MemberProfileRequestModel model);
        Task<int> UpdateAsyn(int profileId, MemberProfileRequestModel model);
    }
}
