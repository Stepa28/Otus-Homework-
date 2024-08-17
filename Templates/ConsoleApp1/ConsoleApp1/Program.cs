// See https://aka.ms/new-console-template for more information

List<Nummber> list = [new(0), new(2), new(40), new(60), new(-4), new(4), new(19)];
Console.WriteLine($"Максимальное число в массиве = {list.GetMax(x => x.Int)}");

FileExplorer explorer = new FileExplorer();
explorer.FileFound += (sender, filePath) =>
{
    Console.WriteLine($"Found file: {filePath.FileName}");
    // Проверка условия для отмены поиска
    if (filePath.FileName.Contains("!") && sender is FileExplorer fileExplorer )
    {
        fileExplorer.SearchCancelled = true;
    }
};

explorer.ExploreDirectory(@"c:\ftp\");

#region Пункт 1

record Nummber(int Int);

public static class ExtensionIEnumerable
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        T res = null!;
        var max = float.MinValue;
        foreach (var item in collection)
        {
            var number = convertToNumber.Invoke(item);
            if(!(number > max)) continue;
            max = number;
            res = item;
        }
        return res;
    }
}

#endregion

#region Пункт 2-4

/*
2. Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;

3. Оформить событие и его аргументы с использованием .NET соглашений:
public event EventHandler FileFound; FileArgs – будет содержать имя файла и наследоваться от EventArgs

4. Добавить возможность отмены дальнейшего поиска из обработчика;
*/

public class FileExplorer
{
    public bool SearchCancelled { get; set; }
    public event EventHandler<FileArgs> FileFound = null!;

    public class FileArgs(string fileName) : EventArgs
    {
        public string FileName => fileName;
    }

    public void ExploreDirectory(string directoryPath)
    {
        SearchCancelled = false;
        ExploreDirectory(new DirectoryInfo(directoryPath));
    }

    private void ExploreDirectory(DirectoryInfo directory)
    {
        try
        {
            if (SearchCancelled)
            {
                return;
            }

            foreach (var file in directory.GetFiles())
            {
                OnFileFound(file.FullName);
            }

            foreach (var subDir in directory.GetDirectories())
            {
                ExploreDirectory(subDir);
            }
        }
        catch (Exception ex)
        {
            // Обработка ошибок при доступе к файлам или каталогам
            Console.WriteLine($"Error exploring directory: {ex.Message}");
        }
    }

    protected virtual void OnFileFound(string filePath)
    {
        FileFound?.Invoke(this, new FileArgs(filePath));
    }
}
    
#endregion