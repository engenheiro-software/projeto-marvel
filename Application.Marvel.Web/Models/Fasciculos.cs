using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Marvel.Web.Models
{
    [JsonObject]
    public class Fasciculos
    {
        [Key]        
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string title { get; set; }
        [JsonProperty(PropertyName = "issueNumber")]
        public int issueNumber { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }
        [JsonProperty(PropertyName = "thumbnail")]
        public Thumbnail thumbnail { get; set; }
    }
}