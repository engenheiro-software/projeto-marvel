using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Application.Marvel.Web.Models
{
    [JsonObject]
    public class Items
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "resourceURI")]
        public string resourceURI { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string type { get; set; }
    }
}