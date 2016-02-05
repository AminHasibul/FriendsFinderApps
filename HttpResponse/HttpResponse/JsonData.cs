
using Newtonsoft.Json;
using System.Collections.Generic;
public class JsonData
{
    
    public User[] user { get; set; }
}

public class User
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string PhoneNo { get; set; }
}
