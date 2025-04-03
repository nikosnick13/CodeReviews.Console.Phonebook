using Spectre.Console;
using nikosnick13.Phonebook;
using static System.Console;
using nikosnick13.Phonebook.Data;
using nikosnick13.Phonebook.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace nikosnick13.Phonebook.Controllers;

internal class ContactController
{
    internal static void AddContact(Contact contact)
    {
        try{
       
            using var db = new ApplicationDbContext();

            db.Contacts.Add(contact);
            db.SaveChanges();
        }
        catch(Exception ex){

            AnsiConsole.MarkupLine($"[red]Error adding contact: {ex.Message}[/]");
        }
    }

    internal static void DeleteContact(Contact contact)
    {
        try {

            var db = new ApplicationDbContext();
            db.Remove(contact);
            db.SaveChanges();

        } 
        catch(Exception ex){

            AnsiConsole.MarkupLine($"[red]Error deleting contact: {ex.Message}[/]");
        }
    }
     
    internal static void UpdateContact(Contact contact)
    {
        try {

            using var db = new ApplicationDbContext();
            db.Update(contact);

            db.SaveChanges();
        
        }
        catch (Exception ex){
            AnsiConsole.MarkupLine($"[red]Error updating contact: {ex.Message}[/]");
        }
    }

    internal static void GetAllContacts()
    {
        try {

            using var db = new ApplicationDbContext();

            var contacts = db.Contacts.ToList();

            if (contacts.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]No contacts found.[/]");
                return;
            }
            TableVisualisation.ShowTable(contacts);
        } 
        catch (Exception ex) {
            AnsiConsole.MarkupLine($"[red]Error viewing contacts: {ex.Message}[/]"); 
        }
        
    }

    //Είναι ο τύπος δεδομένων που θα επιστρέψει η μέθοδος. Εδώ δηλαδή επιστρέφει ένα αντικείμενο τύπου Contact.
    internal static Contact? GetContactById(int id)
    {
        var db = new ApplicationDbContext();
        var contactId  = db.Contacts.SingleOrDefault(x => x.Id == id);

        return contactId;
    }
}
