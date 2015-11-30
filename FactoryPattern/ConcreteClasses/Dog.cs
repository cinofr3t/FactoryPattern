using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPattern.ConcreteClasses
{
    public class Dog : IAnimal
    {
        public string Speak()
        {
            return "Bark";
        }
    }
}
