using Spectre.Console;
using static System.Console;

namespace nikosnick13.Phonebook;

internal class Utility
{
    public static void DisplayReturnMessage(string msg)
    {
        AnsiConsole.MarkupLine(msg);
        ReadKey();
    }

    public static void ShowLoadingStatus()
    {
        AnsiConsole.Status().Start("[yellow]Loading Main Menu...[/]", ctx =>
        {
            Thread.Sleep(1000);
        });
        AnsiConsole.Clear();
    }

    public static bool ConfirmationStatus(string msg)
    {
        var confirmation = AnsiConsole.Prompt(
            new TextPrompt<bool>($"[green]{msg}[/]")
            .AddChoice(true)
            .AddChoice(false)
            .DefaultValue(true)
            .WithConverter(choice => choice ? "y" : "n"));

        return confirmation;
    }

    public static void ShowExitStatus()
    {
        AnsiConsole.Status()
         .Spinner(Spinner.Known.Dots12)  
         .SpinnerStyle(Style.Parse("yellow"))
         .Start("[yellow]Exiting...[/]", ctx =>
         {
             Thread.Sleep(1000);
         });

        AnsiConsole.MarkupLine("[green]Goodbye! 👋[/]");
        Thread.Sleep(500);
        AnsiConsole.Clear(); ;
    }
}
