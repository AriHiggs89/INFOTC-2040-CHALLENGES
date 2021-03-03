using System;

namespace Pets
{
    class Dog : Pet  // Dog subclass.
    {
        // Dog constructor that calls Pet Superclass.
        public Dog(string dogName, string dogOwner, double dogWeight) : base("Dog", dogName, dogOwner, dogWeight)
        {
        }
        public string bark(int count) // Bark method.
        {   
            string woof = "";
            for(int i = 0; i < count; i++)
            {
                woof = woof + "bark!";
            }
            return woof;
        }
    }
}