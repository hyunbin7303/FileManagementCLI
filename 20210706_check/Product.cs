using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp4
{
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
    

        public static void Get_Product(ref List <Product> Products, string file )
        {
            string textreader;
            string line;
            int Lindex=100;
            int check=0;
            int check_grammer=0;
            int alphabet=0;
            int Digit=0;  

            TextReader Product_1 =new StreamReader(file);//Person으로 바꿔서하면 1~6까지 결과값나옴
            Product bb =new Product();        

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
                        Products.Add(new Product(bb.ProductId, bb.Price, bb.Name, bb.Description, bb.VendorId));
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