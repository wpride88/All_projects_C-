using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Midtermscores
{
    class Scores
    {
        static void Main(string[] args)
        {
            int count = 0, i = 0;
            try
            {
                string lineSc; string FileName = "c:\\Midtermscores.txt";
                StreamReader sc = new StreamReader(FileName, Encoding.Default);
                while ((lineSc = sc.ReadLine()) != null)//////111111111111111111
                {
                    if (lineSc != "") count++;
                }
                sc.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            
            int[] scarr = new int[count]; ///222222222222222222222222
            try
            {
                int itemp = 0; string lineSc; string FileName = "c:\\Midtermscores.txt";
                StreamReader sc1 = new StreamReader(FileName, Encoding.Default);
                while ((lineSc = sc1.ReadLine()) != null)
                {
                    if (lineSc != "" && IsDigitValue(lineSc))
                    {
                        itemp = Convert.ToInt16(lineSc.Trim());
                        scarr[i] = itemp;
                        i++;
                    }
                    else Console.WriteLine(lineSc + " is nod digit value; ");
                }
                sc1.Close();
            }
            catch (Exception exc) { Console.WriteLine(exc.Message); }


            Array.Sort(scarr);
            //Console.WriteLine(IsDigitValue("123a") + " " + IsDigitValue("345"));

            int step = 10; int j = step - 1; int countrange = 0; int j2 = 0;
            while (j <= (MaxArr(scarr)+step-1))
            {
                for (i = 0; i < scarr.Length; i++)
                {
                    if (scarr[i] >= j2 && scarr[i] <= j) countrange++;
                }
                //Console.WriteLine("|{0}-{1}| {2}", j2, j, countrange);
                WriteRangeAll(j2, j, countrange, MaxArr(scarr));
                j2 = j; j = j + step;
                countrange = 0; 
            }
            Console.ReadLine();
        }

        public static void WriteRangeAll(int minRange, int maxRange, int count, int maxArrValue)
        {
            string strminRange, strmaxRange, strcount = "";

            if (minRange != 0) minRange++;
            strminRange = Convert.ToString(minRange);
            if (strminRange.Length == 1) strminRange = "0" + strminRange;
           
            strmaxRange = Convert.ToString(maxRange);
            if (strmaxRange.Length == 1) strmaxRange = "0" + strmaxRange;
            
            if (count != 0) { for (int ii = 1; ii <= count; ii++) { strcount = strcount + "*"; } }
            else { strcount = ""; }
            //Console.WriteLine("{0}-{1}: {2}", strminRange, strmaxRange, strcount);
            if (maxRange >= maxArrValue) { Console.WriteLine("{0,5}: {1}", maxArrValue, strcount); }
            else { Console.WriteLine("{0}-{1}: {2}", strminRange, strmaxRange, strcount); };
        }

        public static bool IsDigitValue(string isval)
        {
            bool isdgt = true;
                for (int ii = 0; ii < isval.Length; ii++)
                {
                    if (isval[ii] >= '0' && isval[ii] <= '9' && isdgt) isdgt = true; else isdgt = false;
                }
            return (isdgt);
        }

        public static int MaxArr(int[] arrmax)
        {
            int temp = arrmax[0];
            for (int ii = 0; ii < arrmax.Length; ii++) { if (temp < arrmax[ii]) temp = arrmax[ii]; }
            return (temp);
        }

        public static int MinArr(int[] arrmin)
        {
            int temp = arrmin[0];
            for (int ii = 0; ii < arrmin.Length; ii++) { if (temp > arrmin[ii]) temp = arrmin[ii]; }
            return (temp);
        }
    }
}
