using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class MemberProfile
{
    public int ProfileId { get; set; }

    public string MemberName { get; set; } = null!;

    public string? MobileNumber { get; set; }

    public string? EmailId { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public DateOnly? Dob { get; set; }

    public int AdminId { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual ICollection<MemberMessDetail> MemberMessDetails { get; set; } = new List<MemberMessDetail>();
}
