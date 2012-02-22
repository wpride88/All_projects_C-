using System;
//USING:
/*if (lineR.IndexOf(" -> ") > -1) Console.WriteLine(lineR.IndexOf(" -> "));//Number
string outCity = LeftRightMid.LeftRightMid.Right(lineR, lineR.Length - lineR.IndexOf(" -> ")-4);
string inCity = LeftRightMid.LeftRightMid.Left(lineR, lineR.IndexOf(" -> "));*/
                  /*string myString = "This is a string";
                        //get 4 characters starting from the left
                        Console.WriteLine(Left(myString, 4));
                        //get 6 characters starting from the right
                        Console.WriteLine(Right(myString, 6));
                        //get 4 characters starting at index 5 of the string
                        Console.WriteLine(Mid(myString, 5, 4));
                        //get the characters from index 5 up to the end of the string
                        Console.WriteLine(Mid(myString, 5));
                        //display the result to the screen*/
namespace LeftRightMid
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class LeftRightMid
    {
        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }
        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }
        public static string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex, length);
            //return the result of the operation
            return result;
        }
        public static string Mid(string param, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            string result = param.Substring(startIndex);
            //return the result of the operation
            return result;
        }
    }
}