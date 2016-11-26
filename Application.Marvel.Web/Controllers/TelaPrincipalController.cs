using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Marvel.Web.Models;
using PagedList;
using System.Security.Cryptography;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Application.Marvel.Web.Controllers
{
    public class TelaPrincipalController : Controller
    {
        public int characterPorPagina = 5;

        public ActionResult Index(int pagina = 1)
        {

            List<Character> lista = new List<Character>();
            lista = Session["lista"] as List<Character>;

            CharacterViewModel model = new CharacterViewModel()
            {
                characters = from num in lista
                       .Skip((pagina - 1) * characterPorPagina)
                       .Take(characterPorPagina)
                             select num,

                paginacao = new Paginacao()
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = characterPorPagina,
                    ItensTotal = lista.Count()
                }
            };

            return View("TelaPrincipal", model);
        }
    }
}