using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    public class OrderRange
    {
        static void Main(string[] args)
        {
            int[] n = new[] { 10, 5, 1, 2, 3, 4 };
            Console.WriteLine(build(n));
            Console.ReadLine();
        }
        static string build(int[] entrada)
        {

            List<int> pares = new List<int>();
            List<int> impares = new List<int>();
            int[] p = new int[0] { };
            for (int i = 0; i < entrada.Count(); i++)
            {
                if ((entrada[i] % 2) == 0)
                {
                    pares.Add(entrada[i]);
                }
                else
                {
                    impares.Add(entrada[i]);
                }
            }

            int[] str = pares.ToArray();
            int[] str2 = impares.ToArray();

            Array.Sort<int>(str); Array.Sort<int>(str2); 

            string retorna = "[" + string.Join(", ", str) + "],[" + string.Join(", ", str2) + "]";

            return retorna;
        }
    }
}

