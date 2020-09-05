using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLEntity
{
    public interface IPhoneDictionary
    {
        IEnumerable<Phone> GetAll();
        bool Add(Phone dictObject);
        bool Update(Phone dictObject);
        bool Delete(int id);
        Phone Find(int id);
    }
    public class Phone : IComparable<Phone>
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Telephone { get; set; }
        public int CompareTo(Phone p)
        {
            return this.FIO.CompareTo(p.FIO);
        }
    }
    public class PhoneDictionary : IPhoneDictionary
    {
        PhoneContext db; 
        public PhoneDictionary(DbContextOptions<PhoneContext> options)
        {
            this.db = new PhoneContext(options);
        }
        public IEnumerable<Phone> GetAll()
        {
            return db.Phones.OrderBy(i => i.FIO);
        }
        public bool Add(Phone dictObject)
        {
            try
            {
                db.Phones.Add(dictObject);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Phone dictObject)
        {
            try
            {
                Phone s = db.Phones.Find(dictObject.Id);
                s.FIO = dictObject.FIO;
                s.Telephone = dictObject.Telephone;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                db.Phones.Remove(db.Phones.Find(id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Phone Find(int id)
        {
            return db.Phones.Find(id);
        }
    }
    public class PhoneContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public PhoneContext(DbContextOptions<PhoneContext> options)
            : base(options)
        {

        }
    }
}
