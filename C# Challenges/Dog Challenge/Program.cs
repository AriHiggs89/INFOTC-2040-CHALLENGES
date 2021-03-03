using System;

namespace Dog
{
    public class Dog
    {
        //Class members.
        //
        //Property.
        public string name;
        public string owner;
        public int age;
        public int displayYear;
        public int woof;
        public Gender gender;

        public Dog(string dogName, string dogOwner, int dogAge, Gender dogGender) //constructor
        {
        name = dogName;
        owner = dogOwner;
        age = dogAge;
        gender = dogGender;
        }

        public void Bark(int dogWoof) //woof loop
        {   
            woof = dogWoof;
            for(int i = 0; i < dogWoof; i++)
            {
                Console.Write("Woof!");
            }
            
        }
        public string GetTag()
        {
            string displayYear = ""; //year or years logic

            if (age <= 1)
            {
                displayYear = "year";
            }
            else
            {
                displayYear = "years";
            }

            string hisHerPronoun = ""; // his or her logic

            if (gender == Gender.Male)
            {
                hisHerPronoun = "His";
            }
            else
            {
                hisHerPronoun = "Her";
            }
            
            string heShePronoun = ""; //he or she logic
            if (gender == Gender.Male)
            {
                heShePronoun = "he";
            }
            else
            {
                heShePronoun = "she";
            }

            return $"\nIf lost, call {owner}. {hisHerPronoun} name is {name} and {heShePronoun} is {age} {displayYear} old.";
        }
        public enum Gender
        {
            Male,
            Female
        }
         

        static void Main() //create object instance
        {
            Dog dog1 = new Dog("Coda", "Justin", 1, Gender.Male);
            dog1.Bark(5);
            Console.WriteLine(dog1.GetTag());


            Dog dog2 = new Dog("Mavis", "Ariana", 13, Gender.Female);
            dog2.Bark(2);
            Console.WriteLine (dog2.GetTag());
        }
    }
}
