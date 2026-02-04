using MessoApp.Db.Models;
using MessoApp.DTO.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Mapper
{
    public static class MemberMessDetailMapper
    {
        public static MemberMessDetailResponseModel ToResponse(MemberMessDetail entity)
        {
            return new MemberMessDetailResponseModel
            {
                MemberMessDetailId = entity.MemberMessDetailId,
                ProfileId = entity.ProfileId,
                MemberName = entity.Profile.MemberName,
                MessId = entity.MessId,
                MessName = entity.Mess.MessName,
                IsActive = entity.IsActive,
                JoinedDate = entity.JoinedDate,
                MessType = entity.MessType,
                MemberCategory = entity.MemberCategory,
                MonthlyPrice = entity.MonthlyPrice,
                LeaveDays = entity.LeaveDays,
                TotalTiffinCount = entity.TotalTiffinCount,
                RemainingTiffinDays = entity.RemainingTiffinDays,
                ExtraTiffinDays = entity.ExtraTiffinDays
            };
        }
    }

}
