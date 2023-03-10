namespace TestNinja.Mocking;
using Microsoft.EntityFrameworkCore;

public class VideoRepository : IVideoRepository
{
    public IEnumerable<Video> GetUnprocessedVideos()
    {
        using (var context = new VideoContext())
        {
            var videos =
                (from video in context.Videos
                 where !video.IsProcessed
                 select video).ToList();
            return videos;
        }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video>? Videos { get; set; }
    }
}