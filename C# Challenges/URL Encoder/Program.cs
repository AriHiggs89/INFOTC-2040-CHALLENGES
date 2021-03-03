using System;
using System.Collections.Generic;

namespace URLEncoder
{
    class Program
    {
        static string formatString = "https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf";
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n\nWelcome to the URL Encoder\n\n");
                Console.WriteLine("Enter Project Name: ");
                string projectName = GetUserInput();
                Console.WriteLine("\nEnter Activity Name: ");
                string activityName = GetUserInput();

                Console.WriteLine(createURL(projectName, activityName));

                Console.WriteLine("\nWould you like to do another? (Y/N)");
            }while (Console.ReadLine().ToLower().Equals("y"));
        }
        static string GetUserInput()
        {
            string input = "";
            do
            {
                input = Console.ReadLine();
                if (checkValid(input)) return input;
                {
                    Console.Write("The input contains invalid characters. Enter again: ");
                }
            } while (true);
        }
        static bool checkValid(string input) // checks control characters
        {
            foreach (char character in input.ToCharArray())
            {
                if (character >= 0x00 && character <= 0x1F || character == 0x7F)
                {
                    return false;
                }
            }
            return true;
        } 
        static Dictionary<string, string> convertDict = new Dictionary<string, string>() // New dictionary instance.
        {
            {" ","%20"}, {"<","%3C"}, {">","%3E"}, {"#","%23"}, {"%","%25"}, {"'","%22"}, {";","%3B"}, {"/","%2F"}, 
            {"?","%3F"}, {":","%3A"}, {"=","%3D"}, {"@","%40"}, {"+","%2B"}, {"$","%24"}, {"{","%7B"}, {"|","%7C"},
            {"^","%5E"}, {"[","%2F"}, {"]","%2F"}
        };
        static string encodeString(string value) // Encodes string.
        {
            string newValue = "";
            foreach (char character in value.ToCharArray())
            {
            string characterString = character.ToString();
            newValue += convertDict.GetValueOrDefault(characterString, characterString);
            }
            return newValue;
        }

        static string createURL(string projectName, string activityName) // Assembles the URL
        {
           return String.Format(formatString, encodeString(projectName), encodeString(activityName));
        }
    }
}