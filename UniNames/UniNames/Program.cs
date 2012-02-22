using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniqueGetNames
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList un = new ArrayList();
            ArrayList allnames = new ArrayList();
            string name;
            do
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                if (!un.Contains(name) && name != "") { un.Add(name); };
                if (name !="") { allnames.Add(name); }
            }
            while (name != "");

            un.Sort();
            Console.WriteLine("Unique name list containts:");
            for (int i = 0; i < un.Count; i++)
            {
                Console.WriteLine(un[i]);
            }
            Console.WriteLine();

            int count = 0;
            Hashtable hs = new Hashtable();
            for (int i = 0; i < un.Count; i++)
            {
                for (int j = 0; j<allnames.Count; j++)
                {
                    if ((string)un[i] == (string)allnames[j]) count++;
                }
                hs.Add((String)un[i], Convert.ToString(count));
                count = 0;
            }

            Console.WriteLine("Count names list containts:");
            foreach (DictionaryEntry dehs in hs)
            {
                //Console.WriteLine("Sorted entries [{0}] has count {1}", arrtemp[i,0], arrtemp[i,1]);
                Console.WriteLine("Sorted entries [{0}] has count {1}", dehs.Key, dehs.Value);
            }
            Console.ReadLine();
        }
    }
}
