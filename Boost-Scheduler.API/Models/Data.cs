using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.SignalR;

namespace Boost_Scheduler.API.Data;

/*/
public class Schedule
{
    string userID {get; set;}
    List<string> gameIDs {get; set;}
    List<string> timeIDs {get; set;}
}

public class User{
    string userID{get; set;}
    string username{get; set;}
    string email{get; set;}
    string rating{get; set;}
}
//*/
public class Game{
    public string? GameID{get; set;}
    public string? Name{get; set;}
    public string? System{get; set;}
}

/*/
public class Time{
    string timeID {get; set;}
    string day{get; set;}
    string startTime{get; set;}
    string endTime{get; set;}
}

public class Collection{
    List<Schedule> schedule{get; set;}
    List<User> users{get; set;}
    List<Game> games{get; set;}
    List<Time> times{get; set;}
}
//*/