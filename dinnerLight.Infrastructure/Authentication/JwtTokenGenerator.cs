using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dinnerLight.Application.Common.Interfaces.Authentication;
using dinnerLight.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace dinnerLight.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{

    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;  //DI constructor Injection
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
        SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub , userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName , firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName,lastName),
            new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
        };

        var SecurityToken = new JwtSecurityToken(
            issuer :_jwtSettings.Issuer,
            audience : _jwtSettings.Audience,
            expires : _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims:claims,
            signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(SecurityToken);
    }
}

//what is JWT ?
//how Authentication work with JWT
//what are 
        //1. claims
        //2. signingCredential
        //3. securityToken



/*
JWT stands for JSON Web Token. It is a compact, URL-safe means of representing claims to be transferred between two parties. JWTs are used for authentication and authorization in web applications and APIs. They are commonly used in scenarios where a client needs to securely transmit information between a server and a client as a JSON object.

********************************************************************************

# Authentication with JWT typically works as follows:

********************************************************************************
1. User Authentication: When a user logs in to a system, the server verifies the user's credentials (e.g., username and password). If the credentials are valid, the server creates a JWT containing the user's information (claims) and signs it using a secret key known only to the server.

2. JWT Generation: The server sends the JWT back to the client, who stores it securely (e.g., in local storage or a cookie). The JWT is usually included in subsequent requests to the server as an Authorization header.

3. JWT Verification: When the client makes a request to a protected resource on the server, it includes the JWT in the Authorization header of the request. The server verifies the JWT's signature using the secret key. If the signature is valid and the JWT has not expired, the server considers the request authenticated and processes it.

********************************************************************************

# Claims:                 
 Claims are pieces of information asserted about a subject. For example, a JWT may contain claims such as the user's ID, username, roles, or any other relevant information. These claims are encoded into the JWT and can be used by the server to make authorization decisions.

# Signing Credential:       
The signing credential is the secret key used to sign the JWT. This key is known only to the server and is used to verify the authenticity of the JWT. Without the correct signing credential, the JWT cannot be verified and should not be trusted.

# Security Token:          
 A security token is a generic term used to refer to any token used for security purposes, including JWTs. In the context of JWT, the security token refers to the JWT itself, which contains the claims and is used for authentication and authorization. 

*/        