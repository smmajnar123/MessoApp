using MessoApp.Db.Data;
using MessoApp.Db.Models;
using MessoApp.DTO.RequestModels;
using MessoApp.DTO.ResponseModels;
using MessoApp.Repository.IRepository;
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

        public List<MemberProfileResponseModel> GetAll()
        {
            return [.. _context.MemberProfiles
                .Select(mp => new MemberProfileResponseModel
                {
                    ProfileId = mp.ProfileId,
                    MemberName = mp.MemberName,
                    MobileNumber = mp.MobileNumber,
                    EmailId = mp.EmailId,
                    Gender = mp.Gender,
                    Address = mp.Address,
                    Dob = mp.Dob,
                    AdminId = mp.AdminId
                })];
        }

        public void Add(MemberProfileRequestModel model)
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

            _context.MemberProfiles.Add(entity);
            _context.SaveChanges();
        }

    }
}
