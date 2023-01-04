#nullable disable
namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private readonly IFileDownloader _fileDownloader;
        public InstallerHelper(
            IFileDownloader fileDownloader
        )
        {
            _fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            var url = string.Format("http://example.com/{0}/{1}",
                customerName,
                installerName);
            var isOk = _fileDownloader.Download(url, _setupDestinationFile);
            return isOk;
        }
    }
}