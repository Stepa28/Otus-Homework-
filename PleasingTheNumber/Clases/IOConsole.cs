using PleasingTheNumber.Interface;

namespace PleasingTheNumber.Clases;

public class IOConsole(IOutputString outputString, IInputString inputString):IIO
{

    public void Write(string str)
    {
        outputString.Write(str);
    }

    public string Input()
    {
        return inputString.Input();
    }
}