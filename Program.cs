// 1.

/* DIP: High level methods shouldn't be coupled with low level methods and the dependency should be with a abstraction or interface */

/* IOC: The high-level code doesn't control the creation/flow of its dependencies; that control is inverted and supplied from outside. */

/* IOC container: a framework to implement both DIP and IOC Principles at the same time */

/* Factory IOC container: in this framework there is no trace over the dependency on the High level method */

/* DI: is a technique to implement IOC which the dependency is injected through a constructor*/

/*  Service LifeTimes in .Net: determining specifical Factory runs on which instance of the dependency so there is not more than one choice to start from */

//  2.

// interface IInformationReceiver
// {
//     public void Get_Information();
// }
// class DatabaseReceiveData : IInformationReceiver
// {
//     public void Get_Information()
//     {
//         //  Information Recieved
//         Console.WriteLine("Information Fetched from Database");
//     }
// }

// class ApiRecieveData : IInformationReceiver
// {
//     public void Get_Information()
//     {
//         //  Information Recieved
//         Console.WriteLine("Information Fetched from API");
//     }
// }

// class FileRecieveData : IInformationReceiver
// {
//     public void Get_Information()
//     {
//         //  Information Recieved
//         Console.WriteLine("Information Fetched from File");
//     }
// }

// public class Process
// {
//     private readonly IInformationReceiver _IInformationReceiver;

//     public Process(IInformationReceiver IInformationReceiver)
//     {
//         _IInformationReceiver = IInformationReceiver;
//     }

//     public void Run()
//     {
//         _IInformationReceiver.Get_Information();
//     }

//     static void Main()
//     {
//         IInformationReceiver source = new DatabaseReceiveData();

//         Process process = new Process(source);

//         process.Run();

//         IInformationReceiver source = new DatabaseReceiveData();

//         IInformationReceiver source= new ApiRecieveData();

//         IInformationReceiver source= new FileRecieveData(); 
//     }
// }

// 3.

// interface IInformationReceiver
// {
//     void GetInformation();
// }

// class DatabaseReceiver : IInformationReceiver
// {
//     public void GetInformation()
//     {
//         Console.WriteLine("Information fetched from Database");
//     }
// }

// class ApiReceiver : IInformationReceiver
// {
//     public void GetInformation()
//     {
//         Console.WriteLine("Information fetched from API");
//     }
// }

// class FileReceiver : IInformationReceiver
// {
//     public void GetInformation()
//     {
//         Console.WriteLine("Information fetched from File");
//     }
// }


// // Factory
// class InformationReceiverFactory
// {
//     public static IInformationReceiver Create(string source)
//     {
//         switch (source)
//         {
//             case "database":
//                 return new DatabaseReceiver();

//             case "api":
//                 return new ApiReceiver();

//             case "file":
//                 return new FileReceiver();

//             default:
//                 throw new ArgumentException("Unknown data source");
//         }
//     }
// }


// // High-level class
// class Process
// {
//     private readonly IInformationReceiver _receiver;

//     public Process(IInformationReceiver receiver)
//     {
//         _receiver = receiver;
//     }

//     public void Run()
//     {
//         _receiver.GetInformation();
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         IInformationReceiver receiver =
//             InformationReceiverFactory.Create("database");

//         Process process = new Process(receiver);

//         process.Run();
//     }
// }

// 4.

// using System;
// using Microsoft.Extensions.DependencyInjection;

// interface IInformationReceiver
// {
//     void GetInformation();
// }

// class DatabaseReceiver : IInformationReceiver
// {
//     public void GetInformation()
//     {
//         Console.WriteLine("Information fetched from Database");
//     }
// }

// class ApiReceiver : IInformationReceiver
// {
//     public void GetInformation()
//     {
//         Console.WriteLine("Information fetched from API");
//     }
// }

// class FileReceiver : IInformationReceiver
// {
//     public void GetInformation()
//     {
//         Console.WriteLine("Information fetched from File");
//     }
// }

// class Process
// {
//     private readonly IInformationReceiver _receiver;

//     public Process(IInformationReceiver receiver)
//     {
//         _receiver = receiver;
//     }

//     public void Run()
//     {
//         _receiver.GetInformation();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         // IoC Container
//         var services = new ServiceCollection();

//         // Register dependencies
//         services.AddScoped<IInformationReceiver, DatabaseReceiver>();
//         services.AddScoped<Process>();

//         // Build the container
//         var serviceProvider = services.BuildServiceProvider();

//         // Ask the container for Process
//         var process = serviceProvider.GetRequiredService<Process>();

//         // Run the program
//         process.Run();
//     }
// }