using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;

namespace Serialization;

public static class Deserialization
{
    public static List<F> MyDeserializeFromCsvFile(string path, int capacity = 0)
    {
        var map = new Dictionary<string, int>();

        var list = new List<F>(capacity);

        using var csv = new CsvReader(new StreamReader(path), true);
        var fieldCount = csv.FieldCount;
        string[] headers = csv.GetFieldHeaders();

        for (var i = 0; i < fieldCount; i++) 
            map[headers[i]] = i;

        while (csv.ReadNextRecord())
        {
            var item = new F(int.Parse(csv[map["i1"]])
                , int.Parse(csv[map["i2"]])
                , int.Parse(csv[map["i3"]])
                , int.Parse(csv[map["i4"]])
                , int.Parse(csv[map["i5"]]));

            list.Add(item);
        }

        return list;
    }

    public static List<F> MyDeserializeFromFile(string path, int capacity = 0)
    {
        var list = new List<F>(capacity);
        using var writer = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));

        while (writer.PeekChar() > -1)
            list.Add(new F(writer.ReadBytes(20)));

        return list;
    }

    public static List<F> JsonDeserializeFromFile(string path, int capacity = 0)
    {
        var list = new List<F>(capacity);

        using var reader = new StreamReader(File.Open(path, FileMode.OpenOrCreate));
        var line = reader.ReadToEnd();
        if(!string.IsNullOrEmpty(line))
            list = JsonConvert.DeserializeObject<List<F>>(line);
        
        return list;
    }
}