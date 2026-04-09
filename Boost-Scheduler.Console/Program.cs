using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Boost_Scheduler.API.Data;


HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5160");

bool running = true;
while (running)
{
    Console.Write("\n\n\n\n\n\n\n\n\n\n");
    await MenuItemDisplayGames();
    DisplayGameMenu();
    int response = GetInput(5);
    switch(response)
    {
        case 1:
            await MenuItemSearchGame();
            break;
        case 2:
            await MenuCreateGame();
            break;
        case 3:
            await MenuItemEditGame();
            break;
        case 4:
            await MenuItemDeleteGame();
            break;
        case 5:
            MenuItemQuit();
            break;
        default:
            break;
    }
    Console.WriteLine("Press Enter to continue.");
    string? temp = Console.ReadLine();
}

void DisplayGameMenu()
{
    Console.WriteLine("1    Search for specific game");
    Console.WriteLine("2    Create new game");
    Console.WriteLine("3    Edit game");
    Console.WriteLine("4    Delete game");
    Console.WriteLine("5    Quit");
}

async Task MenuItemDisplayGames()
{
    HttpResponseMessage response = await client.GetAsync("/api/Data/ListGames");
    if (response.IsSuccessStatusCode)
    {
        string jsonResponse = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<List<Game>>(
            jsonResponse,
            new JsonSerializerOptions{ PropertyNameCaseInsensitive = true}
        );
        if (data != null)
        {
            foreach(Game game in data)
            {
                Console.WriteLine ($"{game.GameID}: {game.Name} for {game.System}");
            }
        }
    }
    else
    {
        Console.WriteLine($"Error: {response.StatusCode}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}

async Task MenuItemSearchGame()
{
    string id = InputResponse("Please enter an Id.");

    HttpResponseMessage response = await client.GetAsync($"/api/Data/ReadGame_{id}");
    if (response.IsSuccessStatusCode)
    {
        string jsonResponse = await response.Content.ReadAsStringAsync();
        var game = JsonSerializer.Deserialize<Game>(
            jsonResponse,
            new JsonSerializerOptions{ PropertyNameCaseInsensitive = true}
        );
        if (game != null)
        {
            Console.WriteLine ($"{game.GameID}: {game.Name} for {game.System}");
        }
    }
    else
    {
        Console.WriteLine($"Error: {response.StatusCode}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}

async Task MenuCreateGame()
{
    string name = InputResponse("Please enter a name.");
    string system = InputResponse("Please enter the game system.");

    HttpResponseMessage response = await client.GetAsync($"/api/Data/CreateGame_{name}_{system}");
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Game Added to database.");
    }
    else
    {
        Console.WriteLine($"Error: {response.StatusCode}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}

async Task MenuItemEditGame()
{
    string id = InputResponse("Please enter an Id.");
    string name = InputResponse("Please enter a name.");
    string system = InputResponse("Please enter the game system.");
    HttpResponseMessage response = await client.GetAsync($"/api/Data/UpdateGames_{id}_{name}_{system}");
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Game updated");
    }
    else
    {
        Console.WriteLine($"Error: {response.StatusCode}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}

async Task MenuItemDeleteGame()
{
    string id = InputResponse("Please enter an Id.");
    HttpResponseMessage response = await client.GetAsync($"/api/Data/DeleteGame_{id}");
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Game deleted from database.");
    }
    else
    {
        Console.WriteLine($"Error: {response.StatusCode}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}

void MenuItemQuit()
{
    running = false;
}

int GetInput(int range)
{
    string? response = "";
    int choice = 0;
    Console.WriteLine($"Enter a number from 1 to {range}");

    while (choice == 0)
    {
        response = Console.ReadLine();
        if (int.TryParse(response, out choice))
        {
            if (choice < 1 || choice > range)
                choice = 0;
        }
    }
    return choice;
}

string InputResponse(string message)
{
    string? response = "";
    Console.WriteLine(message);
    while (response == "" || response == null)
    {
        response = Console.ReadLine();
    }
    return response;
}
