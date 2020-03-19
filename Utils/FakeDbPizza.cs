using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPModule5_2_Bo;

namespace TPModule5_2.Utils
{
    public class FakeDbPizza
    {
        private static FakeDbPizza _instance;
        static readonly object instanceLock = new object();

        private FakeDbPizza()
        {
            pizzas = this.GetPizzas();
        }

        public static FakeDbPizza Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new FakeDbPizza();
                    }
                }
                return _instance;
            }
        }

        private List<Pizza> pizzas;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
        }

        private List<Pizza> GetPizzas()
        {
            return new List<Pizza>
            {
                new Pizza{
                    Id=1, 
                    Nom = "Reine", 
                    Pate=Pizza.PatesDisponibles.FirstOrDefault(p => p.Id == 1), 
                    Ingredients= new List<Ingredient>{ 
                        Pizza.IngredientsDisponibles.FirstOrDefault(i=> i.Id== 5), 
                        Pizza.IngredientsDisponibles.FirstOrDefault(i => i.Id == 8) 
                    } 
                },
                 new Pizza{
                    Id=2,
                    Nom = "4 fromages",
                    Pate=Pizza.PatesDisponibles.FirstOrDefault(p => p.Id == 3),
                    Ingredients= new List<Ingredient>{
                        Pizza.IngredientsDisponibles.FirstOrDefault(i=> i.Id== 6),
                        Pizza.IngredientsDisponibles.FirstOrDefault(i => i.Id == 8)
                    }
                }
            };
        }
    }
}