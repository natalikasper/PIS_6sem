using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ASP3MVC.Models
{
    public class DictObjectContext
    {
        public List<DictObject> GetAll()
        {
            List<DictObject> dictObjects = JsonConvert.DeserializeObject<List<DictObject>>(File.ReadAllText("F://6 семестр//ПИС//ASP3MVC//ASP3MVC//user.json", Encoding.UTF8));
            return dictObjects;
        }
        public bool Add(DictObject dictObject)
        {
            try
            {
                List<DictObject> dictObjects = GetAll();
                dictObjects.Add(dictObject);
                File.WriteAllText("F://6 семестр//ПИС//ASP3MVC//ASP3MVC//user.json", JsonConvert.SerializeObject(dictObjects));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(DictObject dictObject)
        {
            try
            {
                List<DictObject> dictObjects = GetAll();
                foreach (DictObject dict in dictObjects)
                {
                    if (dict.Id == dictObject.Id)
                    {
                        dict.FIO = dictObject.FIO;
                        dict.Telephone = dictObject.Telephone;
                    }
                }
                File.WriteAllText("F://6 семестр//ПИС//ASP3MVC//ASP3MVC//user.json", JsonConvert.SerializeObject(dictObjects));
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
                List<DictObject> dictObjects = GetAll();
                dictObjects.Remove(dictObjects.Find(x => x.Id == id));
                File.WriteAllText("F://6 семестр//ПИС//ASP3MVC//ASP3MVC//user.json", JsonConvert.SerializeObject(dictObjects));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DictObject Find(int id)
        {
            List<DictObject> dictObjects = GetAll();
            return dictObjects.Find(x => x.Id == id);
        }
    }
}