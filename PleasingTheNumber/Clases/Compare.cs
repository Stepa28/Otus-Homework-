using PleasingTheNumber.Interface;

namespace PleasingTheNumber.Clases;

public class Compare : ICompared
{
    public int Compared(int source, int second)
    {
        return source > second ? 1 : source < second ? -1 : 0;
    }
}