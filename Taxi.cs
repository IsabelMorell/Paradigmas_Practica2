class Taxi : Vehicle
{
    //constant string as TypeOfVehicle wont change allong PoliceCar instances.
    private static string typeOfVehicle = "Taxi";
    private bool isCarryingPassengers;
    private bool license;

    public Taxi(string plate, bool license) : base(typeOfVehicle, plate)
    {
        //Values of atributes are set just when the instance is done if not needed before.
        isCarryingPassengers = false;
        SetSpeed(45.0f);
        this.license = license;
    }

    public void StartRide()
    {
        if (!isCarryingPassengers && license)
        {
            isCarryingPassengers = true;
            SetSpeed(100.0f);
            Console.WriteLine(WriteMessage("starts a ride."));
        }
        else
        {
            Console.WriteLine(WriteMessage("is already in a ride."));
        }
    }

    public void StopRide()
    {
        if (isCarryingPassengers)
        {
            isCarryingPassengers = false;
            SetSpeed(45.0f);
            Console.WriteLine(WriteMessage("finishes ride."));
        }
        else
        {
            Console.WriteLine(WriteMessage("is not on a ride."));
        }
    }
}