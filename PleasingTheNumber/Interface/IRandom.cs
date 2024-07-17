namespace PleasingTheNumber.Interface;

public interface IRandom
{
    int Next(int min = 1, int max = 100);
}