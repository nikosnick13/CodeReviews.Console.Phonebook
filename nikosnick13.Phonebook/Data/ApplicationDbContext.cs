using Microsoft.EntityFrameworkCore;
using nikosnick13.Phonebook.Models;

namespace nikosnick13.Phonebook.Data;
internal class ApplicationDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=.;Database=PhonebookDB;Trusted_Connection=True;TrustServerCertificate=True;");

    public DbSet<Contact> Contacts { get; set; }
}

