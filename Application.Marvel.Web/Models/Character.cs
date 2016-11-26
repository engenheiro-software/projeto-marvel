using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Application.Marvel.Web.Models
{
    [JsonObject]
    public class Character
    {
        [Key]
        [JsonProperty(PropertyName = "id")]        
        public int id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }
        [JsonProperty(PropertyName = "modified")]
        public string modified { get; set; }
        [JsonProperty(PropertyName = "thumbnail")]
        public Thumbnail thumbnail { get; set; }
        [JsonProperty(PropertyName = "resourceURI")]
        public string resourceURI { get; set; }
        [JsonProperty(PropertyName = "comics")]
        public Comics comics { get; set; }        
    }
}