public class City : IMessageWritter
{
    private string cityName;
    private PoliceStation? policeStation = null;
    public City(string cityName)
    {
        this.cityName = cityName;
    }

    public void AddPoliceStation(PoliceStation policeStation)
    {
        this.policeStation = policeStation;
        Console.WriteLine(WriteMessage("has added a police station"));
    }

    //Override ToString() method with class information
    public override string ToString()
    {
        return $"{cityName}";
    }

    //Implment interface with City message structure
    public string WriteMessage(string message)
    {
        return $"{this}: {message}";
    }
}

