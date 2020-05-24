using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam research1 = new ResearchTeam();
            Console.WriteLine(research1.ToShorString());

            Console.WriteLine("Is YEAR? " + research1[TimeFrame.YEAR]);
            Console.WriteLine("Is TWO_YEARS? " + research1[TimeFrame.TWO_YEARS]);
            Console.WriteLine("Is LONG? " + research1[TimeFrame.LONG] + "\n");

            Paper paper = new Paper("Supernatural", new Person(), new DateTime(2020, 2, 16, 20, 5, 10));
            Paper paper1 = new Paper("Flash", new Person(), new DateTime(2020, 2, 16, 20, 5, 10));
            Paper paper2 = new Paper("Aleskandriy", new Person(), new DateTime(2020, 2, 16, 20, 5, 10));
       

            ResearchTeam research = new ResearchTeam("Tema", "Organization", 123, TimeFrame.YEAR);
            research.AddPapers(paper, paper1, paper2);
            Console.WriteLine(research);
            Console.WriteLine(research.GetLastPublication());

            char[] delimiterChars = { ',', '|' };
            Console.Write("Enter size row and col with a separator '|' or ',': ");
            string strInput = Console.ReadLine();

            int[] input = strInput.Split(delimiterChars).Select(x => int.Parse(x)).ToArray();
            int row = input[0];
            int col = input[1];
            Console.WriteLine($"Rows = {row}, Cols = {col}");

            Stopwatch sw = new Stopwatch();
            Paper[] oneArr = new Paper[row * col];
            sw.Start();  
            for (int i = 0; i < oneArr.Length; i++)
                oneArr[i] = new Paper();

            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);

            Paper[,] twoArr = new Paper[row, col];
            sw.Start();
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    twoArr[i, j] = new Paper();

            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);

            Paper[][] teethArr = new Paper[row][];
            var rand = new Random();
            int size = col * row;

            // init teethArr
            for (int i = 0; i < row; i++)
            {
                int nRand = rand.Next(size);
                size -= nRand;

                teethArr[i] = new Paper[nRand];
                if (row - 1 == i + 1)
                {
                    teethArr[i + 1] = new Paper[size];
                    break;
                }
            }

            sw.Start();
            for (int i = 0; i < teethArr.Length; i++)
                for (int j = 0; j < teethArr[i].Length; j++)
                    teethArr[i][j] = new Paper();
                 
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);









            Console.ReadLine();
        }
    }
}
