using Azure.Core;
using MessoApp.DTO.RequestModels;
using MessoApp.DTO.ResponseModels;
using MessoApp.Helper.Helpers;
using MessoApp.Repository.IRepository;
using MessoApp.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Services.Services
{
    public class AuthService(IAuthRepository authRepository, IJwtService jwtService) : IAuthService
    {
        private readonly IAuthRepository _authRepository = authRepository;
        private readonly IJwtService _jwtService = jwtService;
        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel)
        {
            var hash = PasswordHelper.Hash(loginRequestModel.Password);
            var result = await _authRepository.AuthenticateAsync(loginRequestModel.MobileNumber, hash, loginRequestModel.Role);

            if (!result.IsAuthenticated)
                throw new UnauthorizedAccessException("Invalid credentials");

            return _jwtService.LoginToken(result.UserId, result.MobileNumber, result.Role);
        }
    }
}
