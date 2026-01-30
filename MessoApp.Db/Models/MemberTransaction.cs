using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class MemberTransaction
{
    public int MemberTransactionId { get; set; }

    public int MemberMessDetailId { get; set; }

    public int MessId { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentMode { get; set; }

    public string? PaymentStatus { get; set; }

    public string? Remarks { get; set; }

    public decimal? TotalPaidAmount { get; set; }

    public decimal? RemainingAmount { get; set; }

    public virtual MemberMessDetail MemberMessDetail { get; set; } = null!;

    public virtual Mess Mess { get; set; } = null!;
}
