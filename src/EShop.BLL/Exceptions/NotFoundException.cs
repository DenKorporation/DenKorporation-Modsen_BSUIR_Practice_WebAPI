using System.Net;

namespace EShop.BLL.Exceptions;

public class NotFoundException(string message = "Entity not found", HttpStatusCode code = HttpStatusCode.NotFound) : Exception(message)
{
    public HttpStatusCode Code { get; } = code;
}