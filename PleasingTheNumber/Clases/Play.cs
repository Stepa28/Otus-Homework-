using PleasingTheNumber.Interface;

namespace PleasingTheNumber.Clases;

public class Play(IOConsole io, IRandom rand, IValidateInt valid, ICompared compared, IIntConverter converter) : IPlayable
{
    private int countRound = 1;
    private int hiddenNumber = 0;

    public void Finished()
    {
        io.Write($"Ура вы победили за {countRound-1} раундов\n");
    }

    public void Init()
    {
        hiddenNumber = rand.Next();
        io.Write("Приложение загадало число от 1 до 100, вводите числа, а приложение будет говорить больше оно искомого или меньше\n");
    }

    public bool MakeMove()
    {
        io.Write($"Раунд №{countRound} начился, введите число:\n");
        var str = io.Input();

        if(!valid.Validate(str))
        {
            io.Write("Вы ввели не число:\n");
            return false;
        }

        countRound++;
        var userInput = converter.Convert(str);
        var res = compared.Compared(hiddenNumber, userInput);
        return res != 0;
    }

    public void Gamble()
    {
        while (MakeMove()){}
        Finished();
    }
}