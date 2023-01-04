namespace TestNinja.Mocking;

public interface IBookingRepository
{
    IQueryable<Booking> GetQueryableBookingsExceptId(int id);
}