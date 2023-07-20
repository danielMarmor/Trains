// See https://aka.ms/new-console-template for more information
using PubSubTrainManager;

Console.WriteLine("Welcome, Train Manager!");

Manager manager = new Manager();

while (true)
{
    try
    {
        Console.WriteLine(@$"Operation Options ===>
         0 -Quit
         1- AddCabin,
         2- Remove Cabin,
         3- Start Drive,
         4-Stop Drive,
         5-Post Message,");

        var operation = Console.ReadLine();

        int selectedOperNumber;
        bool isValid = int.TryParse(operation, out selectedOperNumber);
        if (!isValid)
        {
            Console.WriteLine("Please Press a Number!");
            continue;
        }

        switch (selectedOperNumber)
        {
            case (int)ManagerOptions.Quit:
                break;
            case (int)ManagerOptions.AddCabin:
                manager.AddCabin();
                Console.WriteLine("Cabin Added");
                break;
            case (int)ManagerOptions.RemoveCabin:
                manager.RemoveCabin();
                Console.WriteLine("Cabin Removed");
                break;
            case (int)ManagerOptions.StartDrive:
                manager.StartDriving();
                Console.WriteLine("Start Drive");
                break;
            case (int)ManagerOptions.StopDrive:
                manager.StopDriving();
                Console.WriteLine("Stop Drive");
                break;
            case (int)ManagerOptions.PostMessageToPassengers:
                manager.PostMessage($"The Time is {DateTime.Now.ToLongTimeString()}");
                break;
            default:
                Console.WriteLine("Please Press Valid Input");
                break;

        }
        if (selectedOperNumber == (int)ManagerOptions.Quit)
        {
            break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

Console.WriteLine("Thank You!");



