using Microsoft.Extensions.DependencyInjection;
using ServiceCollectionClassDemo.Model;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "DI-ServiceCollection Class";
        var services = new ServiceCollection();

        // Service registrations
        services.AddTransient<IXMLWriter, XMLWriter>();
        services.AddScoped<IJSONWriter, JSONWriter>();

        var provider = services.BuildServiceProvider();

        Console.WriteLine("Dependency Injection Demo");
        Console.WriteLine("Mapping Interfaces to instance classes");
        Console.WriteLine("---");
        Console.WriteLine("Please, select message format (1):XML | (2):JSON");
        var res = Console.ReadLine();

        if (res == "1")
        {
            var XMLInstance = provider.GetService<IXMLWriter>();
            XMLInstance?.WriteXML();
        }
        else
        {
            // Create scope for scoped services
            using var scope = provider.CreateScope();
            var JSONInstance = scope.ServiceProvider.GetService<IJSONWriter>();
            JSONInstance?.WriteJSON();
        }
        var registeredXMlServices = provider.GetServices<IXMLWriter>();
        foreach (var svc in registeredXMlServices)
        {
            Console.WriteLine($"Service Name:{svc.ToString()}");
        }
        Console.WriteLine(new String('*', 20));
        foreach(var svc in services)
        {
            Console.WriteLine($"Type: {svc.ImplementationType} \n" +
                $"Lifetime: {svc.Lifetime} \n" +
                $"Service Type: {svc.ServiceType}");
        }
        Console.ReadLine();
    }
}