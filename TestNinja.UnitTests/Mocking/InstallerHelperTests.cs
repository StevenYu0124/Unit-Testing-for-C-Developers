#nullable disable
namespace TestNinja.UnitTests.Mocking;
public class InstallerHelperTests
{
    private InstallerHelper _installerHelper;
    private Mock<IFileDownloader> _fileDownloader;

    [SetUp]
    public void SetUp()
    {
        _fileDownloader = new Mock<IFileDownloader>();
        _installerHelper = new InstallerHelper(_fileDownloader.Object);
    }

    [Test]
    public void DownloadInstaller_WhenNoException_ReturnTrue()
    {
        // arrange
        _fileDownloader
            .Setup(x => x.Download(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        // act
        var actual = _installerHelper.DownloadInstaller(
            "test customer", 
            "test installer");
        
        // assert
        Assert.That(actual, Is.True);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void DownloadInstaller_WhenWebExceptionIsThrew_ReturnFalse(bool isDownloadOk)
    {
        // arrange
        _fileDownloader
            .Setup(x => x.Download(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(isDownloadOk);

        // act
        var actual = _installerHelper.DownloadInstaller(
            "test customer", 
            "test installer");
        
        // assert
        Assert.That(actual, Is.EqualTo(isDownloadOk));
    }
}