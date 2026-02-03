using MessoApp.Db.Models;
using MessoApp.DTO.RequestModels;
using MessoApp.DTO.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Mapper
{
    public static class MemberProfileMapper
    {
        // Map RequestModel -> Entity
        public static MemberProfile ToEntity(MemberProfileRequestModel model)
        {
            if (model == null) return null;

            return new MemberProfile
            {
                MemberName = model.MemberName,
                MobileNumber = model.MobileNumber,
                EmailId = model.EmailId,
                Gender = model.Gender,
                AddAsynress = model.AddAsynress,
                Dob = model.Dob,
                AdminId = model.AdminId
            };
        }

        // Map Entity -> ResponseModel
        public static MemberProfileResponseModel ToResponse(MemberProfile entity)
        {
            if (entity == null) return null;

            return new MemberProfileResponseModel
            {
                ProfileId = entity.ProfileId,
                MemberName = entity.MemberName,
                MobileNumber = entity.MobileNumber,
                EmailId = entity.EmailId,
                Gender = entity.Gender,
                AddAsynress = entity.AddAsynress,
                Dob = entity.Dob,
            };
        }
    }
}
