using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Marvel.Web.Models
{
    public class CharacterViewModel
    {
        public IEnumerable<Character> characters { get; set; }
        public Paginacao paginacao { get; set; }
    }
}