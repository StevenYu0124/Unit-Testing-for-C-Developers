namespace TestNinja.Mocking;

public class BookingRepository : IBookingRepository
{
    public IQueryable<Booking> GetQueryableBookingsExceptId(int id)
    {
        var unitOfWork = new UnitOfWork();
        var bookings = unitOfWork.Query<Booking>();
        bookings = bookings.Where(b => b.Id != id);
        bookings = bookings.Where(b => b.Status != "Cancelled");
        return bookings;
    }
}