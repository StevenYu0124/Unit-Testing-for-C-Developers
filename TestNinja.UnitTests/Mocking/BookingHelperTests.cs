namespace TestNinja.UnitTests.Mocking;
#nullable disable

public class BookingHelperTests
{
    private Mock<IBookingRepository> _bookingRepository;
    private List<Booking> _bookings;
    [SetUp]
    public void SetUp()
    {
        _bookings = new List<Booking> {
            new Booking
            {
                ArrivalDate = DateTime.Parse("2023-01-05"),
                DepartureDate = DateTime.Parse("2023-01-07"),
                Reference = "test reference"
            }
        };
        _bookingRepository = new Mock<IBookingRepository>();
        _bookingRepository
            .Setup(x => x.GetQueryableBookingsExceptId(It.IsAny<int>()))
            .Returns(_bookings.AsQueryable());
    }


    [TestCase("2023-01-01", "2023-01-05")]
    [TestCase("2023-01-07", "2023-01-09")]
    public void OverlappingBookingsExist_NotOverlap_ReturnEmptyString(
        string targetArrivalDateString, string targetDepartureDateString
    )
    {
        // arrange
        var booking = new Booking
        {
            ArrivalDate = DateTime.Parse(targetArrivalDateString),
            DepartureDate = DateTime.Parse(targetDepartureDateString)
        };

        // act
        var actual = BookingHelper.OverlappingBookingsExist(
            booking,
            _bookingRepository.Object);

        // assert
        Assert.That(actual, Is.Empty);
    }

    [TestCase("2023-01-01", "2023-01-06")]
    [TestCase("2023-01-06", "2023-01-09")]
    [TestCase("2023-01-04", "2023-01-08")]
    [TestCase("2023-01-06", "2023-01-06")]
    public void OverlappingBookingsExist_Overlap_ReturnBookingReference(
        string targetArrivalDateString, string targetDepartureDateString
    )
    {
        // arrange
        var booking = new Booking
        {
            ArrivalDate = DateTime.Parse(targetArrivalDateString),
            DepartureDate = DateTime.Parse(targetDepartureDateString)
        };

        // act
        var actual = BookingHelper.OverlappingBookingsExist(
            booking,
            _bookingRepository.Object);

        // assert
        Assert.That(actual, Is.EqualTo(_bookings.First().Reference));
    }

    [Test]
    public void OverlappingBookingsExist_WhenBookingIsCancelled_ReturnEmptyString()
    {
        // arrange
        var bookingRepository = new Mock<IBookingRepository>();
        var booking = new Booking()
        {
            Status = "Cancelled",
            ArrivalDate = _bookings.First().ArrivalDate,
            DepartureDate = _bookings.First().DepartureDate
        };

        // act
        var actual = BookingHelper.OverlappingBookingsExist(
            booking,
            bookingRepository.Object);

        // assert
        Assert.That(actual, Is.Empty);
    }
}