using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Person
    {
        public int Height {get; set;}
        public int PersonCode {get; set;}
        public string First{get; set;}
        public string Last{get; set;}

        public Person(int height=0, int personcode=0)
        {
            Height=height;
            PersonCode=personcode;

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        Person kevin =new Person(100 ,100);
        kevin.First="HB";
        kevin.Last="P";
        Person Jongyoon = new Person(180 ,180);
        Console.WriteLine("{0}",kevin.PersonCode);
        Console.WriteLine("{0}",Jongyoon.PersonCode);
        List <Person> list= new List <Person>();
        list.Add(kevin);
        list.Add(Jongyoon);
        TextWriter tw = new StreamWriter("SavedList.txt");
        foreach (Person p in list)
        tw.WriteLine(p.First);

        tw.Close();



        }
    }
}