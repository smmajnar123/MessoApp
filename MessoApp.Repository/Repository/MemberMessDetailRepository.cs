using MessoApp.Db.Data;
using MessoApp.DTO.RequestModels;
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
    public class MemberMessDetailRepository(MessDbContext context) : IMemberMessDetailRepository
    {
        private readonly MessDbContext _context = context;
        public async Task<List<MemberMessDetailResponseModel>> GetAllAsyn(int messId)
        {
            var result = await _context.MemberMessDetails.Where(x => x.MessId == messId)
            .Include(x => x.Profile)
            .Include(x => x.Mess)
            .Select(x => MemberMessDetailMapper.ToResponse(x))
            .ToListAsync();

            return result;
        }
    }
}
