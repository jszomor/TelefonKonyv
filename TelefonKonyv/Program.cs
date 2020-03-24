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

      tKonyv.Print();
      Console.ReadKey();
    }
  }
}
