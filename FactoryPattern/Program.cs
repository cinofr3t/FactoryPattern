using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FactoryPattern.Factories;
using FactoryPattern.ConcreteClasses;
using Ninject;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * TASK 1
             * Understanding factory method (Factory Pattern)
             * This is creating an interface that will be responsible for
             * creating the ideal factory needed given an instance
             * upon creating the right factory, the right object will be returned.
             * In this case, the IAnimalFactory returns an IAnimal (Dog or Lion) object
             * this is through CreateAnimal method of the IAnimalFactory(DogFactory ot LionFactory)
             **/
            // Factory Method.
            IAnimalFactory dogFactory = new DogFactory();
            IAnimal dog = dogFactory.CreateAnimal();

            IAnimalFactory lionFactory = new LionFactory();
            IAnimal lion = lionFactory.CreateAnimal();

            //---------------------------------------

            /**
             * Task 2
             * Manual Inversion of Control using Depedency Injection
             * Dependency injection allows applications to be loosely coupled
             * It helps to support plugable code.
             * The main objective is limit the use of the keyword 'new'
             * meaining creating a new instance of an object within another class
             * if an object is instanciated within another class, that forces dependencies
             * meaning the object that is responsible for instanciating another object is 
             * strongly dependent on the object to be instanciate.
             * this can make things difficult when new functionalities are to be added
             * object implementation can change
             * 
             * In the next 3 lines of code below,
             * the program handle is injected with a specific object type, 
             * this can change from DogFactory to LionFactory, 
             * but the implementation of ProgramHandle does not have to change,
             * it will know how to create an animal given the type of object it is provided
             * in the constructor. Ths is known as the Constructor Injection 
             * (There are other types such as Property Injection or Method Injection)
             **/
            var programHandler = new ProgramHandler(new DogFactory());
            IAnimal manuallyCreatedAnimalDependencyInjection = programHandler.CreateAnimal();


            /**
             * Task 3
             * Using DI container (NUnit)
             * We use DI container's so we dont have to keep writting manual DI code
             * First we create a our bindings, I have done this in ProgramModule
             * by binding the interface to the concrete class.
             * Then get the right interface of the object passed into the kernel line 73
             * the returned object is what we use in calling CreateAnimal method.
             */
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IAnimalFactory kernelAnimalFactory = kernel.Get<DogFactory>();
            var programHanderFromKernel = new ProgramHandler(kernelAnimalFactory);
            IAnimal animalFromKernel = programHanderFromKernel.CreateAnimal();

            /**
             * Rlection
             * This is just a basic explanation of reflection,
             * it is when an object checks it's own metadata for information
             * in order to be able to carry out some sort of behaviour.
             * In this case, each objec is reflection of it's self
             * so that we can use the type in a string to be displayed in our output.
             */
            WriteLine(dog.GetType(), dog);
            WriteLine(lion.GetType(), lion);
            WriteLine(manuallyCreatedAnimalDependencyInjection.GetType(),
                manuallyCreatedAnimalDependencyInjection);
            WriteLine(animalFromKernel.GetType(), animalFromKernel);

            Console.ReadLine();
        }

        private static void WriteLine(Type objectType, IAnimal animal)
        {
            Console.WriteLine("{0} = {1}", objectType, animal.Speak());
        }
    }
}
