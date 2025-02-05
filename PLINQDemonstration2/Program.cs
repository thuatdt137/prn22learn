using System.Collections.Concurrent;
using System.Diagnostics;

class Program
{

    // GetPrimeList returns Prime numbers by using sequential ForEach
    private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();

    // GetPrimeListWithParallel returns Prime numbers by using Parallel.ForEach
    private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
    {
        var primeNumbers = new ConcurrentBag<int>();

        Parallel.ForEach(numbers, number => {
            if (IsPrime(number))
            {
                primeNumbers.Add(number);
            }
        });

        return primeNumbers.ToList();
    }

    private static bool IsPrime(int number)
    {
        bool result = true;
        if (number < 2)
        {
            result = false;
            return result;
        }
        for (var divisor = 2; divisor <= Math.Sqrt(number) && result == true; divisor++)
        {
            if (number % divisor == 0)
                result = false;
        }
        return result;
    }

    // end GetPrimeListWithParallel

    static void Main()
    {
        // 2 million
        var limit = 2_000_000;
        var numbers = Enumerable.Range(0, limit).ToList();

        var watch = Stopwatch.StartNew();
        var primeNumbersFromForeach = GetPrimeList(numbers);
        watch.Stop();

        var watchForParallel = Stopwatch.StartNew();
        var primeNumbersFromParallelForeach = GetPrimeListWithParallel(numbers);
        watchForParallel.Stop();

        Console.WriteLine($"Classical foreach loop | Total prime numbers :" +
                          $" {primeNumbersFromForeach.Count} | Time Taken : " +
                          $"{watch.ElapsedMilliseconds} ms.");
    }

}
