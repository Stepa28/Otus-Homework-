using PleasingTheNumber.Interface;

namespace PleasingTheNumber.Clases;

public class IntConverter : IIntConverter
{
    public int Convert(string str)
    {
        return int.Parse(str);
    }
}