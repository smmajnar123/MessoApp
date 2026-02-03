using MessoApp.DTO.RequestModels;
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
        public async Task<List<MemberMessDetailResponseModel>> GetAllAsyn(int messId)
        {
            return await _memberMessDetailRepository.GetAllAsyn(messId);
        }
    }
}
