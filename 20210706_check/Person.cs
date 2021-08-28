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
    

        public static void Get_People(ref List <Person> people, string file )
        {
            string textreader;
            string line;
            TextReader Person_1 =new StreamReader(file);//Person으로 바꿔서하면 1~6까지 결과값나옴
            // List <Person> people = new List <Person>();
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
                {   
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
                        people.Add(new Person(aa.Height,aa.PersonCode,aa.First,aa.Last));
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
