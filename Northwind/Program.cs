using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Northwind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a choice");
            Console.WriteLine("1 ..LIST ALL THE DATA FROM THE Product TABL");
            Console.WriteLine("2. LIST ALL THE DATA FROM THE Product TABLE ORDER BY ProductName");
            Console.WriteLine("3. LIST ALL THE DATA FROM THE Product TABLE Where QuantityPerUnit can be \"jars\" \r\nor \"bottles");
            Console.WriteLine(" 4.From Product table LIST DISTINCT CategoryID");
            Console.WriteLine("/5.List all the products whose UnitsInStock is less the Reorder leve");

            Console.WriteLine("6.List all the products which are discontinue");

            Console.WriteLine("/ 7. List all product id, name, unitprice, unitinstock and stock value \r\n(UnitPrice * UnitsInStock)\r\n // arrange all the record as per stock value highest to \r\nlowest\r\n // remove the records where stock value is zero (0)");

            Console.WriteLine("8 . DISPLAY FirstName, LastName, Country, City OF ALL EMPLOYEES, SORTED ON \r\nDESCENDING ORDER OF Country AND WITHIN Country SORTED ON THE DESCENDING ORDER OF \r\nCity");

            Console.WriteLine("9 .List all employees staying in USA - Seattle");

            Console.WriteLine("10 List all employees hired in October 1993");
            int choice=Convert.ToInt32(Console.ReadLine());

            NorthwindEntities1 north = new NorthwindEntities1();

            switch (choice)
            {
                case 1:

                    //1.LIST ALL THE DATA FROM THE Product TABLE
                    Console.WriteLine("by declarative");

                    

                    var query1 = from p in north.Products select new {p.ProductID,p.ProductName,p.CategoryID,p.UnitPrice };

                    foreach (var item in query1)
                    {
                        Console.WriteLine(item.ProductID + " "+item.ProductName+" "+item.CategoryID+" "+item.UnitPrice);
                    }

                    Console.WriteLine("by method");

                    query1 = north.Products.Select(p=>new { p.ProductID, p.ProductName, p.CategoryID, p.UnitPrice });


                    foreach (var item in query1)
                    {
                        Console.WriteLine(item.ProductID + " " + item.ProductName + " " + item.CategoryID + " " + item.UnitPrice);
                    }


                    break;

            case 2:
                    //2. LIST ALL THE DATA FROM THE Product TABLE ORDER BY ProductNam
                    Console.WriteLine("by declarative");

                    var qury2 = from p in north.Products orderby p.ProductName select new { p.ProductID, p.ProductName, p.CategoryID, p.UnitPrice };
                    foreach (var item in qury2)
                    {
                        Console.WriteLine(item.ProductID + " " + item.ProductName + " " + item.CategoryID + " " + item.UnitPrice);
                    }


                    Console.WriteLine("by method");
                    Console.WriteLine("-------------------------------");

                   var qury3=north.Products.OrderBy(p=>p.ProductName).Select(p => new { p.ProductID, p.ProductName, p.CategoryID, p.UnitPrice });


                    foreach (var item in qury3)
                    {
                        Console.WriteLine(item.ProductID + " " + item.ProductName + " " + item.CategoryID + " " + item.UnitPrice);
                    }



                    break;


            case 3:
                    // LIST ALL THE DATA FROM THE Product TABLE Where QuantityPerUnit can be "jars" 
                  //  or "bottles"


                    Console.WriteLine();
                    Console.WriteLine("by declarative");

                    var query3 = from p in north.Products where (p.QuantityPerUnit.Contains("bottles") || p.QuantityPerUnit.Contains("jars")) select new { p.ProductID, p.ProductName, p.CategoryID, p.UnitPrice,p.QuantityPerUnit };
                    foreach (var item in query3)
                    {
                        Console.WriteLine(item.ProductID + " " + item.ProductName + " " + item.CategoryID + " " + item.UnitPrice+" "+item.QuantityPerUnit);
                    }


                    Console.WriteLine("by method");
                    Console.WriteLine("-------------------------------");

                    var query4 = north.Products.Where(p => p.QuantityPerUnit.Contains("bottles") || p.QuantityPerUnit.Contains("jars")).Select(p=>new { p.ProductID, p.ProductName, p.CategoryID, p.UnitPrice, p.QuantityPerUnit });

                    foreach (var item in query4)
                    {
                        Console.WriteLine(item.ProductID + " " + item.ProductName + " " + item.CategoryID + " " + item.UnitPrice + " " + item.QuantityPerUnit);
                    }


                    break;

                case 4:

                    //

                    // 4.From Product table LIST DISTINCT CategoryI
                    Console.WriteLine("by declarative");

                    var query5 = (from p in north.Products select p.CategoryID).Distinct();

                    foreach (var item in query5)
                        Console.WriteLine(  item);

                    Console.WriteLine("by method");
                    Console.WriteLine("-------------------------------");

                    //var query6=north.Products.Distinct().Select(p=>p.CategoryID);

                    
                    break;

                case 5:

                    //5.List all the products whose UnitsInStock is less the Reorder leve
                    Console.WriteLine("by declarative");

                    var query7 = from p in north.Products where p.UnitsInStock < p.ReorderLevel select new { p.ProductID, p.ProductName, p.CategoryID, p.UnitPrice };

                    foreach (var item in query7)
                    {
                        Console.WriteLine(item.ProductID + " " + item.ProductName + " " + item.CategoryID + " " + item.UnitPrice);
                    }

                    Console.WriteLine("-------------------------------");

                    Console.WriteLine("by method");
                    
                    break;

                case 6:

                    // 6.List all the products which are discontinued
                    Console.WriteLine("by declarative");

                    var query8 = from p in north.Products where (bool)p.Discontinued select new { p.ProductID, p.ProductName, p.CategoryID, p.UnitPrice };

                    foreach (var item in query8)
                    {
                        Console.WriteLine(item.ProductID + " " + item.ProductName + " " + item.CategoryID + " " + item.UnitPrice);
                    }

                    Console.WriteLine("-------------------------------");

                    Console.WriteLine("by method");

                    break;

            case 7:
                                    //// 7. List all product id, name, unitprice, unitinstock and stock value 
                                    //(UnitPrice * UnitsInStock)
                 // arrange all the record as per stock value highest to 
                //lowest
                                    // remove the records where stock value is zero (0)

                    var query9 = (from p in north.Products
                                  where p.UnitsInStock!=0
                                 orderby p.UnitsInStock descending
                                 select new {p.ProductID,p.ProductName,p.UnitPrice,p.UnitsInStock,value=p.UnitPrice*p.UnitsInStock });

                    foreach (var item in query9)
                    {
                        Console.WriteLine(item.ProductID+" "+item.value+" "+item.ProductName);
                    }

                    break;

            case 8: Console.WriteLine();

                    // 8 . DISPLAY FirstName, LastName, Country, City OF ALL EMPLOYEES, SORTED ON 
                    //DESCENDING ORDER OF Country AND WITHIN Country SORTED ON THE DESCENDING ORDER OF
                    //City


                    var query10 = from e in north.Employees
                                  orderby e.Country descending,e.City descending

                                  select e;

                   // query10 = north.Employees;

                    foreach (var item in query10)
                    {
                        Console.WriteLine(item.FirstName+" "+item.LastName+" "+
                            item.Country+" "+item.City);
                    }

                    break;

            case 9: Console.WriteLine();

                    //9 .List all employees staying in USA - Seattl

                    var query11 = from e in north.Employees where e.City == "Seattle" select e;

                    foreach (var item in query11)
                    {
                        Console.WriteLine(item.FirstName + " " + item.LastName + " " +
                            item.Country + " " + item.City);
                    }
                    break;


                case 10: Console.WriteLine();

                   // var query12=from e in north.Employees where e.HireDate.
                    //var query12=north.Employees.Where(e=>e.HireDate)
                    break;

            case 11: Console.WriteLine();
                    //11 LIST TOTAL stock of all the product
                    var query13 = (from p in north.Products select p).Sum(p => p.UnitsInStock*p.UnitPrice);

                    Console.WriteLine(query13);
                    break;
            case 12: Console.WriteLine();
                    //12 . LIST TOTAL PRODUCTS COUNT FOR EACH CATEGOR
                    var query14 = (from p in north.Products group p by p.CategoryID into g select new {g.Key,count=g.Count()});

                    foreach (var item in query14)
                    {
                        Console.WriteLine(item.Key+" "+item.count);

                    }

                    

                    break;

            case 13: Console.WriteLine();

                    //13 LIST FIRST THREE costliest Product

                    var query15 =north.Products.OrderByDescending(p=>p.UnitPrice).Select(p=>p).Take(3);

                    foreach (var item in query15)
                    {
                        Console.WriteLine(item.ProductID+" "+item.ProductName+" "+item.UnitPrice);
                    }
                    break;
            case 14:
                    

                    //14 insert two Category records 
                    // Electronics
                    // Stationary

                    Category category = new Category();

                    category.CategoryID = 11;
                   // category.CategoryID
                    category.Description = "Stationary item";
                    category.CategoryName = "Stationary";

                    north.Categories.Add(category);

                   north.SaveChanges();
                    break;

            case 15: Console.WriteLine();

                   // 15.LIst CategoryName, ProductName and UnitPrice
                    // sort on categoryname

                    var query17 =from p in north.Products join c in north.Categories on p.CategoryID equals
                                c.CategoryID into g
                                from p1 in g
                                orderby p1.CategoryName 
                                select new {p1.CategoryName,p.ProductName,p.UnitPrice};

                    foreach (var item in query17)
                    {
                        Console.WriteLine(item.CategoryName+" "+item.ProductName+" "+item.UnitPrice);
                    }

                    break;
                case 16:

                    // 16.LIst categoryname where products are availabl
                    var query18 = (from c in north.Products
                                  join p in north.Products
                                 on c.CategoryID equals p.CategoryID into g
                                  from p1 in g
                                  where p1.UnitsInStock != 0
                                  select new { p1.Category.CategoryName }).Distinct();


                    foreach (var item in query18)
                    {
                        Console.WriteLine(item.CategoryName);
                    }

                    break;

                case 17:

                    //17.LIst categoryname where products are avaialable
                    // Also include categoryname where no products are available
                    var query19 = (from c in north.Categories select c.CategoryName).Distinct();

                    foreach (var item in query19)
                    {
                        Console.WriteLine(item);
                    }


                    break;

                case 18:
                    //18 list ProductName, CategoryName and Supplier table - company name
                    // Multi table join


                    var query = from p in north.Products
                                join c in north.Categories on p.CategoryID
                              equals c.CategoryID into g
                                from t1 in g.ToList()
                                join s in north.Suppliers
                                on p.SupplierID equals
                                s.SupplierID into table
                                from t2 in table.ToList()
                                select new {p.ProductName,t1.CategoryName,t2.CompanyName };

                    foreach (var item in query)
                    {
                        Console.WriteLine(item.ProductName+" "+item.CategoryName+" "+item.CompanyName);
                    }

                       break;

                case 19:
                    // 19. Update record
                    // Category Table
                    // for newly added Category (Electronics ) add description


                    Category query23 =( from e in north.Categories where e.CategoryID == 10 select e).SingleOrDefault();

                    query23.Description = "updated one";

                    north.SaveChanges();

                    break;

                case 20:

                    //20 Delete record of Stationary from Category tabl
                    var query24 = (from e in north.Categories where e.CategoryID == 10 select e).SingleOrDefault();

                    north.Categories.Remove(query24);

                    north.SaveChanges();
                   

                    break;
            }

            Console.ReadLine();
        }
    }
}
