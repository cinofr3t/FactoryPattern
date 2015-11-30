using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryPattern.ConcreteClasses;

namespace FactoryPattern.Factories
{
    class DogFactory : IAnimalFactory
    {
        private IAnimal _animal;

        public IAnimal animal
        {
            get { return _animal; }
            set { _animal = value; }
        }

        public IAnimal CreateAnimal()
        {
            IAnimal animal = new Dog();
            
            return animal;
        }
    }
}
