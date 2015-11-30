using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPattern.ConcreteClasses
{
    public class Lion : IAnimal
    {
        public string Speak()
        {
            return "Roarrrr";
        }
    }
}
