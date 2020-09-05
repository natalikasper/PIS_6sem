using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
namespace ASP3MVC.Models
{
    public class DictObjectContext
    {
        string JSONPath = "F://6 семестр//ПИС//ASP7//ASP7//user.json";
        public List<DictObject> GetAll()
        {
            List<DictObject> dictObjects = JsonConvert.DeserializeObject<List<DictObject>>(File.ReadAllText(JSONPath, Encoding.UTF8));
            return dictObjects;
        }
        public string GetAllJSON()
        {
            return File.ReadAllText(JSONPath, Encoding.UTF8);
        }
        public bool Add(DictObject dictObject)
        {
            try
            {
                List<DictObject> dictObjects = GetAll();
                dictObjects.Add(dictObject);
                File.WriteAllText(JSONPath, JsonConvert.SerializeObject(dictObjects));
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
                File.WriteAllText(JSONPath, JsonConvert.SerializeObject(dictObjects));
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
                File.WriteAllText(JSONPath, JsonConvert.SerializeObject(dictObjects));
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