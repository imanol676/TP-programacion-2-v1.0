using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
//[Authorize]
[Route("api/vehiculos")]
public class VehiculoController : ControllerBase
{
    private readonly IVehiculoService _vehiculoService;

    public VehiculoController(IVehiculoService vehiculoService)
    {
        _vehiculoService = vehiculoService;
    }

    [HttpGet]
    public ActionResult<List<Vehiculo>> GetAllVehiculos()
    {
        return Ok(_vehiculoService.GetAllVehiculos());
    }

    [HttpGet("{id}/vehiculo")]

    public ActionResult<List<Vehiculo>> GetVehiculoById(int id)
    {
        var a = _vehiculoService.GetVehiculoById(id);
        return Ok(a);

    }
    [Authorize(Roles = "ADMIN")]
    [HttpPost]
    public ActionResult<Vehiculo> CreateVehiculo(VehiculoDTO v)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        Vehiculo _v = _vehiculoService.CreateVehiculo(v);
        return CreatedAtAction(nameof(GetVehiculoById), new { id = _v.Id }, _v);
    }
    [Authorize(Roles = "ADMIN")]
    [HttpDelete("{id}")]
    public ActionResult DeleteVehiculo(int id)
    {
        var v = _vehiculoService.GetVehiculoById(id);

        if (v == null) { return NotFound("Vehiculo no encontrado"); }

        _vehiculoService.DeleteVehiculo(id);
        return NoContent();
    }


    [HttpPut("{id}")]
    public ActionResult<Vehiculo> UpdateVehiculo(int id, VehiculoUpdateDTO updatedVehiculo)
    {
        try
        {
            if (id != updatedVehiculo.Id)
            {
                return BadRequest(new { Message = "El ID del vehículo en la URL no coincide con el ID del vehículo en el cuerpo de la solicitud." });
            }

            Vehiculo vehiculo = _vehiculoService.UpdateVehiculo(id, updatedVehiculo);
            if (vehiculo is null)
            {
                return NotFound(new { Message = $"No se pudo actualizar el vehículo con id: {id}" });
            }

            return Ok(vehiculo); // Puedes usar Ok para un simple 200 en lugar de CreatedAtAction
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return Problem(detail: e.Message, statusCode: 500);
        }
    }


}