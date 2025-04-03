using static System.Console;
using nikosnick13.Phonebook.Enums;
using Spectre.Console;
using static nikosnick13.Phonebook.Enums.MenuIteams;
using nikosnick13.Phonebook.Controllers;
using nikosnick13.Phonebook.Models;

namespace nikosnick13.Phonebook;

internal class UserInterface
{
    public void MainMenu()
    {

        bool isProductMenuRunning = true;

        while (isProductMenuRunning)
        {
            var options = AnsiConsole.Prompt(new SelectionPrompt<MenuOptions>()
           .Title("What you like to do?")
           .AddChoices(
               MenuOptions.AddContact,
               MenuOptions.ViewAllContact,
               MenuOptions.ViewContact,
               MenuOptions.UpdateContact,
               MenuOptions.DeleteContact,
               MenuOptions.Exit)); ;

            switch (options)
            {
                case MenuOptions.AddContact:
                    CreatAContact();
                    break;
                case MenuOptions.ViewAllContact:
                    DisplayAllContacts();
                    break;
                case MenuOptions.ViewContact:
                    DisplayOneContact();
                    break;
                case MenuOptions.UpdateContact:
                    UpdateAContact();
                    break;
                case MenuOptions.DeleteContact:
                    DeleteAContact();
                    break;
                case MenuOptions.Exit:
                    Utility.ShowExitStatus();
                    isProductMenuRunning = false;
                    break;

            }
        }
    }

    private void CreatAContact()
    {

        string userName = GetUserName("Write the name for your contact or prees '0' to return in MainMenu:");
        string userEmail = GetUserEmail("Write the email for your contact or prees '0' to return in MainMenu:");
        string userPhone = GetUserPhoneNumber("Write the phone number for your contact   or prees '0' to return in MainMenu:");

        var contact = new Contact
        {
            Name = userName,
            Email = userEmail,
            PhoneNumber = userPhone
        };

        ContactController.AddContact(contact);
        Utility.DisplayReturnMessage("\n[yellow]Contact added successfully! \nPress Enter to back in Main menu....[/]");
        Utility.ShowLoadingStatus();
        AnsiConsole.Clear();
    }

    private string GetUserName(string msg)
    {
        AnsiConsole.Markup($"[green]{msg}[/]");

        string? userInput = ReadLine();

        if (userInput == "0")
        {
            Utility.ShowLoadingStatus();
            Clear();
            MainMenu();
            return "";
        }
        while (!Validation.isNameValid(userInput) || string.IsNullOrEmpty(userInput))
        {
            AnsiConsole.MarkupLine("[green]Please try again!![/]");
            AnsiConsole.MarkupLine($"[green]{msg}[/]");
            userInput = ReadLine();
            
            if(string.IsNullOrEmpty(userInput)) AnsiConsole.MarkupLine("[red]Input cannot be empty.[/]");
        }
       
        return userInput;
    }

    private string GetUserEmail(string msg)
    {
        AnsiConsole.Markup($"[green]{msg}[/]");

        string? userInput = ReadLine();

        if (userInput == "0")
        {
            Utility.ShowLoadingStatus();
            Clear();
            MainMenu();
            return "";
        }

        while (!Validation.isEmailValid(userInput) || string.IsNullOrEmpty(userInput))
        {
            AnsiConsole.MarkupLine("[green]Please try again!![/]");
            AnsiConsole.Markup($"[green{msg}[/]");
            userInput = ReadLine();

            if(string.IsNullOrEmpty(userInput)) AnsiConsole.MarkupLine("[red]Input cannot be empty.[/]");
        }

        return userInput;
    }

    private string GetUserPhoneNumber(string msg)
    {

        AnsiConsole.Markup($"[green]{msg}[/]");

        string? userInput = ReadLine();

        if (userInput == "0")
        {
            Utility.ShowLoadingStatus();
            Clear();
            MainMenu();
            return "";
        }

        while (!Validation.isPhoneValid(userInput) || string.IsNullOrEmpty(userInput))
        {
            AnsiConsole.MarkupLine("[green]Please try again!![/]");
            AnsiConsole.Markup($"[green]{msg}[/]");
            userInput = ReadLine();

            if (string.IsNullOrEmpty(userInput)) AnsiConsole.MarkupLine("[red]Input cannot be empty.[/]");
        }
        return userInput;
    }

    private void DisplayAllContacts() {

        ContactController.GetAllContacts();
        Utility.DisplayReturnMessage("\n[yellow]Press Enter to back in Main menu....[/]");
        AnsiConsole.Clear();
    }

    private void DeleteAContact()
    {

        ContactController.GetAllContacts();

        Utility.DisplayReturnMessage("\n[yellow]Press Enter to select id....[/]");

        ReadKey();
        
        int userInputId = Validation.getValidInt("\nWrite the id to delete the contact or prees '0' to return in MainMenu: ");

        if (userInputId == 0)
        {
            Utility.ShowLoadingStatus();
            Clear();
            MainMenu();
            return;
        }

        var idContact = ContactController.GetContactById(userInputId);

        if (idContact == null)
        {
            AnsiConsole.MarkupLine("[red]Contact not found![/]");
            return;
        }

        ContactController.DeleteContact(idContact);
        Utility.DisplayReturnMessage($"[yellow]The Id:{idContact.Id} was delete it successfull.\nPrees Enter to return in MainMenu[/]");
        Utility.ShowLoadingStatus();

        AnsiConsole.Clear();
    }

    private void DisplayOneContact() {

        ContactController.GetAllContacts();

        int userInputId = Validation.getValidInt("\nWrite the id to view the contact or press '0' to return to MainMenu: ");

        if (userInputId == 0)
        {
            Utility.ShowLoadingStatus();
            Clear();
            MainMenu();
            return;
        }

        var idContact = ContactController.GetContactById(userInputId);

        if (idContact == null)
        {
            AnsiConsole.MarkupLine("[red]Contact not found![/]");
            return;
        }
      
        TableVisualisation.ShowContact(idContact);
        Utility.DisplayReturnMessage("[green]Prees Enter to return in MainMenu[/]");
        Utility.ShowLoadingStatus();
    }

    private void UpdateAContact() {

        ContactController.GetAllContacts();

        int userInputId = Validation.getValidInt("Write the id to updete the contact or press '0' to return to MainMenu: ");

        if (userInputId == 0)
        {
            Utility.ShowLoadingStatus();
            Clear();
            MainMenu();
            return;
        }

        var idContact = ContactController.GetContactById(userInputId);

        if (idContact == null)
        {
            AnsiConsole.MarkupLine("[red]Contact not found![/]");
            return;
        }
       
      

        if(Utility.ConfirmationStatus("Do you want to chagnge the name?"))
        {
            string newName = GetUserName("Enter a new name or press '0' to return to MainMenu:");
            if (!string.IsNullOrEmpty(newName)) idContact.Name = newName;
            
        }

        if (Utility.ConfirmationStatus("Do you want to chagnge the email?"))
        {
            string newEmail = GetUserEmail("Enter the new email or press '0' to return to MainMenu:");
            if (!string.IsNullOrEmpty(newEmail)) idContact.Email = newEmail;
        }
        if (Utility.ConfirmationStatus("Do you want to chagnge the phoneNumber?")) { 

            string newPhoneNumber = GetUserPhoneNumber("Enter the new phone number or press '0' to return to MainMenu:");
            if(!string.IsNullOrEmpty(newPhoneNumber))idContact.PhoneNumber = newPhoneNumber;
            
        }
       
        ContactController.UpdateContact(idContact);

        Utility.DisplayReturnMessage("\n[green]Contact updated successfully!\nPrees Enter to return in MainMenu[/]");
        Utility.ShowLoadingStatus();
        AnsiConsole.Clear();
    }
}
