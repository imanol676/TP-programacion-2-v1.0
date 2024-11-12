using Microsoft.EntityFrameworkCore;
public class VehiculoDbService : IVehiculoService
{
    private readonly ApplicationDbContext _context;
    public VehiculoDbService(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool ConsultarDisponibilidad(int id)
    {
        throw new NotImplementedException();
    }

    public Vehiculo CreateVehiculo(VehiculoDTO v)
    {
        var nuevoVehiculo = new Vehiculo
        {
            Modelo = v.Modelo,
            Marca = v.Marca,
            PrecioPorDia = (decimal)v.PrecioPorDia,
            EstaDisponible = v.EstaDisponible,
            Reservas = new List<Reserva>()
        };
        _context.Vehiculos.Add(nuevoVehiculo);
        _context.SaveChanges();
        return nuevoVehiculo;
    }

    public void DeleteVehiculo(int id)
    {
        var v = _context.Vehiculos.Find(id);
        if (v != null)
        {
            _context.Vehiculos.Remove(v);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Vehiculo> GetAllVehiculos()
    {
        return _context.Vehiculos;
    }

    public Vehiculo? GetVehiculoById(int id)
    {
        return _context.Vehiculos.Find(id);
    }

    public Vehiculo? UpdateVehiculo(int id, VehiculoUpdateDTO vehiculoDto)
    {
        var vehiculoExistente = _context.Vehiculos.Find(id);

        if (vehiculoExistente == null)
        {
            return null;
        }
        vehiculoExistente.Marca = vehiculoDto.Marca;
        vehiculoExistente.Modelo = vehiculoDto.Modelo;
        vehiculoExistente.PrecioPorDia = vehiculoDto.PrecioPorDia;
        vehiculoExistente.EstaDisponible = vehiculoDto.EstaDisponible;

        _context.Entry(vehiculoExistente).State = EntityState.Modified;
        _context.SaveChanges();
        return vehiculoExistente;
    }
}
