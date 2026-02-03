using MessoApp.DTO.RequestModels;
using MessoApp.DTO.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Repository.IRepository
{
    public interface IMemberProfileRepository
    {
        Task<List<MemberProfileResponseModel>> GetAllAsyn(int adminId);
        Task<int> Add(MemberProfileRequestModel model);

        Task<int> UpdateAsyn(int profileId, MemberProfileRequestModel model);
    }
}
