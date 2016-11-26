using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Application.Marvel.Web.Models;

namespace Application.Marvel.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testandopaginacao()
        {
            //Arrange
            HtmlHelper html = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 20,
                ItensTotal = 10
            };

            Func<int, string> paginaUrl = x => "Pagina" + x;

            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert

        }
    }
}
