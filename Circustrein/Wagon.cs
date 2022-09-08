using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    internal class Wagon
    {
        private int id;
        private int freeSpace = 10;
        private List<Animal> animalList = new List<Animal>();

        public Wagon(int id, Animal animal, int space)
        {
            this.id = id;
            this.animalList.Add(animal);
            this.freeSpace -= space;
            
        }

        //public int FreeSpace { get { return this.freeSpace; } }

        public List<Animal> AnimalList { get { return this.animalList; } }

        public bool IsSpace(int size)
        {
            if (this.freeSpace - size >= 0) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsHerbivore5()
        {
            foreach(Animal animal in this.animalList)
            {
                if(animal.Size == 5 && !animal.IsCarnivore)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsHerbivore3()
        {
            foreach (Animal animal in this.animalList)
            {
                if (animal.Size == 3 && !animal.IsCarnivore)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsDangerousCarnivore(int size)
        {
            foreach (Animal animal in this.animalList)
            {
                if (animal.Size >= size && animal.IsCarnivore)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanCarnivoreFit(int size)
        {
            bool canCarnivoreFit = false;

            foreach (Animal animal in this.animalList)
            {
                if (animal.Size > size && !animal.IsCarnivore)
                {
                    canCarnivoreFit = true;
                }
                else
                {
                    canCarnivoreFit = false;
                    break;
                }
            }

            return canCarnivoreFit;
        }

        public void AddAnimal(Animal animal)
        {
            animalList.Add(animal);

            freeSpace -= animal.Size;
        }


        public string Information()
        {
            return "Wagon#" + id.ToString() + " Animals: " + animalList.Count.ToString() + " Freespace: " + this.freeSpace.ToString();
        }
    }
}
