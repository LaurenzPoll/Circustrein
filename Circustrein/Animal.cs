using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    internal class Animal
    {
        private int size;
        private bool isCarnivore;

        public Animal(int size, bool isCarnivore)
        {
            this.size = size;
            this.isCarnivore = isCarnivore;
        }

        public int Size { get { return this.size; } }
        public bool IsCarnivore { get { return this.isCarnivore; } }
        public string Information()
        {
            string diet;
            if (isCarnivore)
            {
                diet = "Carnivore";
            }
            else
            {
                diet = "Herbivore";
            }

            return "Size: " + this.size.ToString() + "  Diet: " + diet;
        }
    }
}
