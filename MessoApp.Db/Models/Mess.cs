using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class Mess
{
    public int MessId { get; set; }

    public int AdminId { get; set; }

    public string MessName { get; set; } = null!;

    public string? MessAddress { get; set; }

    public string? MessMobile { get; set; }

    public string? MessEmail { get; set; }

    public bool? IsActive { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual ICollection<MemberMessDetail> MemberMessDetails { get; set; } = new List<MemberMessDetail>();

    public virtual ICollection<MemberTransaction> MemberTransactions { get; set; } = new List<MemberTransaction>();
}
