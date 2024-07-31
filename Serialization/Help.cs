namespace Serialization;

public static class Help
{
    public static List<F> GenerateList(int capacity)
    {
        var list = new List<F>(capacity);
        for (var i = 0; i < capacity; i++)
            list.Add(F.Get());
        return list;
    }
}