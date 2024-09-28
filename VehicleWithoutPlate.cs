using System;

public class VehicleWithoutPlate : Vehicle
{
	public VehicleWithoutPlate(string typeOfVehicle) : base(typeOfVehicle)
    {
	}

    //Override ToString() method with class information
    public override string ToString()
    {
        return $"{GetTypeOfVehicle()}";
    }
}
