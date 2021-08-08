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
        int Digit=0;

        while((line = Person_1.ReadLine()) != null)  
        {   
            if(check==4)
            {   
                check_grammer=0;
                check=0;
                check++;
            }
            else
            {
                check++;
            }
        
            Lindex= line.IndexOf("---------");
            if (Lindex==0)
            {
                check--;
                continue;
            }

            Lindex= line.LastIndexOf("PersonCode:");
            if(Lindex!=100 && Lindex!=-1)
            {   Console.WriteLine("{0}",line);
                textreader=line.Substring(line.IndexOf("PersonCode:") + "PersonCode:".Length);
                foreach(char ch in textreader)
                {   
                    Digit=0;
                    if(IsNumeric(ch) == true)//숫자인지 검사하는거
                    {
                        Digit++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(Digit==1)
                {   
                    foreach(Person p in people)
                    {
                        if(p.PersonCode==Convert.ToInt16(textreader))//Person Code에 대한 중복확인.
                        {
                            Digit=0;
                            break;
                        }
                    }                    
                    if(Digit == 1 )
                    {
                        aa.PersonCode=(Convert.ToInt16(textreader));
                        check_grammer++;
                        Digit=0;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if(Digit==0)
                {    
                    continue;
                }
            }
    
            Lindex= line.LastIndexOf("FirstName:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("FirstName:") + "FirstName:".Length);
                foreach(char ch in textreader)
                {   
                    alphabet=0;
                    if(IsEnglish(ch) == true)//알파벳인지 검사하는거
                    {
                        alphabet++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(alphabet==1)
                {
                    aa.First=(textreader);
                    check_grammer++;
                    alphabet=0;
                }
                else if(alphabet==0)
                {    
                  //  Console.WriteLine("Firstname이 str형이 아닙니다.");
                    continue;
                }
            }

            Lindex= line.LastIndexOf("LastName:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("LastName:") + "LastName:".Length);
                foreach(char ch in textreader)
                {   
                    alphabet=0;
                    if(IsEnglish(ch) == true)//알파벳인지 검사하는거
                    {
                        alphabet++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(alphabet==1)
                {
                    aa.Last=(textreader);
                    check_grammer++;
                    alphabet=0;
                }
                else if(alphabet==0)
                {    
                  //  Console.WriteLine("Lasttname이 str형이 아닙니다.");
                    continue;
                }
            }

            Lindex= line.LastIndexOf("Height:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("Height:") + "Height:".Length);
                foreach(char ch in textreader)
                {   
                    Digit=0;
                    if(IsNumeric(ch) == true)//숫자인지 검사하는거
                    {
                        Digit++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(Digit==1)
                {
                    aa.Height=(Convert.ToInt16(textreader));
                    check_grammer++;
                    Digit=0;                    
                }
                else if(Digit==0)
                {    
                    continue;
                }
            }

            if(check==4)
            {
                if(check_grammer==4)
                {
                    // Console.WriteLine("기록{0}",aa.PersonCode);
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
            else
            Console.WriteLine("check확인{0}",check);                                                 
        }  
        foreach (Person p in people)
             Console.WriteLine("personcode: {0}, FirstName : {1}, LastName : {2}, Height {3}",p.PersonCode, p.First, p.Last, p.Height);
            // Console.WriteLine("personcode: {0}",p.PersonCode);

        }
        static bool IsEnglish(char ch)//알파벳인지 검사하는거
        {   
            if ((0x61 <= ch && ch <= 0x7A) || (0x41 <= ch && ch <= 0x5A))
                return true;
            else
                return false;
        }
        static bool IsNumeric(char ch)//숫자인지 검사하는거
        {
            if (0x30 <= ch && ch <= 0x39)
                return true;
            else
                return false;
        }
    }        
}