public interface IVehiculoService
{
    IEnumerable<Vehiculo> GetAllVehiculos();
    Vehiculo? GetVehiculoById(int id);
    Vehiculo CreateVehiculo(VehiculoDTO vehiculo);
    void DeleteVehiculo(int id);
    bool ConsultarDisponibilidad(int id);
    Vehiculo UpdateVehiculo(int id, VehiculoUpdateDTO updatedVehiculo);
}