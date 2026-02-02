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
        public string MessName { get; set; } = string.Empty;
        public string? MessAddress { get; set; }
        public string? MessMobile { get; set; }
        public string? MessEmail { get; set; }
        public bool IsActive { get; set; }
    }
}
