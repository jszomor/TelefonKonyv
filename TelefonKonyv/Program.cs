using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonKonyv
{
  class Program
  {
    static void Main(string[] args)
    {
      string file = "TelefonKonyv.txt";
      TKonyv tKonyv = new TKonyv(file);
      bool end = true;
      while(end)
      {
        tKonyv.Print();
        Console.WriteLine("Opciók:");
        Console.WriteLine("Hozzáad >> 1");
        Console.WriteLine("Töröl >> 2");
        Console.WriteLine("Kilépés és mentés fileba >> 3");
        string userSelect = Console.ReadLine();
        if (userSelect == "1")
        {
          tKonyv.Insert();
        }
        else if (userSelect == "2")
        {

        }
        else if (userSelect == "3")
        {
          end = false;
        }

        Console.Clear();
      }
      Console.ReadKey();
    }
  }
}
