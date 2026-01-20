using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public int MessId { get; set; }

    public string MemberName { get; set; } = null!;

    public string? MobileNumber { get; set; }

    public string? EmailId { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? JoinedDate { get; set; }

    public string? MessType { get; set; }

    public string? MemberCategory { get; set; }

    public decimal? MonthlyPrice { get; set; }

    public int? LeaveDays { get; set; }

    public int? TotalTiffinCount { get; set; }

    public int? RemainingLunchDays { get; set; }

    public int? ExtraLunchDays { get; set; }

    public DateOnly? Dob { get; set; }

    public virtual ICollection<MemberTransaction> MemberTransactions { get; set; } = [];

    public virtual Mess Mess { get; set; } = null!;
}
