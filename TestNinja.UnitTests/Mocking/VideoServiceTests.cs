#nullable disable
namespace TestNinja.UnitTests.Mocking;

public class VideoServiceTests
{
    private VideoService _videoService;
    private Mock<IVideoRepository> _videoRepository;
    private Mock<IFileReader> _fileReader;

    [SetUp]
    public void SetUp()
    {
        _videoRepository = new Mock<IVideoRepository>();
        _fileReader = new Mock<IFileReader>();
        _videoService = new VideoService(
            _videoRepository.Object,
            _fileReader.Object
        );
    }

    [Test]
    public void ReadVideoTitle_WhenFileIsEmpty_ReturnErrorMessage()
    {
        // arrange
        _fileReader.Setup(x => x.ReadAllText("video.txt")).Returns("");

        // act
        var actual = _videoService.ReadVideoTitle();

        // assert
        Assert.That(actual, Is.EqualTo("Error parsing the video."));
    }

    [Test]
    public void ReadVideoTitle_WhenFileIsValid_ReturnVideoTitle()
    {
        // arrange
        _fileReader.Setup(x => x.ReadAllText("video.txt")).Returns(
        @"{
            ""id"": 1,
            ""title"" : ""test"",
            ""isProcessed"": false
        }");

        // act
        var actual = _videoService.ReadVideoTitle();

        // assert
        Assert.That(actual, Is.EqualTo("test"));
    }

    [Test]
    public void GetUnprocessedVideosAsCsv_NotAllVideoAreProcessed_ReturnIdsAsCsv()
    {
        // arrange
        _videoRepository
            .Setup(x => x.GetUnprocessedVideos())
            .Returns(new List<Video>(){
                new Video(){
                    Id = 1,
                    Title = "test 1",
                    IsProcessed = false
                },
                new Video(){
                    Id = 3,
                    Title = "test 3",
                    IsProcessed = false
                }
            });

        // act
        var actual = _videoService.GetUnprocessedVideosAsCsv();

        // assert
        Assert.That(actual, Is.EqualTo("1,3"));
    }

    [Test]
    public void GetUnprocessedVideosAsCsv_AllVideoAreProcessed_ReturnEmptyString()
    {
        // arrange
        _videoRepository
            .Setup(x => x.GetUnprocessedVideos())
            .Returns(new List<Video>());

        // act
        var actual = _videoService.GetUnprocessedVideosAsCsv();

        // assert
        Assert.That(actual, Is.EqualTo(string.Empty));
    }
}