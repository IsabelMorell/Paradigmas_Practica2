internal class Program
{
    static void Main()
    {
        City city = new City("Madrid");
        PoliceStation policeStation = new PoliceStation();
        
        Console.WriteLine(city.WriteMessage("Created"));
        Console.WriteLine(policeStation.WriteMessage("Created"));
        
        city.AddPoliceStation(policeStation);

        Taxi taxi1 = new Taxi("0001 AAA", true);
        Taxi taxi2 = new Taxi("0002 BBB", true);
        Taxi taxi3 = new Taxi("0003 CCC", true);
        Taxi taxi4 = new Taxi("0004 DDD", true);
        Taxi taxi5 = new Taxi("0005 EEE", true);

        PoliceCar policeCar1 = policeStation.AddPoliceCar("0001 CNP", new SpeedRadar());
        PoliceCar policeCar2 = policeStation.AddPoliceCar("0002 CNP", new SpeedRadar());
        PoliceCar policeCar3 = policeStation.AddPoliceCar("0003 CNP");
        PoliceCar policeCar4 = policeStation.AddPoliceCar("0004 CNP", new SpeedRadar());
        PoliceCar policeCar5 = policeStation.AddPoliceCar("0005 CNP");

        Console.WriteLine(taxi1.WriteMessage("Created"));
        Console.WriteLine(taxi2.WriteMessage("Created"));
        Console.WriteLine(taxi3.WriteMessage("Created"));
        Console.WriteLine(taxi4.WriteMessage("Created"));
        Console.WriteLine(taxi5.WriteMessage("Created"));
        Console.WriteLine(policeCar1.WriteMessage("Created"));
        Console.WriteLine(policeCar2.WriteMessage("Created"));
        Console.WriteLine(policeCar3.WriteMessage("Created"));
        Console.WriteLine(policeCar4.WriteMessage("Created"));
        Console.WriteLine(policeCar5.WriteMessage("Created"));

        policeCar1.StartPatrolling();
        policeCar1.UseRadar(taxi1);

        policeCar3.StartPatrolling();
        policeCar3.UseRadar(taxi3);
        policeCar5.StartPatrolling();

        taxi2.StartRide();
        policeCar2.UseRadar(taxi2);
        policeCar2.StartPatrolling();
        policeCar2.UseRadar(taxi2);
        taxi2.StopRide();
        taxi2.TakeLicense();
        policeCar2.EndPatrolling();

        taxi1.StartRide();
        taxi1.StartRide();
        policeCar1.StartPatrolling();
        policeCar1.UseRadar(taxi1);
        taxi1.StopRide();
        taxi1.StopRide();
        policeCar1.EndPatrolling();

        policeCar1.PrintRadarHistory();
        policeCar2.PrintRadarHistory();
    }
}