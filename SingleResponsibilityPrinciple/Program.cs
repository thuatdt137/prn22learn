using OpenClosedPrinciple.Model;
using OpenClosedPrinciple.Utilities;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static List<Book> bookList;
    static void PrintBooks(List<Book> books)
    {
        Console.WriteLine(" List of Books");
        Console.WriteLine(" ---------------------");
        foreach (var item in books)
        {
            Console.WriteLine($"{item.Title.PadRight(39, ' ')}" + $"{item.Author.PadRight(20, ' ')} {item.price}");

        }
        Console.ReadLine();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please, press 'yes' to read an extra file, ");
        Console.WriteLine("or any other key for a single file");
        var ans = Console.ReadLine();
        bookList = (ans.ToLower() != "yes") ? Utilities.ReadData() : Utilities.ReadDataExtra();
        PrintBooks(bookList);
    }
}