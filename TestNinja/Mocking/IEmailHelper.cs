namespace TestNinja.Mocking;

public interface IEmailHelper
{
    void Email(string emailAddress, string emailBody, string filename, string subject);
}