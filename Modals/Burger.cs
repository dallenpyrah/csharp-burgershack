using System;

namespace burgershack.Modals
{
    public class Burger
    {
        public Burger(int patties, int price, string description, string location, int calories)
        {
            Patties = patties;
            Price = price;
            Description = description;
            Location = location;
            Calories = calories;
        }

        public int Patties { get; set; }

        public int Price { get; set ;}

        public string Description { get; set; }

        public string Location { get; set; }

        public int Calories { get; set; }

        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}