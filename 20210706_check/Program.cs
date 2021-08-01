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

        public Person(int height=0, int personcode=0, string first=null, string last = null)
        {
            Height=height;
            PersonCode=personcode;
            First = first;
            Last = last;

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        // List <Person> list= new List <Person>();
        // list.Add(kevin);
        // kevin.First="HB2";
        // list.Add(kevin);
        // TextWriter tw = new StreamWriter("SavedList.txt");
        // foreach (Person p in list)
        // tw.WriteLine(p.First);

        // tw.Close();
        // string myString = "hi there IP:127.0.0.1";
        // string toBeSearched = "IP:";
        // string ipaddr = myString.Substring(myString.IndexOf(toBeSearched) + toBeSearched.Length);
        string textreader;
        string line;
        TextReader Person_1 =new StreamReader("Person_ErrorCase.txt");//Person으로 바꿔서하면 1~6까지 결과값나옴
        List <Person> people = new List <Person>();
        int Lindex=100;
        Person aa =new Person();          
        int check=0;
        int check_grammer=0;
        int alphabet=0;

        while((line = Person_1.ReadLine()) != null)  
        {   check++;
            Lindex= line.IndexOf("---------");
            if (Lindex==0)
            {
                check--;
                continue;
            }
            Lindex= line.LastIndexOf("Height:");
            if(Lindex!=100 && Lindex!=-1)
            {   
                textreader=line.Substring(line.IndexOf("Height:") + "Height:".Length);
                try//int로 변환되면 등록 아니면 스킵
                {   aa.Height=(Convert.ToInt16(textreader));
                    check_grammer++;
                }
                catch(FormatException)
                    {   
                        Console.WriteLine("Height가 int형이 아닙니다.");
                    }                
            }
            Lindex= line.LastIndexOf("PersonCode:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("PersonCode:") + "PersonCode:".Length);
                try//int로 변환되면 등록 아니면 스킵
                {   aa.PersonCode=(Convert.ToInt16(textreader));
                    check_grammer++;
                }
                catch(FormatException)
                    {   
                        Console.WriteLine("Personcode가 int형이 아닙니다.");
                    }    
            }
            Lindex= line.LastIndexOf("FirstName:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("FirstName:") + "FirstName:".Length);
                foreach(char ch in textreader)//알파벳인지 검사하는거
                {
                    if ((0x61 > ch || ch > 0x7A) && (0x41 > ch || ch > 0x5A))
                    {
                        alphabet++;
                    }
                }
                if(alphabet==0)
                {
                    aa.First=(textreader);
                    check_grammer++;
                }
                else if(alphabet>0)
                {    
                    Console.WriteLine("Firstname이 str형이 아닙니다.");
                    alphabet=0;
                }
            }
            Lindex= line.LastIndexOf("LastName:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("LastName:") + "LastName:".Length);
                foreach(char ch in textreader)//알파벳인지 검사하는 거
                {
                    if ((0x61 > ch || ch > 0x7A) && (0x41 > ch || ch > 0x5A))
                    {
                        alphabet++;
                    }
                }
                if(alphabet==0)
                {
                    aa.Last=(textreader);
                    check_grammer++;
                }
                else if(alphabet>0)
                {    
                    Console.WriteLine("Lastname이 str형이 아닙니다.");
                    alphabet=0;
                }
            }           
            if(check==4)
            {
                if(check_grammer==4)
                {
                    // Console.WriteLine("{0}",aa.PersonCode);
                    // Console.WriteLine("{0}",aa.Height);
                    // Console.WriteLine("{0}",aa.First);
                    // Console.WriteLine("{0}",aa.Last);
                    people.Add(new Person(aa.Height,aa.PersonCode,aa.First,aa.Last));
                    // Console.WriteLine("check{0}",check);
                    // Console.WriteLine("check_grammer{0}",check_grammer);
                    check=0;
                    check_grammer=0;
                }
                else
                {
                    check=0;
                    check_grammer=0;
                }
             }                                                 
        }  
        foreach (Person p in people)
        Console.WriteLine("리스트에 들어있는애들 personcode{0}",p.PersonCode);
        }
    }
}