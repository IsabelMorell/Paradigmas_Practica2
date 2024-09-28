public class PoliceStation : IMessageWritter
{
    public List<PoliceCar> policeCars { get; private set; }

    public PoliceStation()
    {
        policeCars = new List<PoliceCar>();
    }

    public PoliceCar AddPoliceCar(string newPlate)
    {
        PoliceCar newPoliceCar = new PoliceCar(newPlate, this);  // relacion de composicion
        policeCars.Add(newPoliceCar);
        return newPoliceCar;
    }

    public void ActUponAlarm(string infractorsPlate)
    {
        Console.WriteLine(WriteMessage("alarm activated"));
        foreach (PoliceCar policeCar in policeCars)
        {
            bool currentlyPatrolling = policeCar.IsPatrolling();
            if (currentlyPatrolling)
            {
                policeCar.PersecuteVehicle(infractorsPlate);
            }
        }
    }

    //Implment interface with PoliceStation message structure
    public string WriteMessage(string message)
    {
        return $"Police Station: {message}";
    }

    public void GetPoliceCars()
    {
        Console.WriteLine(WriteMessage("plates of the police cars of this station:"));
        foreach (PoliceCar policeCar in policeCars)
        {
            Console.WriteLine(policeCar.GetPlate());
        }
    }
}