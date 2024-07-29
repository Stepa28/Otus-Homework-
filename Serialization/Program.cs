// See https://aka.ms/new-console-template for more information

using System.Text;
using Newtonsoft.Json;
using Serialization;

var start = DateTime.Now;

string path = "person.dat";

List<F> list = new List<F>(100000);

// создаем объект BinaryWriter
using (StreamReader writer = new StreamReader(File.Open(path, FileMode.OpenOrCreate)))
{
    var line = writer.ReadLine();
    var entry = line.Split('$');
    foreach (var item in entry)
    {
        if(!string.IsNullOrEmpty(item))
            list.Add(JsonConvert.DeserializeObject<F>(item));
    }
}

Console.WriteLine(DateTime.Now - start);