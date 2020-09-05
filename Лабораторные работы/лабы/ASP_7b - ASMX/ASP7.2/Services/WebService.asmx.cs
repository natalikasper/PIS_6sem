using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace ASP7._2.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]


    public class Phone
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("FIO")]
        public string FIO { get; set; }
        [JsonProperty("Telephone")]
        public string Telephone { get; set; }
    }



    public class WebService : System.Web.Services.WebService
    {

        string JSONPath = "D://7b.json";

        [WebMethod]
        public List<Phone> GetDict()
        {
            IEnumerable<Phone> dictObjects = JsonConvert.DeserializeObject<IEnumerable<Phone>>(File.ReadAllText(JSONPath, Encoding.UTF8));
            return dictObjects.ToList();
        }


        [WebMethod]
        public void AddDict(Phone phone)
        {
            List<Phone> dictObjects = GetDict();
            dictObjects.Add(phone);
            File.WriteAllText(JSONPath, JsonConvert.SerializeObject(dictObjects));
        }


        [WebMethod]
        public void DelDict(Phone phone)
        {
            List<Phone> dictObjects = GetDict();
            dictObjects.Remove(dictObjects.Find(x => x.Id == phone.Id));
            File.WriteAllText(JSONPath, JsonConvert.SerializeObject(dictObjects));
        }

        [WebMethod]
        public void UpdDict(Phone phone)
        {
            List<Phone> dictObjects = GetDict();
            foreach (Phone dict in dictObjects)
            {
                if (dict.Id == phone.Id)
                {
                    dict.FIO = phone.FIO;
                    dict.Telephone = phone.Telephone;
                }
            }
            File.WriteAllText(JSONPath, JsonConvert.SerializeObject(dictObjects));
        }

    }
}
