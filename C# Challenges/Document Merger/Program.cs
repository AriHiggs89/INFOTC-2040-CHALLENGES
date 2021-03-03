using System;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\nD O C U M E N T    M E R G E R ");

                // Takes user input and verifies first file exists.
                Console.WriteLine("\nEnter the name of the first file (including .txt): ");
                Console.WriteLine();                
                string firstFile = Console.ReadLine();
                firstFile = verify(firstFile);

                // Takes user input and verifies second file exists.
                Console.WriteLine("\nEnter the name of the second file (including .txt): ");
                Console.WriteLine();
                string secondFile = Console.ReadLine();
                secondFile = verify(secondFile);

                // Merge file names and appends .txt extension.
                string mergedFileName = firstFile.Substring(0, firstFile.Length - 4) + secondFile.Substring(0, secondFile.Length - 4) + ".txt";
        
                // Reads & writes first and second file to the new merged file
                int characterCount = readFileText(mergedFileName, firstFile, secondFile);

                // Save success.
                Console.Out.WriteLine($"\n{mergedFileName} was successfully saved. The document contains {characterCount} characters.");

                Console.WriteLine("\nWould you like to do another? (Y/N)");
            }
            while (Console.ReadLine().ToLower().Equals("y"));
            
            Console.WriteLine("\nThank you for using Document Merger. Goodbye!\n");
        }

        static bool checkForMissingFile(string input) // checks if file exists in directory
        {
            if (!File.Exists(input)) return true;
            {
                return false;
            }
        }

        static string verify(string fileName)
        {
            if (!checkForMissingFile(fileName))
            {
                return fileName;
            }
            else
            {
                string input = "";
                bool repeat = false;
                do
                {
                    input = Console.ReadLine();
                    if (checkForMissingFile(input))
                    {
                        Console.WriteLine("\nFile not found. Please re-enter file name: ");
                        repeat = true;
                    }
                    else
                    {
                        repeat = false;
                    }
                } while (repeat);
                return input;
            }
        }

        static int readFileText(string mergeFile, string file1, string file2)
        {
            // Initializes streams to null
            StreamWriter mergedFile = null;
            StreamReader fileOne = null;
            StreamReader fileTwo = null;
            int count = 0;

            try
            {
                mergedFile = new StreamWriter(mergeFile);
                fileOne = new StreamReader(file1);
                fileTwo = new StreamReader(file2);

                string line = fileOne.ReadLine();  // Reads first line of file one.
                while (line != null)              // Continues reading and writing first file to the new merged file.
                {
                    mergedFile.WriteLine(line);
                    count += line.Length;
                    line = fileOne.ReadLine();
                }

                line = fileTwo.ReadLine();   // Reads first line of file two.
                while (line != null)        //  Continues reading and writing first file to the new merged file.
                {
                    mergedFile.WriteLine(line);
                    count += line.Length;
                    line = fileTwo.ReadLine();
                }
            }
            catch (Exception e) // Prints the  message if there is an exception.
            {
                Console.WriteLine(e.Message); 
            }
            finally // Closes files when end of file is reached
            {
                if (mergedFile != null)
                {
                    mergedFile.Close(); // Close merged file.
                }

                if (fileOne != null)
                {
                    fileOne.Close(); // Close first file.
                }

                if (fileTwo != null)
                {
                    fileTwo.Close(); // Close second file.
                }
            }
            return count; // Returns the character count in the new merged file.
        }
    }
}
