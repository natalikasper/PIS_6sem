using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;



namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void AddDict(Phone phone);

        [OperationContract]
        void UpdDict(Phone phone);

        [OperationContract]
        void DelDict(Phone phone);

        [OperationContract]
        List<Phone> GetDict();
        
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "WcfServiceLibrary.ContractType".
    [DataContract]
    public class Phone
    {
        [Key]
        [DataMember]
        [Column(Order = 1)]
        public int Id { get; set; }
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public string Telephone { get; set; }
    }

    public class WCFService : IService1
    {
        readonly string path = "D:/7b.json";
        
        public List<Phone> GetDict()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Phone> contacts = JsonConvert.DeserializeObject<List<Phone>>(json);
                return contacts;
            }
        }

        public void AddDict(Phone phone)
        {

            var contacts = GetDict();
            contacts.Add(phone);
            var convertedJson = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            using (StreamWriter w = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                w.WriteLine(convertedJson);
            }
        }

        public void UpdDict(Phone phone)
        {
            var contacts = GetDict();
            Phone contact = contacts.Where(p => p.Id.Equals(phone.Id)).FirstOrDefault();
            contacts.Remove(contact);
            contacts.Add(phone);
            var convertedJson = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            using (StreamWriter w = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                w.WriteLine(convertedJson);
            }
        }

        public void DelDict(Phone phone)
        {
            var contacts = GetDict();
            Phone contact = contacts.Where(p => p.Id.Equals(phone.Id)).FirstOrDefault();
            contacts.Remove(contact);
            var convertedJson = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            using (StreamWriter w = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                w.WriteLine(convertedJson);
            }
        }
    }
}
