using MessoApp.DTO.RequestModels;
using MessoApp.DTO.ResponseModels;
using MessoApp.Repository.IRepository;
using MessoApp.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Services.Services
{
    public class MemberProfileService(IMemberProfileRepository memberProfileRepository) : IMemberProfileService
    {
        public async Task<List<MemberProfileResponseModel>> GetAll(int adminId)
        {
            return await memberProfileRepository.GetAll(adminId);
        }
        public async Task<int> Add(MemberProfileRequestModel model)
        {
           return await memberProfileRepository.Add(model);
        }
    }
}
