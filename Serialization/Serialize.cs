using Newtonsoft.Json;

namespace Serialization;

public static class Serialize
{
    public static void MySerializeToFile(List<F> items, string path)
    {
        using var stream = new MemoryStream();

        foreach (var item in items)
            stream.Write(item.Serialize());

        using var writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
        writer.Write(stream.ToArray());
    }

    public static void JsonSerializeToFile<T>(List<T> items, string path)
    {
        using var writer = new StreamWriter(File.Open(path, FileMode.OpenOrCreate));
        writer.Write(JsonConvert.SerializeObject(items));
    }
}