using System.Diagnostics.Metrics;

public class PoliceCar : VehicleWithPlate
{
    //constant string as TypeOfVehicle wont change allong PoliceCar instances
    private const string typeOfVehicle = "Police Car";
    private bool isPatrolling;
    private bool isPersecuting;
    private SpeedRadar? speedRadar;
    private PoliceStation station;

    public PoliceCar(string plate, PoliceStation station, SpeedRadar? speedRadar = null) : base(typeOfVehicle, plate)
    {
        isPatrolling = false;
        isPersecuting = false;
        this.speedRadar = speedRadar;
        this.station = station;
        
    }

    public void UseRadar(VehicleWithPlate vehicle)
    {
        if (isPatrolling && speedRadar != null)
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
        else if (speedRadar == null)
        {
            Console.WriteLine(WriteMessage($"has no radar."));
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
            isPersecuting = false;
            Console.WriteLine(WriteMessage("stopped patrolling."));
        }
        else
        {
            Console.WriteLine(WriteMessage("was not patrolling."));
        }
    }

    public void PrintRadarHistory()
    {
        if (speedRadar != null)
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
        }
        else
        {
            Console.WriteLine(WriteMessage("doesn´t have a speed radar"));
        }
    }

    public void PersecuteVehicle(string infractorsPlate)
    {
        if (!isPersecuting)
        {
            SetPersecuting(true);
            Console.WriteLine(WriteMessage($"is persecuting vehicle with plate {infractorsPlate}"));
        }
        else
        {
            Console.WriteLine(WriteMessage($"is already persecuting a vehicle"));
        }
    }
}