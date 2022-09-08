using System;
using System.Collections.Generic;

namespace Circustrein
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train();

            Console.WriteLine("Hello!");
            Console.WriteLine("How many animals would you like to add?");
            int amountAnimals = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amountAnimals; i++)
            {
                Console.WriteLine("What is the size of the animal?");
                int animalSize = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Is the diet (C)arnivore or (H)erbivore?");

                bool IsCarnivore = true;
                string diet = Console.ReadLine().ToUpper();

                if (diet == "C")
                {
                    IsCarnivore = true;
                }
                else if (diet == "H")
                {
                    IsCarnivore = false;
                }
                train.AddAnimal(new Animal(animalSize, IsCarnivore));
            }

            train.AddAnimal(new Animal(3, true));
            train.AddAnimal(new Animal(5, false));
            train.AddAnimal(new Animal(3, false));
            train.AddAnimal(new Animal(3, false));
            train.AddAnimal(new Animal(3, true));
            train.AddAnimal(new Animal(1, false));
            train.AddAnimal(new Animal(1, false));
            train.AddAnimal(new Animal(3, true));
            train.AddAnimal(new Animal(5, false));
            train.AddAnimal(new Animal(1, false));
            train.AddAnimal(new Animal(1, true));
            train.AddAnimal(new Animal(5, false));
            train.AddAnimal(new Animal(5, false));
            train.AddAnimal(new Animal(3, true));
            train.AddAnimal(new Animal(1, true));
            train.AddAnimal(new Animal(3, false));
            train.AddAnimal(new Animal(3, false));
            train.AddAnimal(new Animal(3, true));
            train.AddAnimal(new Animal(1, false));




            train.Sorting();

            Console.WriteLine();

            foreach (Wagon wagon in train.Information())
            {
                Console.WriteLine(wagon.Information());
                Console.WriteLine("List of animals:");
                foreach(Animal animal in wagon.AnimalList)
                {
                    Console.WriteLine(animal.Information());
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}