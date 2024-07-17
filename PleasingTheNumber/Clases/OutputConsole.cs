using PleasingTheNumber.Interface;

namespace PleasingTheNumber.Clases;

public class OutputConsole : IOutputString
{
    public void Write(string str)
    {
        Console.Write(str);
    }
}