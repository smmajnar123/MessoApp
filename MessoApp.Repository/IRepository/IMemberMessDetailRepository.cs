using MessoApp.DTO.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Repository.IRepository
{
    public interface IMemberMessDetailRepository
    {
        Task<List<MemberMessDetailResponseModel>> GetAllAsyn(int messId);
    }
}
