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

    class Product
    {
        public int ProductId {get; set;}
        public int Price {get; set;}
        public string Name{get; set;}
        public string Description {get; set;}
        public int VendorId {get; set;}

        public Product(int productid=0, int price=0, string name=null, string description = null, int vendorid = 0)
        {
            ProductId = productid;
            Name = name;
            Description = description;
            VendorId = vendorid;
            Price = price;
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
            {   //Console.WriteLine("{0}",line);
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
            // else
            // Console.WriteLine("check확인{0}",check);                                                 
        }  
        foreach (Person p in people)
             Console.WriteLine("personcode: {0}, FirstName : {1}, LastName : {2}, Height {3}",p.PersonCode, p.First, p.Last, p.Height);
            // Console.WriteLine("personcode: {0}",p.PersonCode);
        
///-----------------------------------------------------------------------------------------------        
        TextReader Product_1 =new StreamReader("Product.txt");//Person으로 바꿔서하면 1~6까지 결과값나옴
        List <Product> Products = new List <Product>();
        Lindex=100;
        Product bb =new Product();          
        check=0;
        check_grammer=0;
        alphabet=0;
        Digit=0;

        while((line = Product_1.ReadLine()) != null)  
        {   
            if(check==5)
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

            Lindex= line.LastIndexOf("ProductId:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("ProductId:") + "ProductId:".Length);
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
                    bb.ProductId=(Convert.ToInt16(textreader));
                    check_grammer++;
                    Digit=0;                    
                }
                else if(Digit==0)
                {    
                    continue;
                }
            }

    
            Lindex= line.LastIndexOf("Name:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("Name:") + "Name:".Length);
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
                    bb.Name=(textreader);
                    check_grammer++;
                    alphabet=0;
                }
                else if(alphabet==0)
                {    
                  //  Console.WriteLine("Name이 str형이 아닙니다.");
                    continue;
                }
            }

            Lindex= line.LastIndexOf("Price:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("Price:") + "Price:".Length);
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
                    bb.Price=(Convert.ToInt16(textreader));
                    check_grammer++;
                    Digit=0;                    
                }
                else if(Digit==0)
                {    
                    continue;
                }
            }


            Lindex= line.LastIndexOf("Description:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("Description:") + "Description:".Length);
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
                    bb.Description=(textreader);
                    check_grammer++;
                    alphabet=0;
                }
                else if(alphabet==0)
                {    
                  //  Console.WriteLine("Description이 str형이 아닙니다.");
                    continue;
                }
            }

            Lindex= line.LastIndexOf("VendorId:");
            if(Lindex!=100 && Lindex!=-1)
            {
                textreader=line.Substring(line.IndexOf("VendorId:") + "VendorId:".Length);
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
                    bb.VendorId=(Convert.ToInt16(textreader));
                    check_grammer++;
                    Digit=0;                    
                }
                else if(Digit==0)
                {    
                    continue;
                }
            }


            if(check==5)
            {
                if(check_grammer==5)
                {
                    // Console.WriteLine("기록{0}",bb.ProductCod);
                    // Console.WriteLine("{0}",bb.Height);
                    // Console.WriteLine("{0}",bb.First);
                    // Console.WriteLine("{0}",bb.Last);
                    // Console.WriteLine("{0}",bb.Last);
                    Products.Add(new Product(bb.ProductId, bb.Price, bb.Name, bb.Description, bb.VendorId));
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
            // else
            // Console.WriteLine("Personcheck확인{0}",check);                                                 
        }  
        foreach (Product p in Products)
             Console.WriteLine("ProductId: {0}, Name : {1}, Price : {2}, Desecription {3}, VendorId {4}",p.ProductId, p.Name, p.Price, p.Description, p.VendorId);
 
        
        // ///저장을 위한 상위 이중 dictionary 설정
        // Dictionary <Person, Dictionary<int, Product>> Person_Product_Dic = new Dictionary<Person, Dictionary <int, Product>>() ;
        // /// 저장을 위한 하위 dictionary 설정
        // Dictionary <int, Product> Product_Dic = new Dictionary<int, Product> ();
        // foreach (Product p in Product)
        // {   
        //     Product_Dic.Add(p.ProductId, new Product(p.ProductId, p.Price, p.Name, p.Description, p.VendorId));
        // }


        /////저장을 위한 dictionary 설정
        Dictionary <Person, List<Product>> Person_Product_Dic = new Dictionary<Person, List<Product>>() ;

        TextReader Person_Product_rel =new StreamReader("PersonProduct_Relationship.txt");      
        
        Dictionary <int, List<int>> Dic_rel= new Dictionary<int, List<int>>();

        while((line = Person_Product_rel.ReadLine()) !=null)
        {
            string [] spstring = line.Split("-");
            string [] spstring_sub = spstring[1].Split(",");
            List <int> spstring_int = new List<int>() ;
            foreach(string i in spstring_sub )
            {
                spstring_int.Add(Convert.ToInt32(i));
            }
            Dic_rel.Add(Convert.ToInt32(spstring[0]), spstring_int);
        }
        
        // // 제대로 들어갔는지 확인.
        // foreach ( KeyValuePair<int, List<int>> pair in Dic_rel)
        // {
        //     Console.WriteLine("key:{0}, Value:{1}", pair.Key, pair.Value[0]);
        // }
        
        
        //// Person_Product_Dic에 저장 시작               

        foreach ( KeyValuePair<int, List<int>> pair in Dic_rel)
        {   
            Person key_person=new Person();    
            List <Product> value_Products = new List <Product>();

            foreach(Person person_id in people)
            {
                if(person_id.PersonCode == pair.Key)
                {
                    key_person=person_id;
                }
            }
            //key값이 없어도 스킵
            if(key_person.PersonCode==0)
            {
                continue;
            }    

            foreach(int i in pair.Value)
            {
                foreach(Product product_id in Products)
                {
                    if(product_id.ProductId==i)
                    {
                        value_Products.Add(product_id);
                    }
                }
            }
            /// list에 하나도 없으면 스킵
            if(value_Products.Count==0)
            {
                continue;
            }           

            Person_Product_Dic.Add(key_person, value_Products);                    
        }
        /// 잘 저장됬는지 확인.
        foreach ( KeyValuePair<Person, List<Product>> pair in Person_Product_Dic)
        {
            // Console.Write("key:{0}, Value:{1}", pair.Key.PersonCode, pair.Value[1].ProductId);
            Console.Write("key:{0},", pair.Key.PersonCode);            

            foreach(Product i in pair.Value)
            {
                Console.Write(" Value:{0}",i.ProductId);
            }
            Console.Write("\n");
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