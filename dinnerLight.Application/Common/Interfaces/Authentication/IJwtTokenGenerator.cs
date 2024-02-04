using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dinnerLight.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId , string firstName , string lastName);
    }
}