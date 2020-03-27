using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonKonyv
{
  class TKonyv
  {
    public struct Entrik
    {
      public int Id;
      public string Name;
      public string Address;
      public string Number;
      public int Age;
    }
    public Entrik[] entries = new Entrik[1000];
    public int NumberOfEntries = 0;
    string fileName;
    public int i = 0;
    public TKonyv(string file)
    {
      fileName = file;
      //entries = new Entrik[1000];

      StreamReader fileReader = new StreamReader(file);
      string sor;
      string[] adatok;
      //int i = 0;
      while ((sor = fileReader.ReadLine()) != null)
      {
        adatok = sor.Split('\t');

        if (adatok.Length != 5) continue;

        entries[i].Id = Convert.ToInt32(adatok[0]);
        entries[i].Name = adatok[1];
        entries[i].Address = adatok[2];
        entries[i].Number = adatok[3];
        entries[i].Age = Convert.ToInt32(adatok[4]);
        NumberOfEntries++;
        i++;
      }
    }
    public void Print()
    {
      for (int i = 0; i < NumberOfEntries; i++)
      {
        Console.WriteLine("{0,3} {1,-20} {2,-30} {3,-15} {4,3}",
          entries[i].Id, entries[i].Name, entries[i].Address, entries[i].Number, entries[i].Age);
      }
    }
    public void Insert()
    {    
        //Console.WriteLine("Kérem az Id-t:");
        entries[i].Id = i+1;
        Console.WriteLine("Kérem a nevet.");
        entries[i].Name = Console.ReadLine();
        Console.WriteLine("Kérem a címet.");
        entries[i].Address = Console.ReadLine();
        Console.WriteLine("Kérem a telefonszámot.");
        entries[i].Number = Console.ReadLine();
        Console.WriteLine("Kérem a kort.");
        entries[i].Age = Convert.ToInt32(Console.ReadLine());
        NumberOfEntries++;
        i++;      
    }
    public void Delete()
    {
      Console.WriteLine("Kérem adja meg a törölni kívánt személy Id-ját.");
      int deleteId = int.Parse(Console.ReadLine());
      entries = entries.Where(x => x.Id != deleteId).ToArray();
    }
    ~TKonyv()
    {
      StreamWriter streamWriter = new StreamWriter(fileName, false);
      for (int i = 0; i < NumberOfEntries; i++)
      {
        streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
          entries[i].Id, entries[i].Name, entries[i].Address, entries[i].Number, entries[i].Age);
      }
      streamWriter.Close();
    }
  }
}
