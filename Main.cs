internal class Program
{

    static void Main()
    {
        Taxi taxi1 = new Taxi("0001 AAA", true);
        Taxi taxi2 = new Taxi("0002 BBB", true);

        PoliceStation policeStation = new PoliceStation();

        PoliceCar policeCar1 = policeStation.AddPoliceCar("0001 CNP");
        PoliceCar policeCar2 = policeStation.AddPoliceCar("0002 CNP");

        Console.WriteLine(taxi1.WriteMessage("Created"));
        Console.WriteLine(taxi2.WriteMessage("Created"));
        Console.WriteLine(policeCar1.WriteMessage("Created"));
        Console.WriteLine(policeCar2.WriteMessage("Created"));

        policeCar1.StartPatrolling();
        policeCar1.UseRadar(taxi1);

        taxi2.StartRide();
        policeCar2.UseRadar(taxi2);
        policeCar2.StartPatrolling();
        policeCar2.UseRadar(taxi2);
        taxi2.StopRide();
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