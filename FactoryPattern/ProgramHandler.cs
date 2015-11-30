using FactoryPattern.ConcreteClasses;
using FactoryPattern.Factories;

namespace FactoryPattern
{
    public class ProgramHandler
    {
        private IAnimalFactory animalFactory;

        public ProgramHandler(IAnimalFactory animalFactory)
        {
            this.animalFactory = animalFactory;
        }

        public IAnimal CreateAnimal()
        {
            return animalFactory.CreateAnimal();
        }
    }
}
