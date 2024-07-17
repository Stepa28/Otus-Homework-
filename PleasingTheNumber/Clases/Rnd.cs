using PleasingTheNumber.Interface;

namespace PleasingTheNumber.Clases;

public class Rnd : IRandom
{
    public int Next(int min = 1, int max = 100)
    {
        return new Random().Next(min, max);
    }
}