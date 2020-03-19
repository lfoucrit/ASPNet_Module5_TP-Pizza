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
        public PizzaVm()
        {

        }
        public List<Ingredient> ingredients = new List<Ingredient>();
        public List<Pate> pates = new List<Pate>();
        public void setIngredients(List<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }
        public void setPates(List<Pate> pates)
        {
            this.pates = pates;
        }

        public Pizza Pizza { get; set; }
        
        public List<int> selectedIngredients { get; set; } = new List<int>();

        public int selectedPate { get; set; }

        public void setPizzaIngredients(List<Ingredient> ingredients)
        {
            this.Pizza.Ingredients = ingredients;
        }

        public void setPizzaPate(Pate pate)
        {
            this.Pizza.Pate = pate;
        }
    }
}