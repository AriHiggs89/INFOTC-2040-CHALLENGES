using System;

namespace Pets
{
    public class Pet
    {
        public string type {set; get;}
        public string name {set; get;}
        public string owner {set; get;}
        public double weight {set; get;}

        public Pet(string petType, string petName, string ownerName, double petWeight) // Pet constructor.
        {
            type = petType;
            name = petName;
            owner = ownerName;
            weight = petWeight;
        }
        public string getTag()
        {
            return $"If lost, call {owner}.";
        }
    }
}