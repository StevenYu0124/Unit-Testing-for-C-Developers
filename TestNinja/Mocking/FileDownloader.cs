#nullable disable
#pragma warning disable SYSLIB0014
using System.Net;
namespace TestNinja.Mocking;
public class FileDownloader : IFileDownloader
{
    public bool Download(
        string url,
        string destinationPath)
    {
        try
        {
            var client = new WebClient();
            client.DownloadFile(url, destinationPath);
            return true;
        }
        catch (WebException)
        {
            return false;
        }
    }
}