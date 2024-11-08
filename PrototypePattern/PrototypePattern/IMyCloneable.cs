namespace PrototypePattern;

// 1. Создаем интерфейс IMyCloneable с шаблоном типа
public interface IMyCloneable<out T>
{
    T Clone();
}