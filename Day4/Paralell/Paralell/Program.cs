using System.Diagnostics;
using System.Net.WebSockets;

int degree = Environment.ProcessorCount; // adjust as needed or bind to UI
var options = new ParallelOptions
{
    MaxDegreeOfParallelism = degree
};

//Parallel.For(0, 50, options, (i, loopState) =>
//{
//    Console.WriteLine(i);
//});

//Stopwatch sw = Stopwatch.StartNew();
//var all = Enumerable.Range(1000000, 5000000);
////all.Where(IsPrime).ToArray();//00:00:00.7360800

////all.AsParallel().Where(IsPrime).ToArray(); //00:00:00.2600148
//all.AsParallel().AsOrdered().WithDegreeOfParallelism(8).Where(IsPrime).ToArray();  //00:00:00.3693836

//Console.WriteLine(sw.Elapsed);



//all.AsParallel()
//    .AsOrdered()

//    .Select(x=> x.ToString().ToUpper()).ToList().ForEach(x=> Console.WriteLine(x));

Enumerable.Range(0, 20000000).AsParallel().Where(IsPrime).WithDegreeOfParallelism(5).ToList();

//var t = Task.Factory.StartNew(_ => DoWork(), "IndexingTask");
Console.Read();
void DoWork()
{
    for (int i = 0; i < 90000; i++)
    {
        Console.WriteLine($"Working... {i}");
        Thread.Sleep(500);
    }
}


static bool IsPrime(int value)
{
    if (value <= 1)
    {
        return false;
    }

    if (value == 2)
    {
        return true;
    }

    if ((value & 1) == 0)
    {
        return false;
    }

    // Check divisors up to sqrt(value)
    var limit = (int)Math.Sqrt(value);

    // 6k ± 1 optimization: all primes > 3 are of the form 6k ± 1
    for (int i = 3; i <= limit; i += 2)
    {
        if (value % i == 0)
        {
            return false;
        }
    }

    //Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
    return true;
}


