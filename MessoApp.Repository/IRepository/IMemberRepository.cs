using MessoApp.DTO.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Repository.IRepository
{
    public interface IMemberRepository
    {
        Task<List<MemberProfileResponse>> GetAllMembersByMessIdAsync(int messId);
    }
}
