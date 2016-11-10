using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1_Lab8_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Batting Average Calculator!");

            bool Open = true;
            do
            {
                Console.WriteLine(Environment.NewLine + "Please enter the number of times at bat:");
                string NumberOfAtBats = Console.ReadLine();
                int NumberOfAtBatsInt = Convert.ToInt32(NumberOfAtBats);
                int[] NumberOfBatsArray = new int[NumberOfAtBatsInt];
                
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Each bat has the following results: \nOut=0 \nSingle = 1 \nDouble=2 \nTriple=3 \nHome Run=4");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Please enter the result for each time at-bat, using numbers 0-4, then press enter:");
                Console.WriteLine(Environment.NewLine);
                
                for (int i = 0; i < NumberOfAtBatsInt; i++)
                {
                    Console.Write("Result for at bat " + (i + 1) + ": ");
                    string BattingResult = Console.ReadLine();
                    int BattingResultInt;
                    
                    bool isValid = MethodGetValidInput(BattingResult, out BattingResultInt);
                    if (!isValid)
                    {
                        i--;
                    }
                    else
                    {
                        NumberOfBatsArray[i] = BattingResultInt;
                    }
                }

                Console.WriteLine(Environment.NewLine);
                double AverageBats = FindAverage(NumberOfBatsArray);
                Console.WriteLine("Batting Average is: " + AverageBats.ToString("0.000"));
                double SluggingPercentage = FindSluggerPercentage(NumberOfBatsArray);
                Console.WriteLine("The Slugging Percentage is:  " + SluggingPercentage.ToString("0.000"));
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Would you like to play again? Yes or No?");
                string Answer = Console.ReadLine();

                if (Answer.ToLower() != "yes" && Answer.ToLower() != "y")
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Ok. Press any key to exit");
                    Console.ReadKey();
                    Open = false;
                }
            }
            while (Open);
        }


        static bool MethodGetValidInput(string stringResults, out int Result)
        {
            if (stringResults == "0" || stringResults == "1" || stringResults == "2" || stringResults == "3" || stringResults == "4")
            {
                Result = int.Parse(stringResults);
                return true;
            }
            else
            {
                Result = -1;
                Console.WriteLine("Entry does not exist, please write a number 0-4.");
                return false;
            }
        }

        static double FindAverage(int[] NumberofBatsArray)
        {
            double Hits = 0;
            foreach (int Number in NumberofBatsArray)
            {
                if (Number > 0)
                {
                    Hits++;
                }
            }
            return Hits / NumberofBatsArray.Length;
        }

        static double FindSluggerPercentage(int[] BattingResultArray)

        {

            int Total = 0;
            for (int i = 0; i < BattingResultArray.Length; i++)
            {
                if (BattingResultArray[i] != 0)
                    Total += BattingResultArray[i];
            }

            double Slugging = (double)Total / (double)BattingResultArray.Length;
            return Slugging;
        }
  }
}

