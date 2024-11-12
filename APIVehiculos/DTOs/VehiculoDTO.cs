using System.ComponentModel.DataAnnotations;
public class VehiculoDTO
{
    [Required(ErrorMessage = "El campo Modelo es requerido.")]
    public required string Modelo { get; set; }

    [Required(ErrorMessage = "El campo Marca es requerido.")]
    public required string Marca { get; set; }

    [Required(ErrorMessage = "El campo es requerido.")]
    public decimal PrecioPorDia { get; set; }

    [Required(ErrorMessage = "El campo es requerido.")]
    public required bool EstaDisponible { get; set; }

}