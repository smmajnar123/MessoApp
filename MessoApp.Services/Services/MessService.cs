using MessoApp.DTO.ResponseModels;
using MessoApp.Repository.IRepository;
using MessoApp.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Services.Services
{
    public class MessService(IMessRepository messRepository) : IMessService
    {
        private readonly IMessRepository _messRepository = messRepository;

        public async Task<List<MessResponse>> GetAllMessByAdminIdAsync(int adminId)
        {
            return await _messRepository.GetAllMessByAdminIdAsync(adminId);
        }
    }
}
