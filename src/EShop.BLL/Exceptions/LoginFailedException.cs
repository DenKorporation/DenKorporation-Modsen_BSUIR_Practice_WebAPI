using System.Net;

namespace EShop.BLL.Exceptions;

public class LoginFailedException(string message = "Invalid login or password", HttpStatusCode code = HttpStatusCode.BadRequest) : Exception(message)
{
    public HttpStatusCode Code { get; } = code;
}