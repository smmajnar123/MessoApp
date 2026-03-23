using MessoApp.Db.Data;
using MessoApp.Db.Models;
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
    public class MemberProfileRepository(MessDbContext context) : IMemberProfileRepository
    {
        private readonly MessDbContext _context = context;

        public async Task<List<MemberProfileResponseModel>> GetAllAsyn(int adminId)
        {
            return await _context.MemberProfiles
                .Where(mp => mp.AdminId == adminId)
                .Select(mp => MemberProfileMapper.ToResponse(mp))
                .ToListAsync();
        }

        public async Task<MemberProfileResponseModel?> GetMemberProfileAsyn(int profileId)
        {
            return await _context.MemberProfiles.Where(mp => mp.ProfileId == profileId).
                Select(mp => MemberProfileMapper.ToResponse(mp)).FirstOrDefaultAsync();
        }


        public async Task<int> AddAsyn(MemberProfileRequestModel model)
        {
            var entity = MemberProfileMapper.ToEntity(model);
            await _context.MemberProfiles.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsyn(int profileId, MemberProfileRequestModel model)
        {
            var entity = await _context.MemberProfiles.FirstOrDefaultAsync(mp => mp.ProfileId == profileId && mp.AdminId == model.AdminId)
            ?? throw new KeyNotFoundException("Member profile not found.");
            MemberProfileMapper.UpdateEntity(entity, model);
            return await _context.SaveChangesAsync();
        }
    }
}
