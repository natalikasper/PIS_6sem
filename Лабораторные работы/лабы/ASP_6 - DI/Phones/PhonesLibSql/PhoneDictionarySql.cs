using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace PhonesLibSql
{
    public interface IPhoneDictionary<T> where T : class
    {
        List<T> GetConList();
        T GetContact(long id);
        void Create(T item);
        void Update(T item);
        void Delete(long id);
    }


    public class Contact
    {
        public long Id { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public Contact() { }
    }


    public class AppContext : DbContext
    {
        public AppContext() : base("PhoneBook")
        { }
        public virtual DbSet<Contact> Contacts { get; set; }
    }


    public class PhoneDictionarySql : IPhoneDictionary<Contact>
    {
        public List<Contact> GetConList()
        {
            using (AppContext db = new AppContext())
            {
                List<Contact> contacts = db.Contacts.OrderBy(p => p.Surname).ToList();
                return contacts;
            }
        }

        public Contact GetContact(long id)
        {
            Contact contact;
            using (AppContext db = new AppContext())
            {
                contact = db.Contacts.Find(id);
                return contact;
            }
        }

        public void Create(Contact item)
        {
            using (AppContext db = new AppContext())
            {
                db.Contacts.Add(item);
                db.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            using (AppContext db = new AppContext())
            {
                Contact contact = db.Contacts.Where(p => p.Id.Equals(id)).FirstOrDefault();
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }

        public void Update(Contact item)
        {
            using (AppContext db = new AppContext())
            {
                var contact = db.Contacts.Find(item.Id);
                contact.Phone = item.Phone;
                contact.Surname = item.Surname;
                db.Entry<Contact>(contact).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
