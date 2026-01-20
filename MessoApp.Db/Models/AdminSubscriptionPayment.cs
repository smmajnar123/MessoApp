using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class AdminSubscriptionPayment
{
    public int SubscriptionPaymentId { get; set; }

    public int AdminId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string? SubscriptionPlan { get; set; }

    public int? PlanDurationDays { get; set; }

    public string? PaymentMode { get; set; }

    public string? PaymentStatus { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Remarks { get; set; }

    public virtual Admin Admin { get; set; } = null!;
}
