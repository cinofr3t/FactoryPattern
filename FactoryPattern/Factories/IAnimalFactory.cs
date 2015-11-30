using FactoryPattern.ConcreteClasses;
namespace FactoryPattern.Factories
{
    public interface IAnimalFactory
    {
        IAnimal animal { get; set; }

        //Returns an instance of the concrete class' interface
        IAnimal CreateAnimal();
    }
}