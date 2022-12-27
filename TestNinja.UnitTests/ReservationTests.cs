namespace TestNinja.UnitTests;

public class ReservationTests
{
    [Test]
    public void CanBeCancelledBy_UserIsAdmin_RetureTrue()
    {
        // arrange
        var reservation = new Reservation()
        {
            MadeBy = new User()
        };
        var user = new User()
        {
            IsAdmin = true
        };
        var expected = true;

        // act
        var actual = reservation.CanBeCancelledBy(user);

        // assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CanBeCancelledBy_UserIsNotAdmin_RetureFalse()
    {
        // arrange
        var reservation = new Reservation()
        {
            MadeBy = new User()
        };
        var user = new User()
        {
            IsAdmin = false
        };
        var expected = false;

        // act
        var actual = reservation.CanBeCancelledBy(user);

        // assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CanBeCancelledBy_MadeBySameUser_RetureTrue()
    {
        // arrange
        var user = new User()
        {
            IsAdmin = false
        };
        var reservation = new Reservation()
        {
            MadeBy = user
        };
        var expected = true;

        // act
        var actual = reservation.CanBeCancelledBy(user);

        // assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}