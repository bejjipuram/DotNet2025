using CAP2025.Day_20;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_45_M1Practice
{
    public class Animal
    {
        public string Name = "Animal";
    }
    public class Dog : Animal
    {
        public Dog()
        {
            Name = "Dog";
        }
    }
    public interface IProducer<out T>
    {
        T Produce();
    }
    public interface IConsumer<in T>
    {
        void Consume(T item);
    }
    public class DogProducer : IProducer<Dog>
    {
        public Dog Produce() => new Dog();
    }
    public class AnimalConsumer : IConsumer<Animal>
    {
        public void Consume(Animal item)
        {
            Console.WriteLine($"Consumed: {item.Name}");
        }
    }
    public class GenericVariance
    {
        public static void Main(string[] args)
        {
            IProducer<Animal> producer = new DogProducer();
            IConsumer<Dog> consumer = new AnimalConsumer();
            Use(producer, consumer);
        }

        public static void Use(IProducer<Animal> producer, IConsumer<Dog> consumer)
        {
            Animal animal = producer.Produce();
            if(animal is Dog dog)
            {
                consumer.Consume(dog);
            }
        }
    }
}
