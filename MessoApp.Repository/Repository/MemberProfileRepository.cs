using MessoApp.Db.Data;
using MessoApp.Db.Models;
using MessoApp.DTO.RequestModels;
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
    public class MemberProfileRepository(MessDbContext context) : IMemberProfileRepository
    {
        private readonly MessDbContext _context = context;

        public async Task<List<MemberProfileResponseModel>> GetAll(int adminId)
        {
            return await _context.MemberProfiles
                .Where(mp => mp.AdminId == adminId)   // ✅ FILTER
                .Select(mp => new MemberProfileResponseModel
                {
                    ProfileId = mp.ProfileId,
                    MemberName = mp.MemberName,
                    MobileNumber = mp.MobileNumber,
                    EmailId = mp.EmailId,
                    Gender = mp.Gender,
                    Address = mp.Address,
                    Dob = mp.Dob
                })
                .ToListAsync();
        }


        public async Task<int> Add(MemberProfileRequestModel model)
        {
            var entity = new MemberProfile
            {
                MemberName = model.MemberName,
                MobileNumber = model.MobileNumber,
                EmailId = model.EmailId,
                Gender = model.Gender,
                Address = model.Address,
                Dob = model.Dob,
                AdminId = model.AdminId
            };

            await _context.MemberProfiles.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

    }
}
