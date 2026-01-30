using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class MemberMessDetail
{
    public int MemberMessDetailId { get; set; }

    public int ProfileId { get; set; }

    public int MessId { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? JoinedDate { get; set; }

    public string? MessType { get; set; }

    public string? MemberCategory { get; set; }

    public decimal? MonthlyPrice { get; set; }

    public int? LeaveDays { get; set; }

    public int? TotalTiffinCount { get; set; }

    public int? RemainingTiffinDays { get; set; }

    public int? ExtraTiffinDays { get; set; }

    public virtual ICollection<MemberTransaction> MemberTransactions { get; set; } = new List<MemberTransaction>();

    public virtual Mess Mess { get; set; } = null!;

    public virtual MemberProfile Profile { get; set; } = null!;
}
