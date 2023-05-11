namespace SharedModels;

public class Location
{
    public float Long { get; }
    public float Lat { get; }

    public Location(float longitude, float lat)
    {
        Long = longitude;
        Lat = lat;
    }
}
