using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace ASP3MVC.Models
{
    public class DictObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("Surname")]
        public string Surname { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }
    }
}