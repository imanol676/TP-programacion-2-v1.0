using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

public class ApplicationUser : IdentityUser
{
    [JsonIgnore]
    public List<Reserva>? Reservas { get; set; }
}