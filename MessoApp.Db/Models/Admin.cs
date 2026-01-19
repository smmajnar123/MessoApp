using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string? MobileNumber { get; set; }

    public string? EmailId { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public int? TotalMemberCount { get; set; }

    public int? TotalActiveMemberCount { get; set; }

    public int? TotalInActiveMemberCount { get; set; }

    public string? Subscription { get; set; }

    public decimal? SubscriptionPrice { get; set; }

    public DateOnly? SubscriptionStartDate { get; set; }

    public int? SubscriptionRemainingDays { get; set; }

    public virtual ICollection<AdminSubscriptionPayment> AdminSubscriptionPayments { get; set; } = new List<AdminSubscriptionPayment>();

    public virtual ICollection<Mess> Messes { get; set; } = new List<Mess>();
}
