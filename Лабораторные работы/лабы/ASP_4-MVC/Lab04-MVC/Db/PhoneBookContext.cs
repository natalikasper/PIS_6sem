using Lab04_MVC.Models;
using System.Data.Entity;

namespace Lab04_MVC.Db
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() : base("PhoneBook")
        { }

        public DbSet<Contact> Contacts { get; set; }

    }
}