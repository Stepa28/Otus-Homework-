namespace PrototypePattern;

// 2. Базовый класс Animal с реализацией IMyCloneable и ICloneable
public class Animal : IMyCloneable<Animal>, ICloneable
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    // Клонирующий конструктор
    protected Animal(Animal source)
    {
        Name = source.Name;
    }

    // Реализация Clone из IMyCloneable
    public virtual Animal Clone()
    {
        return new Animal(this);
    }

    // Реализация ICloneable
    object ICloneable.Clone()
    {
        return Clone();
    }
}