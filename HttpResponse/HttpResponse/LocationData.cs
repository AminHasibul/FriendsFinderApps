
public class LocationData
{
    public UserLocation[] Location { get; set; }
}

public class UserLocation
{
    public string UserId { get; set; }
    public string Lat { get; set; }
    public string Lng { get; set; }
    public string LastUpdate { get; set; }
}
