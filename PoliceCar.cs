using System.Diagnostics.Metrics;

public class PoliceCar : Vehicle
{
    //constant string as TypeOfVehicle wont change allong PoliceCar instances
    private const string typeOfVehicle = "Police Car";
    private bool isPatrolling;
    private bool isPersecuting;
    private SpeedRadar speedRadar;
    private PoliceStation station;

    public PoliceCar(string plate, PoliceStation station) : base(typeOfVehicle, plate)
    {
        isPatrolling = false;
        isPersecuting = false;
        speedRadar = new SpeedRadar();
        this.station = station;
    }

    public void UseRadar(Vehicle vehicle)
    {
        if (isPatrolling)
        {
            speedRadar.TriggerRadar(vehicle);
            bool speeding = speedRadar.GetLastReading();
            if (speeding)
            {
                Console.WriteLine(WriteMessage($"Triggered radar. Result: Catched above legal speed."));
                station.ActUponAlarm(vehicle.GetPlate());
            }
            else
            {
                Console.WriteLine(WriteMessage($"Triggered radar. Result: Driving legally."));
            }
        }
        else
        {
            Console.WriteLine(WriteMessage($"has no active radar."));
        }
    }

    public bool IsPatrolling()
    {
        return isPatrolling;
    }

    public void SetPersecuting(bool newState)
    {
        isPersecuting = newState;
    }

    public void StartPatrolling()
    {
        if (!isPatrolling)
        {
            isPatrolling = true;
            Console.WriteLine(WriteMessage("started patrolling."));
        }
        else
        {
            Console.WriteLine(WriteMessage("is already patrolling."));
        }
    }

    public void EndPatrolling()
    {
        if (isPatrolling)
        {
            isPatrolling = false;
            Console.WriteLine(WriteMessage("stopped patrolling."));
        }
        else
        {
            Console.WriteLine(WriteMessage("was not patrolling."));
        }
    }

    public void PrintRadarHistory()
    {
        Console.WriteLine(WriteMessage("Report radar speed history:"));
        foreach (float speed in speedRadar.SpeedHistory)
        {
            Console.WriteLine(speed);
        }
    }

    public void PersecuteCar(string infractorsPlate)
    {
        SetPersecuting(true);
    }
}