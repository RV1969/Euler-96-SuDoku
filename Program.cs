using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Euler0096
{
    class Program
    {
        static string[] lines;
        static string[] blocks = new string[50];
        static string[] blocks2 = new string[50];
        static string[] blocks3 = new string[50];
        static string[] blocks4 = new string[50];

        static void ReadFile(string name)
        {
            int numberOfLines = 0;
            var list = new List<string>();
            var fileStream = new FileStream(name, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                    numberOfLines++;
                }
            }
            lines = list.ToArray();
        }

        static void Process()
        {
            int x = 0;
            int z = 0;

            while (x <= lines.Length - 10)
            {
                for (int y = 1; y <= 9; y++)
                {
                    blocks[z] += lines[x + y];
                }
                x += 10;                
                z++;
            }
        }

        static string Checkgrid(string inp)
        {
            if (inp == "invalid") return inp;
            else
            {
                for (int p = 0; p <= 9; p++)
                {
                    if (!inp.Contains("0")) break;
                    else
                    {
                        for (int y = 0; y <= 80; y++)
                        {
                            List<string> Possibilities = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                            if (inp.Substring(y, 1) == "0")
                            {
                                for (int x = 0; x <= 8; x++)
                                {
                                    Possibilities.Remove(inp.Substring(y / 9 * 9 + x, 1));
                                    Possibilities.Remove(inp.Substring((y % 9) + (9 * x), 1));
                                }

                                int b = y % 9;
                                int s = 0;

                                switch (y / 27)
                                {
                                    case 0: if (b < 3) s = 0; else if (b < 6) s = 3; else s = 6; break;
                                    case 1: if (b < 3) s = 27; else if (b < 6) s = 30; else s = 33; break;
                                    case 2: if (b < 3) s = 54; else if (b < 6) s = 57; else s = 60; break;
                                }

                                for (int x = 0; x <= 2; x++)
                                {
                                    Possibilities.Remove(inp.Substring(s + x, 1));
                                    Possibilities.Remove(inp.Substring(s + 9 + x, 1));
                                    Possibilities.Remove(inp.Substring(s + 18 + x, 1));
                                }
                                if (Possibilities.Count == 0) return "invalid";
                                if (Possibilities.Count == 1)
                                {
                                    StringBuilder sb = new StringBuilder(inp);
                                    sb[y] = Convert.ToChar(Possibilities[0]);
                                    inp = sb.ToString();
                                }
                            }
                        }
                    }
                }
            }
            return inp;
        }

        static string CheckgridModerate(string inp)
        {
            
            for (int y = 0; y <= 80; y++)
            {
                List<string> Possibilities = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                if (inp == "invalid") return inp;
                else
                {
                    if (inp.Substring(y, 1) == "0")
                    {
                        for (int x = 0; x <= 8; x++)
                        {
                            Possibilities.Remove(inp.Substring(y / 9 * 9 + x, 1));
                            Possibilities.Remove(inp.Substring((y % 9) + (9 * x), 1));
                        }

                        int b = y % 9;
                        int s = 0;

                        switch (y / 27)
                        {
                            case 0: if (b < 3) s = 0; else if (b < 6) s = 3; else s = 6; break;
                            case 1: if (b < 3) s = 27; else if (b < 6) s = 30; else s = 33; break;
                            case 2: if (b < 3) s = 54; else if (b < 6) s = 57; else s = 60; break;
                        }

                        for (int x = 0; x <= 2; x++)
                        {
                            Possibilities.Remove(inp.Substring(s + x, 1));
                            Possibilities.Remove(inp.Substring(s + 9 + x, 1));
                            Possibilities.Remove(inp.Substring(s + 18 + x, 1));
                        }

                        if (Possibilities.Count == 2)
                        {
                            string solution;
                            for (int x = 0; x <= 1; x++)
                            {
                                StringBuilder sb = new StringBuilder(inp);
                                sb[y] = Convert.ToChar(Possibilities[x]);
                                solution=Checkgrid(sb.ToString());
                                if  (!solution.Contains("invalid") && !solution.Contains("0")) { return solution; }
                            }
                            

                        }
                    }
                }
            }
            return inp;
        }

        static string CheckgridHard(string inp)
        {

            for (int y = 0; y <= 80; y++)
            {
                List<string> Possibilities = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                if (inp == "invalid") return inp;
                else
                {
                    if (inp.Substring(y, 1) == "0")
                    {
                        for (int x = 0; x <= 8; x++)
                        {
                            Possibilities.Remove(inp.Substring(y / 9 * 9 + x, 1));
                            Possibilities.Remove(inp.Substring((y % 9) + (9 * x), 1));
                        }

                        int b = y % 9;
                        int s = 0;

                        switch (y / 27)
                        {
                            case 0: if (b < 3) s = 0; else if (b < 6) s = 3; else s = 6; break;
                            case 1: if (b < 3) s = 27; else if (b < 6) s = 30; else s = 33; break;
                            case 2: if (b < 3) s = 54; else if (b < 6) s = 57; else s = 60; break;
                        }

                        for (int x = 0; x <= 2; x++)
                        {
                            Possibilities.Remove(inp.Substring(s + x, 1));
                            Possibilities.Remove(inp.Substring(s + 9 + x, 1));
                            Possibilities.Remove(inp.Substring(s + 18 + x, 1));
                        }

                        if (Possibilities.Count == 3)
                        {
                            string solution;
                            for (int x = 0; x <= 2; x++)
                            {
                                StringBuilder sb = new StringBuilder(inp);
                                sb[y] = Convert.ToChar(Possibilities[x]);
                                solution = CheckgridModerate(sb.ToString());
                                if (!solution.Contains("invalid") && !solution.Contains("0")) { return solution; }
                            }


                        }
                    }
                }
            }
            return inp;
        }

        static string CheckgridExtraHard(string inp)
        {

            for (int y = 0; y <= 80; y++)
            {
                List<string> Possibilities = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                if (inp == "invalid") return inp;
                else
                {
                    if (inp.Substring(y, 1) == "0")
                    {
                        for (int x = 0; x <= 8; x++)
                        {
                            Possibilities.Remove(inp.Substring(y / 9 * 9 + x, 1));
                            Possibilities.Remove(inp.Substring((y % 9) + (9 * x), 1));
                        }

                        int b = y % 9;
                        int s = 0;

                        switch (y / 27)
                         {
                             case 0: if (b < 3) s = 0; else if (b < 6) s = 3; else s = 6; break;
                             case 1: if (b < 3) s = 27; else if (b < 6) s = 30; else s = 33; break;
                             case 2: if (b < 3) s = 54; else if (b < 6) s = 57; else s = 60; break;
                         }
                        
                         for (int x = 0; x <= 2; x++)
                         {
                             Possibilities.Remove(inp.Substring(s + x, 1));
                             Possibilities.Remove(inp.Substring(s + 9 + x, 1));
                             Possibilities.Remove(inp.Substring(s + 18 + x, 1));
                         }

                        if (Possibilities.Count == 4)
                        {
                            string solution;
                            for (int x = 0; x <= 3; x++)
                            {
                                StringBuilder sb = new StringBuilder(inp);
                                sb[y] = Convert.ToChar(Possibilities[x]);                                                              
                                solution = CheckgridHard(sb.ToString());                                
                                if (!solution.Contains("invalid") && !solution.Contains("0")) { return solution;}
                            }


                        }
                    }
                }
            }
            return inp;
        }

        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            ReadFile("C:/Users/ronald.vosman/source/repos/Euler0096/Euler0096/p096_sudoku.txt");
            Process();

            int passblocks = 0;
            int passblocks2 = 0;
            int passblocks3 = 0;

            int euler = 0;

            Console.WriteLine("Easy (no guesses):");
            Console.WriteLine("==================");
            
            string solution;
            for (int z = 0; z <= 49; z++)
            { solution = Checkgrid(blocks[z]);
                if (!solution.Contains("0"))
                {
                    Console.WriteLine(solution);
                    euler += int.Parse(solution.Substring(0, 3));                    
                }

                else
                    blocks2[passblocks++] = solution;
            }
            Console.WriteLine();
           
            Console.WriteLine("Moderate (one guess):");
            Console.WriteLine("=====================");
            for (int z = 0; z <= passblocks-1; z++)
            {
                solution = CheckgridModerate(blocks2[z]);
                if (!solution.Contains("0"))
                {
                    Console.WriteLine(solution);
                    euler += int.Parse(solution.Substring(0, 3));
                }
                else
                    blocks3[passblocks2++] = solution;
            }

            Console.WriteLine();
            Console.WriteLine("Hard (two guesses):");
            Console.WriteLine("===================");
            for (int z = 0; z <= passblocks2 - 1; z++)
            {
                solution = CheckgridHard(blocks3[z]);
                if (!solution.Contains("0"))
                {
                    Console.WriteLine(solution);
                    euler += int.Parse(solution.Substring(0, 3));
                }
                else                  
                    blocks4[passblocks3++] = solution;
            }

            Console.WriteLine();
            Console.WriteLine("Extra hard (three guesses):");
            Console.WriteLine("===========================");
            for (int z = 0; z <= passblocks3 - 1; z++)
            {
                solution = CheckgridExtraHard(blocks4[z]);
                //if (!solution.Contains("0"))
                {
                    Console.WriteLine(solution);
                    euler += int.Parse(solution.Substring(0, 3));
                }
                //else
                //    blocks4[passblocks3++] = solution;
            }

            Console.WriteLine();
            Console.WriteLine(euler);
            string elapsedMs = watch.ElapsedMilliseconds.ToString();
            Console.WriteLine("That took me " + elapsedMs + " milliseconds.");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
