// See https://aka.ms/new-console-template for more information

using Serialization;

var path = "person.dat";
var capacity = 100000;
List<F> list;

#region Serialize
/*
{
    list = Help.GenerateList(capacity);

    var start = DateTime.Now;

    //Serialize.MySerializeToFile(list, path);
    //Serialize.JsonSerializeToFile(list, path);

    Console.WriteLine(DateTime.Now - start);
}
*/
#endregion

#region Deserialize
/*
{
    var start = DateTime.Now;

    //list = Deserialization.MyDeserializeFromFile(path, capacity);
    //list = Deserialization.MyDeserializeFromCsvFile(path, capacity);
    //list = Deserialization.JsonDeserializeFromFile(path, capacity);

    Console.WriteLine(DateTime.Now - start);
}
*/
#endregion