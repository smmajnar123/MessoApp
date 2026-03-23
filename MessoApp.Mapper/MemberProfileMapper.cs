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
            return new MemberProfile
            {
                MemberName = model.MemberName,
                MobileNumber = model.MobileNumber,
                EmailId = model.EmailId,
                Gender = model.Gender,
                Address = model.Address,
                Dob = model.Dob,
                AdminId = model.AdminId
            };
        }

        // Map Entity -> ResponseModel
        public static MemberProfileResponseModel ToResponse(MemberProfile entity)
        {
            if (entity == null) return new MemberProfileResponseModel();

            return new MemberProfileResponseModel
            {
                ProfileId = entity.ProfileId,
                MemberName = entity.MemberName,
                MobileNumber = entity.MobileNumber,
                EmailId = entity.EmailId,
                Gender = entity.Gender,
                Address = entity.Address,
                Dob = entity.Dob,
            };
        }

        public static void UpdateEntity(MemberProfile entity, MemberProfileRequestModel model)
        {
            entity.MemberName = model.MemberName.Trim();
            entity.MobileNumber = model.MobileNumber.Trim();
            entity.EmailId = model.EmailId.Trim();
            entity.Gender = model.Gender;
            entity.Address = model.Address?.Trim();
            entity.Dob = model.Dob;
        }

    }
}
