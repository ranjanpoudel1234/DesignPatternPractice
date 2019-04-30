using System.Security.Cryptography.X509Certificates;

namespace Ranjan.DesignPattern.AbstractFactory.RealWorldExample
{
    public class AnimalWorld
    {
        Carnivore carnivore;
        Herbivore herbivore;

        public AnimalWorld(ContinentFactory continentFactory)
        {
            carnivore = continentFactory.CreateCarnivore();
            herbivore = continentFactory.CreateHerbivore();
        }
        public void DescribeAnimalBehavior()
        {
            carnivore.Eats(herbivore);     
            carnivore.EatsMeatALot();
        }
    }
}
