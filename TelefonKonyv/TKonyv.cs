using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonKonyv
{
  public class NewTkonyv : TKonyv
  {
    string emailFileName;
    public NewTkonyv(string fileEmail, string file) : base(file)
    {
      emailFileName = fileEmail;
      //fileName = file;
      //entries = new Entrik[1000];
      StreamReader fileReader = null;
      try
      {
        fileReader = new StreamReader(fileEmail);
        string sor;
        string[] adatok;
        //int i = 0;
        while ((sor = fileReader.ReadLine()) != null)
        {
          adatok = sor.Split('\t');

          if (adatok.Length != 2) continue;
          int k = FindId(Convert.ToInt32(adatok[0]));
          if (k >= 0)
          {
            entries[k].Email = adatok[1];
          }
        }
      }
      catch
      {
        return;
      }      
    }
    int FindId(int id)
    {
      int i;
      for (i = 0; i < db; i++)
      {
        if (entries[i].Id == id)
        {
          break;
        }
      }
      if (i != db)
        return i;
      else
        return -1;
    }
    public void Print()
    {
      for (int i = 0; i < db; i++)
      {
        Console.WriteLine("{0,3} {1,-20} {2,-30} {3,-15} {4,3} {5, -30}",
        entries[i].Id, entries[i].Name, entries[i].Address, entries[i].Number, entries[i].Age, entries[i].Email);
      }    
    }
    public void Insert()
    {
      int temp = 0;
      for (int i = 0; i < db; i++)
      {
        if (temp < entries[i].Id && entries[i].Id != 0)
        {
          temp = entries[i].Id;
        }
      }
      //Console.WriteLine("Kérem az Id-t:");
      entries[db].Id = temp + 1;
      Console.WriteLine("Kérem a nevet.");
      entries[db].Name = Console.ReadLine();
      Console.WriteLine("Kérem a címet.");
      entries[db].Address = Console.ReadLine();
      Console.WriteLine("Kérem a telefonszámot.");
      entries[db].Number = Console.ReadLine();
      Console.WriteLine("Kérem a kort.");
      entries[db].Age = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Kérem az emailt.");
      entries[db].Email = Console.ReadLine();
      NumberOfEntries++;
      db++;
    }
    public void Delete(int id)
    {
      int i;
      for (i = 0; i < db; i++)
      {
        if (entries[i].Id == id)
        {
          break;
        }
      }
      if (i == db)
      {
        return;
      }
      for (int j = i; j < db - 1; j++)
      {
        entries[j].Id = entries[j + 1].Id;
        entries[j].Name = entries[j + 1].Name;
        entries[j].Address = entries[j + 1].Address;
        entries[j].Number = entries[j + 1].Number;
        entries[j].Age = entries[j + 1].Age;
        entries[j].Email = entries[j + 1].Email;
      }
      db--;
      //entries = entries.Where(x => x.Id != deleteId).ToArray();
    }
    ~NewTkonyv()
    {
      StreamWriter streamWriter = new StreamWriter(emailFileName, false);

      for (int i = 0; i < db; i++)
      {
        if (entries[i].Email == null) continue;

        streamWriter.WriteLine("{0}\t{1}",
          entries[i].Id, entries[i].Email);
      }
      streamWriter.Close();
    }
  }
  public class TKonyv
  {
    public int MaxAge 
    {
      get
      {
        int age = 0;
        for (int i = 0; i < db; i++)
        {
          if(age < entries[i].Age)
          {
            age = entries[i].Age;
          }
        }
        return age;
      }    
    }
    public struct Entrik
    {
      public int Id;
      public string Name;
      public string Address;
      public string Number;
      public int Age;
      public string Email;
    }
    public Entrik[] entries = new Entrik[1000];
    public int NumberOfEntries = 0;
    string fileName;
    public int db = 0;
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

        entries[db].Id = Convert.ToInt32(adatok[0]);
        entries[db].Name = adatok[1];
        entries[db].Address = adatok[2];
        entries[db].Number = adatok[3];
        entries[db].Age = Convert.ToInt32(adatok[4]);
        NumberOfEntries++;
        db++;
      }
    }
    public void Print()
    {
      for (int i = 0; i < db; i++)
      {
        Console.WriteLine("{0,3} {1,-20} {2,-30} {3,-15} {4,3}",
        entries[i].Id, entries[i].Name, entries[i].Address, entries[i].Number, entries[i].Age);
      }
    }
    public void Insert()
    {
      int temp = 0;
      for (int i = 0; i < db; i++)
      {
        if (temp < entries[i].Id && entries[i].Id != 0)
        {
          temp = entries[i].Id;
        }
      }
        //Console.WriteLine("Kérem az Id-t:");
        entries[db].Id = temp+1;
        Console.WriteLine("Kérem a nevet.");
        entries[db].Name = Console.ReadLine();
        Console.WriteLine("Kérem a címet.");
        entries[db].Address = Console.ReadLine();
        Console.WriteLine("Kérem a telefonszámot.");
        entries[db].Number = Console.ReadLine();
        Console.WriteLine("Kérem a kort.");
        entries[db].Age = Convert.ToInt32(Console.ReadLine());
        NumberOfEntries++;
        db++;      
    }
    public void Delete(int id)
    {
      int i;
      for (i = 0; i < db; i++)
      {
        if(entries[i].Id == id)
        {
          break;
        }
      }
      if(i == db)
      {
        return;
      }
      for (int j = i; j < db-1; j++)
      {
        entries[j].Id = entries[j + 1].Id;
        entries[j].Name = entries[j + 1].Name;
        entries[j].Address = entries[j + 1].Address;
        entries[j].Number = entries[j + 1].Number;
        entries[j].Age = entries[j + 1].Age;        
      }
      db--;
      //entries = entries.Where(x => x.Id != deleteId).ToArray();
    }
    ~TKonyv()
    {
      StreamWriter streamWriter = new StreamWriter(fileName, false);

      for (int i = 0; i < db; i++)
      {
        streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
          entries[i].Id, entries[i].Name, entries[i].Address, entries[i].Number, entries[i].Age);
      }
      streamWriter.Close();
    }
  }
}
