namespace PrototypePattern;

// 4. Класс Dog, который наследуется от Mammal
public class Dog : Mammal
{
    public string Breed { get; set; }

    public Dog(string name, int numberOfLegs, string breed) : base(name, numberOfLegs)
    {
        Breed = breed;
    }

    protected Dog(Dog source) : base(source)
    {
        Breed = source.Breed;
    }

    public override Dog Clone()
    {
        return new Dog(this);
    }
}