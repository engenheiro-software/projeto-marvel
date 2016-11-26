using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Application.Marvel.Web.Models;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Application.Marvel.Web.Controllers
{
    public class TelaInicialController : Controller
    {
        HttpClient client = new HttpClient();

        public TelaInicialController()
        {
            client.BaseAddress = new Uri("http://gateway.marvel.com/v1/public/characters");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Enviar(Usuario usuario)
        {            
            if (string.IsNullOrEmpty(usuario.Private_Key) && string.IsNullOrEmpty(usuario.Public_Key))
                throw new Exception("Os 'private_key' e 'public_key' não podem ser vazio.");

            Character _characters = new Character();
            _characters.thumbnail = new Thumbnail();
            List<Items> _items = new List<Items>();
            Comics _comics = new Comics();
            _comics.items = _items;
            _characters.comics = _comics;

            List<Character> _lst = new List<Character>();
            _lst.Add(_characters);            

            var ts = "1";
            var privateKey = usuario.Private_Key.ToString();
            var publicKey = usuario.Public_Key.ToString();
            var hash = "";
            var source = ts + privateKey + publicKey;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = Hash.GetMd5Hash(md5Hash, source);
            }
            var url = "?ts=" + ts + "&apikey=" + publicKey + "&hash=" + hash;

            Session["usuario"] = usuario;

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                int inicio = json.IndexOf("[{\"id\":");
                var str = json.Substring(inicio);
                int fim = str.IndexOf("}}");
                var str2 = str.Substring(0, fim);

                _lst = JsonConvert.DeserializeObject<List<Character>>(str2);
            }

            Session["lista"] = _lst;            

            //return View("TelaPrincipal", _lst);
            return RedirectToAction("Index", "TelaPrincipal");            
        }
    }
}