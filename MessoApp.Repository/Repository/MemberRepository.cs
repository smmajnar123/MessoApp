using MessoApp.Db.Data;
using MessoApp.DTO.ResponseModels;
using MessoApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MessoApp.Repositories
{
    public class MemberRepository(MessDbContext context) : IMemberRepository
    {
        private readonly MessDbContext _context = context;

        public async Task<List<MemberProfileResponse>> GetAllMembersByMessIdAsync(int messId)
        {
            return await _context.Members
               .AsNoTracking()
               .Where(m => m.MessId == messId)
               .Select(m => new MemberProfileResponse
               {
                   MemberId = m.MemberId,
                   MessId = m.MessId,
                   MemberName = m.MemberName,
                   MobileNumber = m.MobileNumber,
                   EmailId = m.EmailId,
                   Address = m.Address,
                   Gender = m.Gender,
                   JoinedDate = m.JoinedDate,
                   MessType = m.MessType,
                   Mess = new MessResponse
                   {
                       MessId = m.Mess.MessId,
                       MessName = m.Mess.MessName,
                       MessAddress = m.Mess.MessAddress,
                       MembersCount = m.Mess.MembersCount,
                       ActiveMemberCount = m.Mess.ActiveMemberCount,
                       InActiveMemberCount = m.Mess.InActiveMemberCount
                   }
               })
               .ToListAsync();
        }
    }
}
