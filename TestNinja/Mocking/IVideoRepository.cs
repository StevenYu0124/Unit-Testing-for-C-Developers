namespace TestNinja.Mocking;

public interface IVideoRepository
{
    IEnumerable<Video> GetUnprocessedVideos();
}