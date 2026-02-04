using MessoApp.Helper.Common.Enums;

namespace MessoApp.DTO.ResponseModels
{
    public class AuthResponseModel
    {
        public bool IsAuthenticated { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; } 
        public string MobileNumber { get; set; } = string.Empty;
    }

}
