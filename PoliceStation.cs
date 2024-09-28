public class PoliceStation
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
        foreach (PoliceCar policeCar in policeCars)
        {
            bool currentlyPatrolling = policeCar.IsPatrolling();
            if (currentlyPatrolling)
            {
                policeCar.PersecuteCar(infractorsPlate);
            }
        }
    }
}