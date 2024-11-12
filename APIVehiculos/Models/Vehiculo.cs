using System.Text.Json.Serialization;
public class Vehiculo
{
    public int Id { get; set; }  // Clave primaria
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public decimal PrecioPorDia { get; set; }
    public bool EstaDisponible { get; set; }

    // Relación con Reservas (Un Vehiculo puede estar en muchas Reservas)
    [JsonIgnore]
    public  List<Reserva> Reservas { get; set; }


}
