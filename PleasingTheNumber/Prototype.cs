namespace PleasingTheNumber;

public class Prototype
{
    public static void Play()
    {
        var value = new Random().Next(1, 100);

        try
        {
            int userIn;
            do
            {
                var str = Console.ReadLine();
                userIn = int.Parse(str);
                if(userIn > value)
                    Console.WriteLine("Искомое число меньше введённого");
                if(userIn < value)
                    Console.WriteLine("Искомое число больше введённого");
            } while (userIn != value);

            Console.WriteLine("Вы нашли введённое число");
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
}