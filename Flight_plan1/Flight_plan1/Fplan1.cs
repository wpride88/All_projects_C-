using System;
using System.IO;
using System.Text;
using CollectionClass;
using LeftRightMid;
using System.Collections;
using System.Collections.Generic;

namespace CSharpApplication.FlightPlan
{
    class FlightRoutePlanner
    {
        [STAThread]
        static void Main()
        {
            StreamWriter sw = new StreamWriter("c:\\flights.txt", false, Encoding.Default);

            //**1//////////////////////////////////////////
            string[][] splan = new string[6][];
            //Инициализация "зубчатых" массивов
            splan[0] = new string[] { "San Jose", "San Francisco", "Anchorage" };
            splan[1] = new string[] { "New York", "Anchorage", "San Jose", "San Francisco", "Honolulu" };
            splan[2] = new string[] { "Anchorage", "New York", "San Jose" };
            splan[3] = new string[] { "Honolulu", "New York", "San Francisco" };
            splan[4] = new string[] { "Denver", "San Jose" };
            splan[5] = new string[] { "San Francisco", "New York", "Honolulu", "Denver" };
            //**2///////////////////////////////////////////

            int i, j;
            for (i = 0; i < splan.Length; i++)
            {
                for (j = 1; j < splan[i].Length; j++)
                {
                    System.Console.WriteLine(splan[i][0] + " -> " + splan[i][j]);
                    sw.WriteLine(splan[i][0] + " -> " + splan[i][j]);
                }
                j = 0;
                System.Console.WriteLine("///////////////////////");
                sw.WriteLine("");
            }
            //Console.ReadLine();
            sw.Close();*/

            ////////////////////////////////////////////
            string FileName = "C:\\flights.txt";
            //string FileName = "flights.txt";
            int count = 0; 
            int i, j;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("List of flying plans ");

            ArrayList arUNIcities = new ArrayList();
            ArrayList arINcities = new ArrayList();
            ArrayList arOUTcities = new ArrayList();

            try
            {
                StreamReader sr = new StreamReader(FileName, Encoding.Default);

                string lineR;
                while ((lineR = sr.ReadLine()) != null)
                {
                    if (lineR != "")
                    {
                        //Console.WriteLine(lineR);
                        string outCity = lineR.Substring(lineR.IndexOf(" -> ") + 4);
                        string inCity = lineR.Substring(0, lineR.IndexOf(" -> "));
                        //
                        if (!(arUNIcities.Contains(inCity))) arUNIcities.Add(inCity);
                        arINcities.Add(inCity); arOUTcities.Add(outCity);
                        count++;
                    }
                    else Console.WriteLine("");
                }
                sr.Close();
            }
            catch (Exception exc)
            {
                // Сообщение об ошибке
                Console.WriteLine(exc.Message);
            }

            //String[][] ar = new string [arINcities.Count][];//Инициализация зубчастого массива
            String[,] ar2unsort = new string[arINcities.Count, 2];//Инициализация 2-х мерного массива
            String[,] ar2sort = new string[arINcities.Count, 2];//Инициализация 2-х мерного массива
            String[] ar2UNIsort = new string[arUNIcities.Count];

            for (i = 0; i < arINcities.Count; i++)
            {
                ar2unsort[i, 0] = (String)(arINcities[i]);
                ar2unsort[i, 1] = (String)(arOUTcities[i]);
                if (i < arUNIcities.Count) { ar2UNIsort[i] = (String)arUNIcities[i]; };
            }
            Console.WriteLine("");

            //
            Array.Sort(ar2UNIsort);
            int k = 0;
            for (j = 0; j < ar2UNIsort.Length; j++)
            {
                string first = ar2UNIsort[j];
                for (i = 0; i < ar2sort.Length / 2; i++)
                {
                    if (ar2unsort[i, 0] == first)
                    {
                        ar2sort[k, 0] = ar2unsort[i, 0];
                        ar2sort[k, 1] = ar2unsort[i, 1];
                        k++;
                    }
                }
            }

            //
            int x = 0; string firstcity, tempcity;// ////////////////////////////////////////////////////////
            ArrayList routePlan = new ArrayList();

                do
                {
                    Console.WriteLine("Welcome to Flight Planner!");
                    Console.WriteLine("Here is a list of all the cities in our database:");
                    Console.WriteLine("");
                    for (i = 0; i < ar2sort.Length / 2; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("    " + ar2sort[i, 0] + " -> " + ar2sort[i, 1]);
                    }
                    Console.ResetColor(); Console.WriteLine("");
                    Console.WriteLine("Let's plan a round-trip route!");
                    Console.Write("Enter the starting city: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    firstcity = Console.ReadLine(); Console.ResetColor();
                    if (Array.IndexOf(ar2UNIsort, firstcity) != -1)
                    {
                        routePlan.Add(firstcity);
                        x = 1;
                    }
                    else
                    {
                        Console.Clear(); x = 0; Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your entered city cannot find in our database, please reenter the start city!");
                        Console.WriteLine(); Console.ResetColor();
                    }
                } while (x == 0);

                x = 0;// ////////////////////////////////////////////
                tempcity = firstcity;
                do
                {
                    tempcity = ReadNextCity(ar2sort, tempcity, ar2UNIsort);
                    routePlan.Add(tempcity);

                } while (firstcity != tempcity);
                
                //
                Console.WriteLine("");  Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Your choosen route plan is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                for (i = 0; i < routePlan.Count; i++ )
                {
                    Console.Write(routePlan[i]);
                    if (i < routePlan.Count - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("->"); Console.ResetColor();
                    }
                }
            Console.WriteLine(""); Console.ReadLine();
        }

        
        public static string ReadNextCity(string[,] arr, string tmpcity, string[] arrUNI)
        {
            string rdCity; int x;
            do
            {
                Console.WriteLine("");
                Console.Write("From "); Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(tmpcity); Console.ResetColor();
                Console.WriteLine(" you can fly directly to:");
                for (int i = 0; i < arr.Length / 2; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (arr[i, 0] == tmpcity) Console.WriteLine("    " + arr[i, 0] + " -> " + arr[i, 1]);
                    Console.ResetColor();
                }

                Console.WriteLine(); Console.Write("Where do you want to go from ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(tmpcity); Console.ResetColor(); Console.Write(" ? ");
                Console.ForegroundColor = ConsoleColor.Blue;

                rdCity = Console.ReadLine(); Console.ResetColor();
                if (Array.IndexOf(arrUNI, rdCity) != -1)
                {
                    //rtPlan.Add(rdCity);
                    x = 1;
                }
                else
                {
                    x = 0; Console.Clear(); Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your entered city cannot find in our database, please reenter the start city!");
                    Console.WriteLine(); Console.ResetColor();
                }
            } while (x == 0);

            return (rdCity);
        }

        public static void IncreaseLength(ref int[] arr, int delta)
        {
            //создаем и 'расстягиваем' массив int'ов до 10 и тоже самое для string'ов до 15:
            //string[] strings = new string[]{"One", "Two", "Three"};
            //strings = (string[])IncreaseArray(strings, 15);
            //string[][] allplan = new string[6][];
            //Console.WriteLine(Right(lineR, 5));
            //assign a value to our string
            int[] tmp = new int[arr.Length + delta];
            Array.Copy(arr, 0, tmp, 0, arr.Length);
            arr = tmp;
        }
    }
}