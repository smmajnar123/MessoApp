using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.DTO.RequestModels
{
    public class MemberProfileRequestModel
    {
        public string MemberName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly? Dob { get; set; }
        public int AdminId { get; set; }    
    }
}
