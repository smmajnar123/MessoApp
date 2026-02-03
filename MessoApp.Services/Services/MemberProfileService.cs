using MessoApp.DTO.RequestModels;
using MessoApp.DTO.ResponseModels;
using MessoApp.Repository.IRepository;
using MessoApp.Services.IServices;

namespace MessoApp.Services.Services
{
    public class MemberProfileService(IMemberProfileRepository memberProfileRepository) : IMemberProfileService
    {
        private readonly IMemberProfileRepository _memberProfileRepository = memberProfileRepository;
        public async Task<List<MemberProfileResponseModel>> GetAllAsyn(int adminId)
        {
            return await _memberProfileRepository.GetAllAsyn(adminId);
        }

        public async Task<int> AddAsyn(MemberProfileRequestModel model)
        {
            return await _memberProfileRepository.AddAsyn(model);
        }

        public async Task<int> UpdateAsyn(int profileId, MemberProfileRequestModel model)
        {
            return await _memberProfileRepository.UpdateAsyn(profileId, model);
        }
    }
}
