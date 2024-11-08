namespace PrototypePattern;

// 3. Класс Mammal, который наследуется от Animal
public class Mammal : Animal
{
    public int NumberOfLegs { get; set; }

    public Mammal(string name, int numberOfLegs) : base(name)
    {
        NumberOfLegs = numberOfLegs;
    }

    protected Mammal(Mammal source) : base(source)
    {
        NumberOfLegs = source.NumberOfLegs;
    }

    public override Mammal Clone()
    {
        return new Mammal(this);
    }
}