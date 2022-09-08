using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    internal class Train
    {
        private int points;

        private Wagon wagon;
        private List<Wagon> wagonList = new List<Wagon>();

        //temporary list for animals in wagon
        //private List<Animal> tempAnimal = new List<Animal>();

        //storing all the animals
        private List<Animal> animalList = new List<Animal>();



        public void AddAnimal(Animal animal)
        {
            animalList.Add(animal);
        }


        public void Sorting()
        {
            int wagonNumber = 1;

            // check if animal list is empty. if not keep repeating until all animals are placed in wagon
            while (animalList.Count > 0)
            {               
                foreach (Animal animal in animalList.ToList())
                {
                    //Get all Carnivores size 5 out of list
                    if (animal.Size == 5 && animal.IsCarnivore)
                    {
                        AddWagon(new Wagon(wagonNumber, animal, animal.Size));

                        animalList.Remove(animal);
                        wagonNumber++;
                    }
                    //Get all Herbivores size 5 out of list
                    else if (animal.Size == 5 && !animal.IsCarnivore)
                    {
                        AddWagon(new Wagon(wagonNumber, animal, animal.Size));

                        animalList.Remove(animal);
                        wagonNumber++;
                    }
                }

                foreach(Wagon wagon in wagonList)
                {
                    if(wagon.ContainsHerbivore5())
                    {
                        foreach(Animal animal in animalList.ToList())
                        {
                            //adding herbivore size 3
                            if (animal.Size == 3 && !animal.IsCarnivore && !wagon.ContainsDangerousCarnivore(animal.Size))
                            {
                                if (wagon.IsSpace(animal.Size))
                                {
                                    wagon.AddAnimal(animal);
                                    animalList.Remove(animal);
                                }
                            }
                            //adding carnivore size 3
                            else if (animal.Size == 3 && animal.IsCarnivore && wagon.CanCarnivoreFit(animal.Size))
                            {
                                if(wagon.IsSpace(animal.Size))
                                {
                                    wagon.AddAnimal(animal);
                                    animalList.Remove(animal);
                                }
                            }

                            //adding herbivore size 1
                            else if (animal.Size == 1 && !animal.IsCarnivore && !wagon.ContainsDangerousCarnivore(animal.Size))
                            {
                                if (wagon.IsSpace(animal.Size))
                                {
                                    wagon.AddAnimal(animal);
                                    animalList.Remove(animal);
                                }
                            }
                            //adding carnivore size 1
                            else if (animal.Size == 1 && animal.IsCarnivore && wagon.CanCarnivoreFit(animal.Size))
                            {
                                if (wagon.IsSpace(animal.Size))
                                {
                                    wagon.AddAnimal(animal);
                                    animalList.Remove(animal);
                                }
                            }
                        }
                    }

                    if (wagon.ContainsHerbivore3())
                    {
                        foreach (Animal animal in animalList.ToList())
                        {
                            //adding herbivore size 3
                            if (animal.Size == 3 && !animal.IsCarnivore && !wagon.ContainsDangerousCarnivore(animal.Size))
                            {
                                if (wagon.IsSpace(animal.Size))
                                {
                                    wagon.AddAnimal(animal);
                                    animalList.Remove(animal);
                                }
                            }
                            //adding carnivore size 3
                            else if (animal.Size == 3 && animal.IsCarnivore && wagon.CanCarnivoreFit(animal.Size))
                            {
                                if (wagon.IsSpace(animal.Size))
                                {
                                    wagon.AddAnimal(animal);
                                    animalList.Remove(animal);
                                }
                            }

                            //adding herbivore size 1
                            else if (animal.Size == 1 && !animal.IsCarnivore && !wagon.ContainsDangerousCarnivore(animal.Size))
                            {
                                if (wagon.IsSpace(animal.Size))
                                {
                                    wagon.AddAnimal(animal);
                                    animalList.Remove(animal);
                                }
                            }
                            //adding carnivore size 1
                            else if (animal.Size == 1 && animal.IsCarnivore && wagon.CanCarnivoreFit(animal.Size))
                            {
                                if (wagon.IsSpace(animal.Size))
                                {
                                    wagon.AddAnimal(animal);
                                    animalList.Remove(animal);
                                }
                            }
                        }
                    }
                }

                //Place animals size 3 in wagons
                foreach (Animal animal in animalList.ToList())
                {
                    bool herbivoreWagon = false;
                    bool carnivoreWagon = false;

                    //Get one Carnivore size 3 out of list
                    if (animal.Size == 3 && animal.IsCarnivore && !herbivoreWagon)
                    {

                        AddWagon(new Wagon(wagonNumber, animal, animal.Size));

                        animalList.Remove(animal);
                        wagonNumber++;
                        carnivoreWagon = true;
                    }

                    //Get one Herbivores size 3 out of list
                    else if (animal.Size == 3 && !animal.IsCarnivore && !carnivoreWagon)
                    {

                        AddWagon(new Wagon(wagonNumber, animal, animal.Size));

                        animalList.Remove(animal);
                        wagonNumber++;
                        herbivoreWagon = true;
                    }

                    if(herbivoreWagon && carnivoreWagon)
                    {
                        break;
                    }
                }

                //check if there are only carnivores left. When true create seperate wagons for them
                if(animalList.All(c => c.IsCarnivore == true))
                {
                    bool RunOnceMore = false;

                    if (RunOnceMore)
                    {
                        foreach (Animal animal in animalList.ToList())
                        {
                            AddWagon(new Wagon(wagonNumber, animal, animal.Size));

                            animalList.Remove(animal);
                            wagonNumber++;
                        }
                    }
                    else
                    {
                        RunOnceMore = true;
                    }
                }
            }
        }




        public void AddWagon(Wagon wagon)
        {
            wagonList.Add(wagon);
        }

        public List<Wagon> Information()
        {
            return wagonList;
        }
    }
}
