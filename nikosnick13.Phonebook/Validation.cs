using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spectre.Console;
using nikosnick13.Phonebook;
using System.Threading.Tasks;
using nikosnick13.Phonebook.Migrations;
using static System.Console;
using System.Text.RegularExpressions;
using Microsoft.Identity.Client;

namespace nikosnick13.Phonebook;


internal class Validation
{
    public static bool isNameValid(string? userInput)
    { 
        if (string.IsNullOrWhiteSpace(userInput)) {

            AnsiConsole.MarkupLine("[red]The input is empty or contains only spaces.[/]");
            return false;
        }
        if (userInput.Length < 3 || userInput.Length > 255) {

            AnsiConsole.MarkupLine("[red]The input must be between 3 and 255 characters.[/]");
            return false;
        }
        if (userInput.Any(char.IsDigit)) {

            AnsiConsole.MarkupLine("[red]The input must not contain numbers.[/]");
            return false;
        }

        return true;
    }

    public static bool isEmailValid(string? emailInput) {

        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        
        if (string.IsNullOrWhiteSpace(emailInput) || !Regex.IsMatch(emailInput,emailPattern)) {

            AnsiConsole.MarkupLine("[red]The email is not valid. Please enter a valid email address.[/]");
            return false;
        }
        return true;
    }

    public static bool isPhoneValid(string? phoneInput)
    {
        if (string.IsNullOrWhiteSpace(phoneInput))
        {
            AnsiConsole.MarkupLine("[red]The input is empty or contains only spaces.[/]");
            return false;
        }
        if (phoneInput.Length != 10) {
            AnsiConsole.MarkupLine("[red]The phone number must contain exactly 10 digits.[/]");
            return false;
        }

        foreach (char c in phoneInput) {

            if (!char.IsDigit(c)) {

                AnsiConsole.MarkupLine("[red]The phone number must contain only digits.[/]");
                return false;
            }
        }
        return true;
    }

    public static int getValidInt(string msg) {

        while(true) {

            AnsiConsole.Markup($"[green]{msg}[/]\n");  

            string? input = ReadLine();

            if (input == "0") return 0;

            if (int.TryParse(input, out int result)) return result;
             
            AnsiConsole.MarkupLine("[red]Invalid input. Please enter a valid number.[/]");
        }
    }
}
