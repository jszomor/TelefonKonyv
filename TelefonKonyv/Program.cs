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
      string fileEmail = "TelefonKonyvEmail.txt";
      NewTkonyv tKonyv = new NewTkonyv(fileEmail, file);
      bool end = true;
      while(end)
      {
        tKonyv.Print();
        Console.WriteLine($"Legmagasabb kor: {tKonyv.MaxAge}");
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
          Console.WriteLine("Kérem adja meg a törölni kívánt személy Id-ját.");
          int deleteId = int.Parse(Console.ReadLine());
          tKonyv.Delete(deleteId);
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
