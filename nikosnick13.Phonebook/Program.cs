using static System.Console;

namespace nikosnick13.Phonebook;

internal class Program
{
    static void Main(string[] args)
    {
        UserInterface userInterface = new UserInterface();
        userInterface.MainMenu();
    }
}
