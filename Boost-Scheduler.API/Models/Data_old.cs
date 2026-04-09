/*/
namespace Boost_Scheduler.API.Data;

public record Schedule(
    string userID,
    List<string> gameIDs,
    List<string> timeIDs
);

public record User(
    string userID,
    string username,
    string email,
    string rating
);

public record Game(
    string gameID,
    string name,
    string system
);

public record Time(
    string timeID,
    string day,
    string startTime,
    string endTime
);

public record Collection(
    List<Schedule> schedule,
    List<User> users,
    List<Game> games,
    List<Time> times
);
//*/