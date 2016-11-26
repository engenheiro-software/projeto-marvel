using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Application.Marvel.Web.Models
{
    [JsonObject]
    public class Comics
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "available")]
        public int available { get; set; }
        [JsonProperty(PropertyName = "collectionURI")]
        public string collectionURI { get; set; }
        [JsonProperty(PropertyName = "items")]
        public List<Items> items { get; set; }
        [JsonProperty(PropertyName = "returned")]
        public int returned { get; set; }
    }
}