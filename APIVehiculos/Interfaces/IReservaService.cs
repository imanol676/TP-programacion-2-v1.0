public interface IReservaService
{
    IEnumerable<Reserva> GetAllReservas();
    Reserva? GetReservaById(int id);
    Reserva CreateReserva(ReservaDTO reserva);
    Reserva? UpdateReserva(int id, Reserva reserva);
    void DeleteReserva(int id);

    IEnumerable<Reserva> GetReservasByUserId(string userId);
}