using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = "C:\\lear.txt";
            //string FileName = "C:\\flights.txt";
            int Lines = 0, Words = 0, wordsall =0, charsall = 0, spaces = 0, spacesall = 0, s = 0;
            char[] charSeparators = new char[] { ' ' };
            string[] stringSeparators = new string[] { "[stop]" };
            //string[] result; //lineWR.Split(charSeparators,StringSplitOptions.None);
            // intToString string intstr = lineWR.Length.ToString();
            //stringToInt
            int wdtemp = 0;
            try
            {
                StreamReader wr = new StreamReader(FileName, Encoding.Default);

                string lineWR;
                while ((lineWR = wr.ReadLine()) != null)
                {
                    if (lineWR != "")
                    {
                        /////////////////////////////////////
                        for (int i = 0; i < lineWR.Length; i++)
                        {
                            if ((IsLetterOrDigit(lineWR[i]) == 1) || (IsLetterOrDigit(lineWR[i]) == 0))
                            {
                                //wdtemp++;
                            } else
                            {
                                if (lineWR[i] == ' ' && lineWR[i-1] != ' ') Words++;
                                if (lineWR[i] == '\'') Words++;
                                if ((IsLetterOrDigit(lineWR[i]) == -1) && (lineWR[i - 1] == ' ')) s=0; // Words--;
                            }
                            wdtemp++;
                        }
                        if (lineWR[wdtemp-1] != ' ') { Words++; wdtemp = 0; }
                        //Console.WriteLine(lineWR + " Chars: " + lineWR.Length + ", Words: " + wordsall);
                        spacesall = spacesall + spaces;
                        charsall = charsall + lineWR.Length;
                        Lines++;
                        wordsall = wordsall + Words; Words = 0;
                    }
                    else Console.WriteLine("");
                }
                wr.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            
            Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("File: " + FileName); Console.ResetColor();
            Console.WriteLine("Lines = " + Lines);
            Console.WriteLine("Words = " + wordsall);
            Console.WriteLine("Chars = " + charsall);
            
            /*char[] chars = new char[4];
            chars[0] = 'X';        // Character literal
            chars[1] = '\x0058';   // Hexadecimal
            chars[2] = (char)88;   // Cast from integral type
            chars[3] = '\u0058';   // Unicode

            foreach (char c in chars)
            {
                Console.Write(c + " ");
            }
            // Output: X X X X*/
            char sym1 = 'A', sym2 = '1';
            //Console.WriteLine(sym1 + " - " + IsLetterOrDigit(sym1) + "; " + sym2 + " - " + IsLetterOrDigit(sym2)); 
            Console.ReadLine();
        }

        public static int IsLetterOrDigit(char symb)
        {
            int symORdigit = 0;
            if ((symb >= 'A' && symb <= 'Z') || (symb >= 'a' && symb <= 'z'))
            {
                symORdigit = 1;
            }
            else
            {
                if (symb >= '0' && symb <= '9') { symORdigit = 0; }
                else { symORdigit = -1; };
            }
            return (symORdigit);
        }
    }
}
