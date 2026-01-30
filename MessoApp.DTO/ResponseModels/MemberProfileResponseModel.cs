using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.DTO.ResponseModels
{
    public class MemberProfileResponseModel
    {
        public int ProfileId { get; set; }
        public string? MemberName { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public DateOnly? Dob { get; set; }
        public int AdminId { get; set; }
    }
}
