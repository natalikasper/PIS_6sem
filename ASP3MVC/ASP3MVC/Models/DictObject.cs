﻿using Newtonsoft.Json;
namespace ASP3MVC.Models
{
    public class DictObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("FIO")]
        public string FIO { get; set; }
        [JsonProperty("Telephone")]
        public string Telephone { get; set; }
    }
}