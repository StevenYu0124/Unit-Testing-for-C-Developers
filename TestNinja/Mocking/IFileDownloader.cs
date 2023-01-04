namespace TestNinja.Mocking;

public interface IFileDownloader
{
    bool Download(string url, string destinationPath);
}