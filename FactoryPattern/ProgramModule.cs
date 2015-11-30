using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryPattern.ConcreteClasses;
using FactoryPattern.Factories;
using Ninject.Modules;

namespace FactoryPattern
{
    class ProgramModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnimalFactory>().To<DogFactory>();
            Bind<IAnimalFactory>().To<LionFactory>();
            Bind<IAnimal>().To<Dog>();
            Bind<IAnimal>().To<Lion>();
        }
    }
}
