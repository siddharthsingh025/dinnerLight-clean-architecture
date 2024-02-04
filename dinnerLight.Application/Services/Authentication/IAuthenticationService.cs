using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dinnerLight.Application.Services.Authentication;
    public interface IAuthenticationService
    {
        AuthenticationResult  Login(string email, string password);
        AuthenticationResult  Register(string firstName , string fastName ,string email , string password);
    }
