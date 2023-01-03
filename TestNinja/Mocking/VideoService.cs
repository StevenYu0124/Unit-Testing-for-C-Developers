#nullable disable

using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IFileReader _fileReader;
        public VideoService(
            IVideoRepository videoRepository,
            IFileReader fileReader)
        {
            _videoRepository = videoRepository;
            _fileReader = fileReader;
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.ReadAllText("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            
            var videos = _videoRepository.GetUnprocessedVideos();
                
            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }
}