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
    public class MemberMessDetailService(IMemberMessDetailRepository memberMessDetailRepository) : IMemberMessDetailService
    {
        private readonly IMemberMessDetailRepository _memberMessDetailRepository = memberMessDetailRepository;
        public async Task<MemberMessDetailResponseModel?> GetMemberMessDetailsAsync(int profileId)
        {
            return await _memberMessDetailRepository.GetMemberMessDetailsAsync(profileId);
        }
    }
}
