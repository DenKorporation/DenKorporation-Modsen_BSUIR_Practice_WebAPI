using System.Net;
using Microsoft.AspNetCore.Identity;

namespace EShop.BLL.Exceptions;

public class RegistrationFailedException(string message = "Registration Failed", HttpStatusCode code = HttpStatusCode.BadRequest, IEnumerable<IdentityError>? errors = null) : Exception(message)
{
    public HttpStatusCode Code { get; } = code;
    public IEnumerable<IdentityError>? Errors;
}