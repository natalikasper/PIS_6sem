﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesLib
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


    public class PhoneDictionary : IPhoneDictionary<Contact>
    {
        readonly string path = "D:/data.json";

        public List<Contact> GetConList()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
                return contacts;
            }
        }

        public Contact GetContact(long id)
        {
            var contacts = GetConList();
            var contact = contacts.Where(p => p.Id.Equals(id)).FirstOrDefault();
            return contact;
        }

        public void Create(Contact item)
        {
            var contacts = GetConList();
            contacts.Add(item);
            var convertedJson = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            using (StreamWriter w = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                w.WriteLine(convertedJson);
            }
        }

        public void Delete(long id)
        {
            var contacts = GetConList();
            Contact contact = contacts.Where(p => p.Id.Equals(id)).FirstOrDefault();
            contacts.Remove(contact);
            var convertedJson = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            using (StreamWriter w = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                w.WriteLine(convertedJson);
            }
        }

        public void Update(Contact item)
        {
            var contacts = GetConList();
            Contact contact = contacts.Where(p => p.Id.Equals(item.Id)).FirstOrDefault();
            contacts.Remove(contact);
            contacts.Add(item);
            var convertedJson = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            using (StreamWriter w = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                w.WriteLine(convertedJson);
            }
        }
    }
}
