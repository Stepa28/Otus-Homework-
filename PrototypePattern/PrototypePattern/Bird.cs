namespace PrototypePattern;

// 5. Класс Bird, наследник Animal
public class Bird : Animal
{
    public bool CanFly { get; set; }

    public Bird(string name, bool canFly) : base(name)
    {
        CanFly = canFly;
    }

    protected Bird(Bird source) : base(source)
    {
        CanFly = source.CanFly;
    }

    public override Bird Clone()
    {
        return new Bird(this);
    }
}