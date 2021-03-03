using System;

namespace Pets
{
    class Cat : Pet  // Cat subclass.
    {
        // Cat constructor that calls the Pet Superclass
        public Cat(string catName, string catOwner, double catWeight) : base("Cat", catName, catOwner, catWeight)
        {
        }
        public string meow(int count) // Meow method.
        {
            string mew = "";
            for(int i = 0; i < count; i++)
            {
                mew = mew + "meow.";
            }
            return mew;
        }
    }
}
