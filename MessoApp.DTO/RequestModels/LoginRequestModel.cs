using MessoApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.DTO.RequestModels
{
    public class LoginRequestModel
    {
        public string MobileNumber { get; set; } = null!;
        public string Password { get; set; } = null!;

        public Role Role { get; set; }
    }
}
