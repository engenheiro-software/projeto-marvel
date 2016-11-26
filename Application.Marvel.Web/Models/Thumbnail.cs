using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Application.Marvel.Web.Models
{
    [JsonObject]
    public class Thumbnail
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "path")]
        public string path { get; set; }
        [JsonProperty(PropertyName = "extension")]
        public string extension { get; set; }
    }
}