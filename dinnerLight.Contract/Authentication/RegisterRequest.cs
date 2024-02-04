using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dinnerLight.Contract.Authentication;
    public record RegisterRequest
    (string FirstName,
string LastName,
string Email,
string Password );
