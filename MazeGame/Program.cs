static void TryMove(int proposedTop, int proposedLeft, string[] mazeRows)
{
    if (proposedTop >= 0 && proposedTop < mazeRows.Length &&
        proposedTop < Console.BufferHeight &&
        proposedLeft >= 0 && proposedLeft < mazeRows[proposedTop].Length &&
        proposedLeft < Console.BufferWidth)
    {
        if (mazeRows[proposedTop][proposedLeft] != '#')
        {
            Console.CursorTop = proposedTop;
            Console.CursorLeft = proposedLeft;
        }
    }
}

Console.WriteLine("Welcome to the maze");
Console.WriteLine("\npress any key to start");
Console.ReadKey(true);

string[] mapRows = File.ReadAllLines("map.txt");

Console.Clear();
foreach (string row in mapRows)
{
    Console.WriteLine(row);
}

Console.SetCursorPosition(0, 0);

ConsoleKey key;
do
{
    key = Console.ReadKey(true).Key;

    switch (key)
    {
        case ConsoleKey.UpArrow:
            TryMove(Console.CursorTop - 1, Console.CursorLeft, mapRows);
            break;
        case ConsoleKey.DownArrow:
            TryMove(Console.CursorTop + 1, Console.CursorLeft, mapRows);
            break;
        case ConsoleKey.LeftArrow:
            TryMove(Console.CursorTop, Console.CursorLeft - 1, mapRows);
            break;
        case ConsoleKey.RightArrow:
            TryMove(Console.CursorTop, Console.CursorLeft + 1, mapRows);
            break;
    }

    if (mapRows[Console.CursorTop][Console.CursorLeft] == '*')
    {
        Console.Clear();
        Console.WriteLine("Congratulations! You won!");
        Console.WriteLine("You successfully navigated the maze!");
        break;
    }
} while (key != ConsoleKey.Escape);
