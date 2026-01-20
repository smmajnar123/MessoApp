using MessoApp.DTO.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Services.IServices
{
    public interface IMemberService
    {
        Task<List<MemberProfileResponse>> GetAllMembersByMessIdAsync(int messId);
    }
}
