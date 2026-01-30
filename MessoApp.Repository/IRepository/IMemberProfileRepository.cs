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
        List<MemberProfileResponseModel> GetAll();
        void Add(MemberProfileRequestModel model);
    }
}
