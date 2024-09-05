// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Parallelism;

var watch = new Stopwatch();

watch.Start();

var space = new SpaceCounter("c:\\Project\\Otus-Homework-\\Parallelism\\Примеры\\");

watch.Stop();
Console.WriteLine($"Результат: {space.SpaceCount}");

Console.WriteLine("Elapsed time: " + watch.Elapsed);
