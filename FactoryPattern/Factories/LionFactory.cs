using FactoryPattern.ConcreteClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPattern.Factories
{
    class LionFactory : IAnimalFactory
    {
        private IAnimal _animal;

        public IAnimal animal
        {
            get { return _animal; }
            set { _animal = value; }
        }

        public IAnimal CreateAnimal()
        {
            IAnimal animal = new Lion();
            return animal;
        }
    }
}
