using System;
using System.Collections.Generic;

namespace MessoApp.Db.Models;

public partial class Mess
{
    public int MessId { get; set; }

    public int AdminId { get; set; }

    public string MessName { get; set; } = null!;

    public string? MessAddress { get; set; }

    public string? MessGender { get; set; }

    public int? MembersCount { get; set; }

    public int? ActiveMemberCount { get; set; }

    public int? InActiveMemberCount { get; set; }

    public bool? IsActive { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual ICollection<Member> Members { get; set; } = [];
}
