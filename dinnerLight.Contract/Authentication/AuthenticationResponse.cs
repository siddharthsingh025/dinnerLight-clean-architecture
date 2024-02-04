
namespace dinnerLight.Contract.Authentication;

public record AuthenticationResponse(
    Guid id,
string FirstName,
string LastName,
string Email,
string Token );

