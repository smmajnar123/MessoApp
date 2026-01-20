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
    public class MemberService(IMemberRepository memberRepository) : IMemberService
    {
        private readonly IMemberRepository _memberRepository = memberRepository;

        public async Task<List<MemberProfileResponse>> GetAllMembersByMessIdAsync(int messId)
        {
            return await _memberRepository.GetAllMembersByMessIdAsync(messId);
        }
    }
}
