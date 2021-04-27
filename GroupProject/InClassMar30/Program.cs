using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //USE THIS STATMENT ANY TIME WE NEED TO PERFORM FILE INPUT OR OUTPUT
namespace InClassMar30
{
    class Program
    {
        //a comma seperated value (CSV) file appears like below
        //David Jones,71
        //Adam Wiles, 47
        //etc

        //This is the name of our input file for this project
        static string myInputFile = "StudentGrades.csv";
        //These are the lists where we will store our file information
        static List<string> studentNames = new List<string>();
        static List<double> studentGrades = new List<double>();
        static void Main(string[] args)
        {
            if (ReadfileIn())
            {
                Console.WriteLine("The average grade in the class is {0:f1}", studentGrades.Average());
                DisplayBestStudent();
                DisplayWorstStudent();
            }
            else
            {
                Console.WriteLine("Something failed. Fix error and try again.");
            }
            Console.ReadLine();

        }
        static bool ReadfileIn()
        {

            try { 
            //Read all the lines in the file
            string[] lines = File.ReadAllLines(myInputFile);
            //go thorugh each of the lines of input
            foreach (string curLine in lines)
            {
                string[] cells = curLine.Split(',');
                if (cells[0].Trim().ToUpper() == "STUDENT NAME")
                {
                    //skip header and skip to next line
                }
                else
                {
                    studentNames.Add(cells[0]);
                    studentGrades.Add(Convert.ToDouble(cells[1]));
                }
            }
            return true;
        } // end of try
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("The file is not found where expected. Please double check your file and try again.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("File error: {0}", ex.GetType());
                return false;
            }
            
        }
        static void DisplayBestStudent()
        {
            //find the max grade out of all grades
            double max = studentGrades.Max();
            //find the index of this beset grade
            int index = studentGrades.IndexOf(max);
            Console.WriteLine("Student {0} has the best grade of {1:f1}", studentNames[index], studentGrades[index]);
        }
        static void DisplayWorstStudent()
        {
            //find the max grade out of all grades
            double min = studentGrades.Min();
            //find the index of this beset grade
            int index = studentGrades.IndexOf(min);
            Console.WriteLine("Student {0} has the lowest grade of {1:f1}", studentNames[index], studentGrades[index]);
        }
    }
}
