using PleasingTheNumber.Interface;

namespace PleasingTheNumber.Clases;

public class InputConsole : IInputString
{
    public string Input()
    {
        return Console.ReadLine();
    }
}