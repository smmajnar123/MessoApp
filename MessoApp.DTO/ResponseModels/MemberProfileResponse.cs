using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.DTO.ResponseModels
{
    public class MemberProfileResponse
    {
        public int MemberId { get; set; }
        public int MessId { get; set; }
        public string MemberName { get; set; } = null!;
        public string? MessType { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? Dob { get; set; }  
        public MessResponse Mess { get; set; } = null!;
    }
}
