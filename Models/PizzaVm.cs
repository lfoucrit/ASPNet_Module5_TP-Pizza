using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule5_2_Bo;

namespace TPModule5_2.Models
{
    public class PizzaVm
    {
        private Pizza pizza;

        public Pizza GetPizza()
        {
            return pizza;
        }

        public void SetPizza(Pizza value)
        {
            pizza.Nom = value.Nom;
            pizza.Id = value.Id;
            //pizza.Pate = IdSelectedPate;
            //pizza.Ingredients = IdSelectedIngredients;
        }

        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();
        public int IdSelectedPate { get; set; }
        public List<int> IdSelectedIngredients { get; set; } = new List<int>();
    }
}