using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    public class ChangeString
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(build("123 abcd*3"));
        //    Console.ReadLine();
        //}
        static string build(String entrada)
        {
            string retorna = "";
            string abc = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,ñ,o,p,q,r,s,t,u,v,w,x,y,z";
            string[] subs = abc.Split(',');

            for (int i = 0; i < entrada.Count(); i++)
            {
                string en = entrada[i].ToString();

                string letraCm = "";
                for (int j = 0; j < subs.Count(); j++)
                {
                    string ab = subs[j].ToString();
                    if ((ab == en) && ab != "z")
                    {
                        letraCm = subs[j + 1].ToString();
                    }
                }
                if ((en != letraCm) && letraCm != "")
                {
                    en = letraCm;
                }
                retorna += en;
            }
            return retorna;
        }
    }
}
