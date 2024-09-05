namespace Parallelism;

public class SpaceCounter
{
    private int _spaceCount;
    
    public int SpaceCount => _spaceCount;

    public SpaceCounter(string folderPath)
        : this(new DirectoryInfo(folderPath)){}

    public SpaceCounter(DirectoryInfo directory)
    {
        var tasks = new List<Task>();
        
        foreach (var file in directory.GetFiles())
        {
            if(file.Extension == ".txt")
                tasks.Add(SpaceCountInTextFile(file.FullName));
        }
        
        Task.WaitAll(tasks.ToArray());
    }

    private async Task SpaceCountInTextFile(string fileName)
    {
        try
        {
            using var reader = new StreamReader(fileName);
            while (await reader.ReadLineAsync() is { } line)
            {
                Interlocked.Add(ref _spaceCount, line.Count(c => c == ' '));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}