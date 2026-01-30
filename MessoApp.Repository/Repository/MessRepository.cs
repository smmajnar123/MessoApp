using MessoApp.Db.Data;
using MessoApp.DTO.ResponseModels;
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

        public async Task<List<MessResponse>> GetAllMessByAdminIdAsync(int adminId)
        {
            return await _context.Messes
                .Where(m => m.Admin.AdminId == adminId)
                .Select(m => new MessResponse
                {
                    MessId = m.MessId,
                    MessName = m.MessName,
                    MessAddress = m.MessAddress,
                })
                .ToListAsync();
        }
    }
}
