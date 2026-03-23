using MessoApp.Db.Data;
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
    public class MemberMessDetailRepository(MessDbContext context) : IMemberMessDetailRepository
    {
        private readonly MessDbContext _context = context;
        //public async Task<MemberMessDetailResponseModel?> GetMemberMessDetailsAsync(int profileId)
        //{
        //    return await _context.MemberMessDetails.AsNoTracking().Where(x => x.ProfileId == profileId)
        //    .Select(x => MemberMessDetailMapper.ToResponse(x))
        //    .FirstOrDefaultAsync(); ;
        //}
        public async Task<MemberMessDetailResponseModel?> GetMemberMessDetailsAsync(int profileId)
        {
            return await _context.MemberMessDetails
                .AsNoTracking()
                .Where(m => m.ProfileId == profileId)
                .Select(m=>MemberMessDetailMapper.ToResponse(m))
                .FirstOrDefaultAsync();   // TOP(1)
        }
    }
}
