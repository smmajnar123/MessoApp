using MessoApp.DTO.RequestModels;
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

        public async Task<List<MessResponse>> GetAllAsyn(int adminId)
        {
            return await _messRepository.GetAllAsyn(adminId);
        }

        public async Task<int> AddAsyn(MessRequestModel model)
        {
            return await _messRepository.AddAsyn(model);
        }

        public Task<int> UpdateAsyn(int messId, MessRequestModel model)
        {
            return _messRepository.UpdateAsyn(messId, model);
        }
    }
}
