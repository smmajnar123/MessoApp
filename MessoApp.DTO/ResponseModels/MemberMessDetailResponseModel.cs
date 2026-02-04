using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.DTO.ResponseModels
{
    public class MemberMessDetailResponseModel
    {
        public int MemberMessDetailId { get; set; }

        public int ProfileId { get; set; }
        public string MemberName { get; set; } = null!;

        public int MessId { get; set; }
        public string MessName { get; set; } = null!;

        public bool IsActive { get; set; }
        public DateOnly? JoinedDate { get; set; }

        public string? MessType { get; set; }
        public string? MemberCategory { get; set; }

        public decimal? MonthlyPrice { get; set; }

        public int? LeaveDays { get; set; }
        public int? TotalTiffinCount { get; set; }
        public int? RemainingTiffinDays { get; set; }
        public int? ExtraTiffinDays { get; set; }

    }
}
