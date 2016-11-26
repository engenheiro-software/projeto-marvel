using Application.Marvel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace Application.Marvel.Web.Controllers
{
    public class TeladeDetalheController : Controller
    {
        HttpClient client = new HttpClient();

        public TeladeDetalheController()
        {
            {                
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        // GET: TeladeDetalhe
        public ActionResult Index(int id)
        {
            Character _characters = new Character();
            _characters.thumbnail = new Thumbnail();
            List<Items> _items = new List<Items>();
            Comics _comics = new Comics();
            _comics.items = _items;
            _characters.comics = _comics;            
            List<Character> _lst = new List<Character>();
            _lst.Add(_characters);

            Fasciculos _fasciculos = new Fasciculos();
            _fasciculos.thumbnail = new Thumbnail();
            List<Fasciculos> _lstFasciculos = new List<Fasciculos>();
            _lstFasciculos.Add(_fasciculos);
            List<Fasciculos> _lstFasciculos2 = new List<Fasciculos>();           

            var usuario = Session["usuario"] as Usuario;            
            
            var ts = "1";
            var privateKey = usuario.Private_Key.ToString();
            var publicKey = usuario.Public_Key.ToString();
            var hash = "";
            var source = ts + privateKey + publicKey;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = Hash.GetMd5Hash(md5Hash, source);
            }
            var url = "http://gateway.marvel.com/v1/public/characters?ts=" + ts + "&apikey=" + publicKey + "&hash=" + hash + "&id=" + id;

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
            _characters = _lst[0];

            var urlItem = "";
            
            foreach (var item in _characters.comics.items)
            {
                urlItem = item.resourceURI.ToString() + "?ts=" + ts + "&apikey=" + publicKey + "&hash=" + hash;
                
                response = client.GetAsync(urlItem).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    int inicio = json.IndexOf("[{\"id\":");
                    var strInicio = json.Substring(inicio);
                    int fim = strInicio.IndexOf("]}}");
                    var strFim = strInicio.Substring(0, (fim+1));

                    _lstFasciculos = JsonConvert.DeserializeObject<List<Fasciculos>>(strFim);

                    _lstFasciculos2.Add(_lstFasciculos[0]);
                }                
            }

            TempData["fasciculos"] = _lstFasciculos2;                                  

            return View("TeladeDetalhe", _characters);
        }
    }
}