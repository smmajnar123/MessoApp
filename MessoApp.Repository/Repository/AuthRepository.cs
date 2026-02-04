using MessoApp.Db.Data;
using MessoApp.Db.Models;
using MessoApp.DTO.ResponseModels;
using MessoApp.Helper.Common.Enums;
using MessoApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MessoApp.Repository.Repository
{
    public class AuthRepository(MessDbContext context) : IAuthRepository
    {
        private readonly MessDbContext _context = context;

        public async Task<AuthResponseModel> AuthenticateAsync(string mobile, string passwordHash, Role role)
        {
            if (role == Role.Admin)
            {
                var admin = await _context.Admins.FirstOrDefaultAsync(a => a.MobileNumber == mobile && a.PasswordHash == passwordHash);

                if (admin != null)
                {
                    return new AuthResponseModel
                    {
                        IsAuthenticated = true,
                        UserId = admin.AdminId,
                        Role = Role.Admin,
                        MobileNumber = mobile,
                    };
                }
            }
            else
            {
                var member = await _context.MemberProfiles.FirstOrDefaultAsync(a => a.MobileNumber == mobile && a.PasswordHash == passwordHash);
                if (member != null)
                {
                    return new AuthResponseModel
                    {
                        IsAuthenticated = true,
                        UserId = member.ProfileId,
                        Role = Role.Member,
                        MobileNumber = mobile,
                    };
                }
            }
            return new AuthResponseModel
            {
                IsAuthenticated = false,
                UserId = 0,
                Role = Role.None,
                MobileNumber = mobile
            };
        }

    }
}
