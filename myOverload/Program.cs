using System;

namespace myOverloadExample
{
    public class GameTitle
    {
        public string Game { get; set; }
        public int HoursPlayed { get; set; }
        public string? Genre { get; set; } //Action, Simulation, Other

        // Overload unary operators ++ and -- 
        public static GameTitle operator ++(GameTitle obj)
        {
            obj.HoursPlayed++;
            return obj;
        }
        public static GameTitle operator --(GameTitle obj)
        {
            obj.HoursPlayed--;
            return obj;
        }

        // Overload Comparison Operators > and <
        public static bool operator >(GameTitle left, GameTitle right)
        {
            bool larger = false;
            if (left.HoursPlayed > right.HoursPlayed)
                larger = true;
            return larger;
        }
        public static bool operator <(GameTitle left, GameTitle right)
        {
            bool smaller = false;
            if (left.HoursPlayed < right.HoursPlayed)
                smaller = true;
            return smaller;
        }

        // Overload Binary Operators + and -
        public static GameTitle operator +(GameTitle obj, double hour)
        {
            obj.HoursPlayed += obj.HoursPlayed;
            return obj;
        }
        public static GameTitle operator -(GameTitle obj, double hour)
        {
            obj.HoursPlayed -= obj.HoursPlayed;
            return obj;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            GameTitle[] myGame = new GameTitle[100];
            for (int i = 0; i < myGame.Length; i++)
            {
                myGame[i] = new GameTitle();  // creates objects
            }
            int selection = Menu();
            int index = 0, entry = 0;
            string ans = "";
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        if (index < 100)
                        {
                            Console.Write("Enter game genre (Action, Simulation, Other: ");
                            myGame[index].Genre = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Game Name: ");
                            myGame[index].Game = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Hours Played: ");
                            myGame[index].HoursPlayed = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            index++;
                        }
                        else
                            Console.WriteLine("You have too many log entries - see programming");
                        break;
                    case 2:
                        for (int i = 0; i < myGame.Length; i++)
                        {
                            if (myGame[i].Game != "" && myGame[i].Game != null)
                            {
                                Console.WriteLine($"Game Genre: {myGame[i].Genre}");
                                Console.WriteLine($"Game Name: {myGame[i].Game}");
                                Console.WriteLine($"Hours Played: {myGame[i].HoursPlayed}");
                            }
                        }
                        break;
                    case 3:
                        entry = pickEntry(index);
                        Console.Write("Change game genre (Action, Simulation, Other) Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Category? ");
                            myGame[entry].Genre = Console.ReadLine();
                        }
                        Console.WriteLine();
                        Console.Write("Change game name? Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Game name: ");
                            myGame[entry].Game = Console.ReadLine();
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        entry = pickEntry(index);

                        Console.Write("Increase Hours by 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            // calls the operator++ method
                            myGame[entry]++;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Decrease Hours by 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            // calls the operator-- method
                            myGame[entry]--;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Increase Hours by > 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Enter the hours: ");
                            int hr;
                            while (!int.TryParse(Console.ReadLine(), out hr))
                                Console.WriteLine($"Please a number");
                            // calls the operator+ method
                            // the method should receive an 
                            // object and a integer as arguments
                            myGame[entry] += hr;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Decrease Hours by > 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Enter the hours: ");
                            int hr;
                            while (!int.TryParse(Console.ReadLine(), out hr))
                                Console.WriteLine($"Please a number");
                            // calls the operator- method
                            // the method should receive an 
                            // object and a integer as arguments
                            myGame[entry] -= hr;
                            Console.WriteLine();
                            break;
                        }

                        break;
                    case 5:
                        GameTitle totalAction = new GameTitle();
                        totalAction.Genre = "Action Genre";
                        totalAction.Game = "Total hours plying action titles";
                        GameTitle totalSim = new GameTitle();
                        totalSim.Genre = "Simulation Genre";
                        totalSim.Game = "Total hours playing simulation titles";
                        GameTitle totalOther = new GameTitle();
                        totalOther.Genre = "Other Genres";
                        totalOther.Game = "Total hours playing other games";
                        for (int i = 0; i < myGame.Length; i++)
                        {
                            switch (myGame[i].Genre)
                            {
                                case "Action":
                                    totalAction.HoursPlayed += myGame[i].HoursPlayed;
                                    break;
                                case "Simulation":
                                    totalSim.HoursPlayed += myGame[i].HoursPlayed;
                                    break;
                                case "Other":
                                    totalOther.HoursPlayed += myGame[i].HoursPlayed;
                                    break;
                            }
                        }
                        Console.WriteLine("Total Hours by Genre");
                        // calls operator >
                        if (totalAction > totalSim && totalAction > totalOther)
                        {
                            Console.WriteLine("You spent the most time playing action games.");
                            Console.WriteLine($"Hours playing action games = {totalAction.HoursPlayed}");
                            Console.WriteLine($"Hours playing simulation games = {totalSim.HoursPlayed}");
                            Console.WriteLine($"Hours playing other games = {totalOther.HoursPlayed}");
                        }
                        // calls operator >
                        else if (totalAction > totalSim && totalAction > totalOther)
                        {
                            Console.WriteLine("You spent the most time playing simulation games.");
                            Console.WriteLine($"Hours playing action games = {totalAction.HoursPlayed}");
                            Console.WriteLine($"Hours playing simulation games = {totalSim.HoursPlayed}");
                            Console.WriteLine($"Hours playing other games = {totalOther.HoursPlayed}");
                        }
                        else
                        {
                            Console.WriteLine("You spent the most time playing other game genres.");
                            Console.WriteLine($"Hours playing action games = {totalAction.HoursPlayed}");
                            Console.WriteLine($"Hours playing simulation games = {totalSim.HoursPlayed}");
                            Console.WriteLine($"Hours playing other games = {totalOther.HoursPlayed}");
                        }
                        break;
                    default:
                        Console.WriteLine("You made an invalid selection, please try again");
                        break;
                }
                selection = Menu();

            }
        }
        public static int Menu()
        {
            int choice = 0;
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1 - Add a Game");
            Console.WriteLine("2 - Print All Games Played");
            Console.WriteLine("3 - Change Genre or Game Title");
            Console.WriteLine("4 - Adjust hours Played");
            Console.WriteLine("5 - Total Genres and compare");
            Console.WriteLine("6 - Quit");
            while (!int.TryParse(Console.ReadLine(), out choice))
                Console.WriteLine("Please select 1 - 6");
            return choice;
        }
        public static int pickEntry(int index)
        {
            Console.WriteLine("What entry would you like to change?");
            Console.WriteLine($"1 through {index}");
            int entry;
            while (!int.TryParse(Console.ReadLine(), out entry))
                Console.WriteLine($"Please select 1 - {index}");
            entry -= 1;  // subtract 1 to begin index at 0
            return entry;
        }
    }
}