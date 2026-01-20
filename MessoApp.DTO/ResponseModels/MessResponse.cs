using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.DTO.ResponseModels
{
    public class MessResponse
    {
        public int MessId { get; set; }
        public string MessName { get; set; } = null!;
        public string? MessAddress { get; set; }
        public int? MembersCount { get; set; }
        public int? ActiveMemberCount { get; set; }
        public int? InActiveMemberCount { get; set; }
    }
}
