using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public DateOnly? Dob { get; set; }

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<AdminSubscriptionDetail> AdminSubscriptionDetails { get; set; } = new List<AdminSubscriptionDetail>();

    public virtual ICollection<MemberProfile> MemberProfiles { get; set; } = new List<MemberProfile>();

    public virtual ICollection<Mess> Messes { get; set; } = new List<Mess>();
}
