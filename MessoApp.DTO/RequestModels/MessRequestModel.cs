using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.DTO.RequestModels
{
    public class MessRequestModel
    {
        public int AdminId { get; set; }
        public string MessName { get; set; } = null!;
        public string? MessAddress { get; set; }
        public string? MessMobile { get; set; }
        public string? MessEmail { get; set; }
        public bool IsActive { get; set; }
    }
}
