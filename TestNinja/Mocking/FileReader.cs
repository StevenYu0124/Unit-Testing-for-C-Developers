namespace TestNinja.Mocking;

public class FileReader : IFileReader
{
    public string ReadAllText(string path)
    {
        string text = File.ReadAllText("video.txt");
        return text;
    }
}