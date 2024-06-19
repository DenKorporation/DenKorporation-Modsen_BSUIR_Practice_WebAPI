using System.Text.Json.Serialization;

namespace EShop.DAL.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
    Submitted,
    AwaitingValidation,
    StockConfirmed,
    Paid,
    Shipped,
    Cancelled
}