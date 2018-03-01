using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class UserController : Controller
    {
        static List<User> listInUser = new List<User>
        {
            new User {id = 1, nome = "Matheus Antonio SIlva", email = "matheus@mail.com", cpf = "1111111111"},
            new User {id = 2, nome = "Larissa Maria dos Santos Fonseca", email = "lari@mail.com", cpf = "2222222"},
        };
        // GET: User
        public ActionResult Index()
        {
            return View(listInUser);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(listInUser.FirstOrDefault(x => x.id == id ));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                listInUser.Add(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = listInUser.FirstOrDefault(x => x.id == id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("id, nome, cpf, email")] User user)
        {
            try
            {
                if(id != user.id)
                {
                    return NotFound();
                }
                if(ModelState.IsValid)
                {
                    var userTemp = listInUser.FirstOrDefault(x => x.id == id);
                    if(userTemp != null)
                    {
                        userTemp.id = user.id;
                        userTemp.nome = user.nome;
                        userTemp.cpf = user.cpf;
                        userTemp.email = user.email;
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = listInUser.FirstOrDefault(x => x.id == id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var user = listInUser.FirstOrDefault(x => x.id == id);
                listInUser.Remove(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}