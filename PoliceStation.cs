public class PoliceStation : IMessageWritter
{
    public List<PoliceCar> policeCars { get; private set; }

    public PoliceStation()
    {
        policeCars = new List<PoliceCar>();
    }

    public PoliceCar AddPoliceCar(string newPlate, SpeedRadar? speedRadar = null)
    {
        PoliceCar newPoliceCar = new PoliceCar(newPlate, this, speedRadar);
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

    public void StopPersecution(string infractorsPlate)
    {
        Console.WriteLine(WriteMessage("alarm dectivated"));
        foreach (PoliceCar policeCar in policeCars)
        {
            bool currentlyPersecuting = policeCar.IsPersecuting();
            if (currentlyPersecuting)
            {
                policeCar.StopPersecution(infractorsPlate);
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