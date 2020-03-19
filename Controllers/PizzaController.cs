﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule5_2.Utils;
using TPModule5_2_Bo;

namespace TPModule5_2.Controllers
{
    public class PizzaController : Controller
    {

        private static List<Pizza> pizzas;

        public PizzaController()
        {
            if (pizzas == null)
            {
                pizzas = FakeDbPizza.Instance.Pizzas;
            }
        }

        // GET: Pizza
        public ActionResult Index()
        {
            return View(pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null)
            {
                return View(pizza);
            }
            return RedirectToAction("Index");
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            List<Ingredient> ingredients = Pizza.IngredientsDisponibles;
            List<Pate> pates = Pizza.PatesDisponibles;

            return View();
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(Pizza nouvellePizza)
        {
            try
            {
                int maxId = pizzas.Max(p => p.Id);
                nouvellePizza.Id = maxId +1;
                pizzas.Add(nouvellePizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            Pizza pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null)
            {
                return View(pizza);
            }
            return RedirectToAction("Index");
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(Pizza pizza)
        {
            try
            {
                Pizza pizzaDb = pizzas.FirstOrDefault(p => p.Id == pizza.Id);
                pizzaDb.Nom = pizza.Nom;
                pizzaDb.Pate = pizza.Pate;
                pizzaDb.Ingredients = pizza.Ingredients;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null)
            {
                return View(pizza);
            }
            return RedirectToAction("Index");
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = pizzas.FirstOrDefault(p => p.Id == id);
                pizzas.Remove(pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
