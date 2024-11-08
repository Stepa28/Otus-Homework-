// Создаем объекты классов и клонируем их
using PrototypePattern;

var originalDog = new Dog("Buddy", 4, "Labrador");
var clonedDog = originalDog.Clone();

var originalBird = new Bird("Parrot", true);
var clonedBird = originalBird.Clone();

// Вывод для проверки
Console.WriteLine("Original Dog: " + originalDog.Name + ", " + originalDog.Breed);
Console.WriteLine("Cloned Dog: " + clonedDog.Name + ", " + clonedDog.Breed);
Console.WriteLine("Original Bird: " + originalBird.Name + ", Can fly: " + originalBird.CanFly);
Console.WriteLine("Cloned Bird: " + clonedBird.Name + ", Can fly: " + clonedBird.CanFly);