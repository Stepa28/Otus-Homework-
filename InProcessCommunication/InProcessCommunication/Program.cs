// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

var list = new List<int>();
var rand = new Random();
const int iteration = 100000;
Console.WriteLine($"Размер листа {iteration}");
for (var i = 0; i < iteration; i++)
{
    list.Add(rand.Next() % 10);
}

const int threadsCount = 8;
var threads = new List<Thread>();

var sums = new int[threadsCount];
for (var i = 0; i < threadsCount; i++)
{
    sums[i] = 0;
}
var memorySums = new Memory<int>(sums);
var memoryList = new Memory<int>(list.ToArray());

long sum = 0;
long sum2 = 0;
long sum3 = 0;
var watch = new Stopwatch();

watch.Start();
foreach (var item in list)
{
    sum += item;
}
watch.Stop();
Console.WriteLine($"Последовательного вычисления: {sum} | {watch.Elapsed}");

watch.Restart();
for (int i = 0; i < threadsCount; i++)
{
    var thread = new Thread(SummationOfEveryThreadsCountElement);
    threads.Add(thread);
    thread.Start(new Sum2Struct(memoryList, memorySums, i));
}
foreach (var thread in threads)
{
    thread.Join();
}

foreach (var partialSum in memorySums.Span)
{
    sum2 += partialSum;
}
watch.Stop();
Console.WriteLine($"Параллельное вычисление: {sum2} | {watch.Elapsed}");

watch.Restart();
sum3 = list.AsParallel().Sum();
watch.Stop();
Console.WriteLine($"LINQ: {sum3} | {watch.Elapsed}");


void SummationOfEveryThreadsCountElement(object value)
{
    var sumStruct = value as Sum2Struct;
    var spanList = sumStruct.List.Span;
    var partialSum = 0;
    try
    {
        for (int i = sumStruct.Start % threadsCount; i < spanList.Length; i += threadsCount)
        {
            partialSum += spanList[i];
        }

        sumStruct.Sum.Span[sumStruct.Start % threadsCount] = partialSum; 
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

internal class Sum2Struct(Memory<int> list, Memory<int> sum, int start)
{
    public Memory<int> List = list;
    public Memory<int> Sum = sum;
    public readonly int Start = start;
}