using Azure;
using MessoApp.Db.Data;
using MessoApp.DTO.RequestModels;
using MessoApp.DTO.ResponseModels;
using MessoApp.Mapper;
using MessoApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Repository.Repository
{
    public class MessRepository(MessDbContext context) : IMessRepository
    {
        private readonly MessDbContext _context = context;

        public Task<int> AddAsyn(MessRequestModel model)
        {
            var entity = MessMapper.ToEntity(model);
            _context.Messes.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<MessResponse>> GetAllAsyn(int adminId)
        {
            return await _context.Messes
                .Where(m => m.Admin.AdminId == adminId)
                .Select(m => MessMapper.ToResponse(m))
                .ToListAsync();
        }

        public async Task<int> UpdateAsyn(int messId, MessRequestModel model)
        {
            var entity = await _context.Messes.FirstOrDefaultAsync(m => m.MessId == messId && m.AdminId == model.AdminId)
                ?? throw new KeyNotFoundException("Mess not found.");
            MessMapper.UpdateEntity(entity, model);
            return await _context.SaveChangesAsync();
        }
    }
}
