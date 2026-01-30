using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class AdminSubscriptionDetail
{
    public int SubscriptionPaymentId { get; set; }

    public int AdminId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string SubscriptionPlan { get; set; } = null!;

    public int PlanDurationDays { get; set; }

    public string PaymentMode { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? Remarks { get; set; }

    public virtual Admin Admin { get; set; } = null!;
}
