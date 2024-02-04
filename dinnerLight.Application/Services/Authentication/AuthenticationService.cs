using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dinnerLight.Application.Common.Interfaces.Authentication;

namespace dinnerLight.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }


        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstName",
                "lastName",
                email,
                "token" );
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {

            // 1:   Check if the user already exists
            // 2:    Create user ( generate new unique Id)
            // 3:   Generate JWT token

            Guid userId = Guid.NewGuid();

            var token = _jwtTokenGenerator.GenerateToken(userId , firstName , lastName);

            return new AuthenticationResult(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                token);
        }
    }
}