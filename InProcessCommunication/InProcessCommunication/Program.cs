// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

var list = new List<int>();
var rand = new Random();
const int iteration = 10_000_000;
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
long sum4 = 0;
var watch = new Stopwatch();

watch.Start();
foreach (var item in list)
{
    sum += item;
}

watch.Stop();
Console.WriteLine($"Последовательного вычисления:\t{sum} | {watch.Elapsed}");

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
Console.WriteLine($"Параллельное вычисление:\t{sum2} | {watch.Elapsed}");

watch.Restart();
sum3 = list.AsParallel().Sum();
watch.Stop();
Console.WriteLine($"LINQ:\t\t\t\t{sum3} | {watch.Elapsed}");



var pos = 0;
var step = 10000;
var c = iteration / step + 1;
var ps = new List<IEnumerable<int>>(c);

watch.Restart();
for (var i = 0; i < c; i++)
{
    var p = list.Skip(pos).Take(step);
    ps.Insert(i, p);
    pos += step;
}

sum4 = ps.AsParallel().Select(x => x.Sum()).Sum();

watch.Stop();
Console.WriteLine($"Parallel Step:\t\t\t{sum4} | {watch.Elapsed}");


var vectorSize = Vector<int>.Count;
var accVector = Vector<int>.Zero;
var tmp = list.ToArray();

watch.Restart();
var index = 0;

for (; index < list.Count - vectorSize; index += vectorSize)
{
    var v = new Vector<int>(tmp, index);
    accVector = Vector.Add(accVector, v);
}

var result = Vector.Dot(accVector, Vector<int>.One);

for (; index < list.Count; index++)
{
    result += list[index];
}
watch.Stop();
Console.WriteLine($"Vector:\t\t\t\t{result} | {watch.Elapsed}");

void SummationOfEveryThreadsCountElement(object value)
{
    //if(value is object[] and [string HH, int aa])
    //{
    //    HH = aa.ToString();
    //}
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
    catch(Exception ex)
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