using nikosnick13.Phonebook.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nikosnick13.Phonebook;

internal class TableVisualisation
{
    public static void ShowContact(Contact contact) {

        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Email");
        table.AddColumn("Phone");

        table.AddRow(
            contact.Id.ToString(),
            contact.Name ?? "-",
            contact.Email ?? "-",
            contact.PhoneNumber ?? "-" );
        AnsiConsole.Write(table);
    }

    public  static void ShowTable(List<Contact> recordList)  
    {
        var table = new Table();
        table.Title("Contacts");
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Email");
        table.AddColumn("PhoneNumber");

        foreach (var record in recordList) {
            table.AddRow(record.Id.ToString(),
                         record.Name ?? "-",
                         record.Email ?? "-",
                         record.PhoneNumber ?? "-");
        }
        AnsiConsole.Write(table);
    }
}
