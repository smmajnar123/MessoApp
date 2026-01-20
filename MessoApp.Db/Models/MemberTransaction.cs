using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class MemberTransaction
{
    public int MemberTransactionId { get; set; }

    public int MemberId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal Amount { get; set; }

    public string? PaymentMode { get; set; }

    public string? PaymentStatus { get; set; }

    public string? Remarks { get; set; }

    public virtual Member Member { get; set; } = null!;
}
