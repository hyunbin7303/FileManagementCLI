using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
    ///-------Person 받기
            string filename="Person_ErrorCase.txt";
            List <Person> people = new List <Person>();
            Person.Get_People(ref people, filename);    

            foreach (Person p in people)
                Console.WriteLine("personcode: {0}, FirstName : {1}, LastName : {2}, Height {3}",p.PersonCode, p.First, p.Last, p.Height);
            
    ///-------Product 받기        
            string filename_product="Product.txt";
            List <Product> Products = new List <Product>();
            Product.Get_Product(ref Products, filename_product);    
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
            
            string line;

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
    }

}