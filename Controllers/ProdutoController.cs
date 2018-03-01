using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class ProdutoController : Controller
    {
        static List<Produto> listaDeProdutos = new List<Produto>
        {
            new Produto {id = 1, nome = "Tomato soup", categoria = "Groceries", preco = 1},
            new Produto {id = 2, nome = "You You", categoria = "Toys", preco = 3.78M},
            new Produto {id = 3, nome = "Hammer", categoria = "Hardware", preco = 16.99M}
        };

        // GET: Produto
        public ActionResult Index()
        {
            return View(listaDeProdutos);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            return View(listaDeProdutos.FirstOrDefault(x => x.id == id));
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            try
            {
                // TODO: Add insert logic here
                listaDeProdutos.Add(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = listaDeProdutos.FirstOrDefault(x => x.id == id);
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("id, nome, categoria, preco")] Produto produto)
        {
            try
            {
               if(id != produto.id)
                {
                    return NotFound();
                }
               if (ModelState.IsValid)
                {
                    var produtoTemp = listaDeProdutos.FirstOrDefault(x => x.id == id);
                    if(produtoTemp != null)
                    {
                        produtoTemp.categoria = produto.categoria;
                        produtoTemp.nome = produto.nome;
                        produtoTemp.preco = produto.preco;
                        produtoTemp.id = produto.id;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = listaDeProdutos.FirstOrDefault(x => x.id == id);
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                
                var produto = listaDeProdutos.FirstOrDefault(x => x.id == id);
                listaDeProdutos.Remove(produto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}