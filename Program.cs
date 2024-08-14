using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Numerics;

namespace LINQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region LINQ - Restriction Operators

            ////1.Find all products that are out of stock.
            //var res=listGenerator.ProductList.Where(P => P.UnitsInStock == 0);
            //foreach (var item in res) 
            //{
            //    Console.WriteLine(item);
            //}

            ////2.Find all products that are in stock and cost more than 3.00 per unit.
            //var res = listGenerator.ProductList.Where(P => P.UnitsInStock>0&&P.UnitPrice>3.0m );
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////3.Returns digits whose name is shorter than their value.
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var res = Arr.Select((name, index) => new { Name = name, Value = index }).Where(item => item.Name.Length < item.Value).Select(item => item.Value);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Element Operators

            ////1.Get first Product out of Stock
            //var res = listGenerator.ProductList.Where(P=>P.UnitsInStock == 0 ).First();
            //Console.WriteLine(res);


            ////2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            //var res = listGenerator.ProductList.Where(P => P.UnitPrice>1000).SingleOrDefault();
            //Console.WriteLine(res);

            ////3.Retrieve the second number greater than 5
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res = Arr.Where(n => n > 5).Skip(1).FirstOrDefault();         
            //Console.WriteLine(res);

            #endregion

            #region Aggregate Operators

            ////1.Uses Count to get the number of odd numbers in the array
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res =Arr.Count(N=>N%2==1);
            //Console.WriteLine(res);

            ////2.Return a list of customers and how many orders each has.
            //var res = listGenerator.CustomerList.Select(C=> new { C,Orders_Count=C.Orders.Count() });
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////3.Return a list of categories and how many products each has
            //var res = listGenerator.ProductList.Select(P=>new { Category=P.Category,Category_Count=P.Category.Count() }).Distinct();
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////4.Get the total of the numbers in an array.
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res =Arr.Sum(x => x);
            //Console.WriteLine(res);

            ////5.Get the total number of characters of all words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //string[] lines = File.ReadAllLines("dictionary_english.txt");
            //var res = lines
            //    .Where(line => !string.IsNullOrWhiteSpace(line))
            //    .Select(line => line.Trim())
            //    .ToArray().Count();
            //Console.WriteLine(res);

            ////6.Get the length of the shortest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //string[] lines = File.ReadAllLines("dictionary_english.txt");
            //string longest = lines.OrderBy(word => word.Length).FirstOrDefault();
            //var res = longest.Length;
            //Console.WriteLine(res);

            ////7.Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //string[] lines = File.ReadAllLines("dictionary_english.txt");
            //string longest = lines.OrderByDescending(word => word.Length).FirstOrDefault();
            //var res = longest.Length;
            //Console.WriteLine(res);


            ////8.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //string[] lines = File.ReadAllLines("dictionary_english.txt");
            //var res = lines
            //    .Average(P => P.Length);
            //Console.WriteLine((int)res);

            ////9.Get the total units in stock for each product category.
            //var res = listGenerator.ProductList
            // .GroupBy(p => p.Category)
            // .Select(g => new
            // {
            //     Category = g.Key,
            //     Total = g.Sum(p => p.UnitsInStock)
            // });
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"Category: {item.Category}, Total Units in Stock: {item.Total}");
            //}

            ////10.Get the cheapest price among each category's products
            //var res = listGenerator.ProductList
            //.GroupBy(p => p.Category).Select(g => new
            //{
            //    Category = g.Key,
            //    Cheapest = g.Min(p => p.UnitPrice)
            //});
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"Category: {item.Category}, Cheapest: {item.Cheapest}");
            //}

            ////11.Get the products with the cheapest price in each category(Use Let)
            //var res = from p in listGenerator.ProductList
            //                                 group p by p.Category into g
            //                                 let minPrice = g.Min(p => p.UnitPrice)
            //                                 select new
            //                                 {
            //                                     Category = g.Key,
            //                                     cheap = g.First(p => p.UnitPrice == minPrice)
            //                                 };
            //foreach (var category in res)
            //{
            //    Console.WriteLine($"Category: {category.Category}, Product: {category.cheap.ProductName}, Price: {category.cheap.UnitPrice}");
            //}

            ////12.Get the most expensive price among each category's products.
            //var res = listGenerator.ProductList
            //.GroupBy(p => p.Category)
            //.Select(g => new
            //{
            //    Category = g.Key,
            //   exp = g.Max(p => p.UnitPrice)
            //});
            //foreach (var category in res)
            //{
            //    Console.WriteLine($"Category: {category.Category}, Price: {category.exp}");
            //}

            ////13.Get the products with the most expensive price in each category.
            //var res = listGenerator.ProductList
            //.GroupBy(p => p.Category)
            //.Select(g => new
            //{
            //    Category = g.Key,
            //    exp = g.OrderByDescending(p => p.UnitPrice).FirstOrDefault()
            //});

            //foreach (var category in res)
            //{
            //    Console.WriteLine($"Category: {category.Category}, Product: {category.exp.ProductName}, Price: {category.exp.UnitPrice}");
            //}

            ////14.Get the average price of each category's products. 
            //var res = listGenerator.ProductList
            //.GroupBy(p => p.Category)
            //.Select(g => new
            //{
            //    Category = g.Key,
            //    Average = g.Average(p => p.UnitPrice)
            //});

            //foreach (var category in res)
            //{
            //    Console.WriteLine($"Category: {category.Category}, Average: {category.Average}");
            //}


            #endregion

            #region Ordering Operators

            //1.Sort a list of products by name
            //var res = listGenerator.ProductList.OrderBy(P => P.ProductName);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            //2.Uses a custom comparer to do a case -insensitive sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var res = Arr.OrderBy(word => word, StringComparer.OrdinalIgnoreCase).ToArray();

            //// Print the sorted array
            //foreach (string word in res)
            //{
            //    Console.WriteLine(word);
            //}

            ////3.Sort a list of products by units in stock from highest to lowest.
            //var res = listGenerator.ProductList.OrderByDescending(P => P.UnitsInStock);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////4.Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var res = Arr.OrderBy(word => word.Length).ThenBy(word => word).ToArray();
            //foreach (string item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////5.Sort first by-word length and then by a case -insensitive sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var res = Arr.OrderBy(word => word.Length)
            //       .ThenBy(word => word, StringComparer.OrdinalIgnoreCase)
            //       .ToArray();
            //foreach (string item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////6.Sort a list of products, first by category, and then by unit price, from highest to lowest.
            //var res = listGenerator.ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"{item.Category} - {item.ProductName}: {item.UnitPrice:C}");
            //}

            ////7.Sort first by-word length and then by a case -insensitive descending sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var res = Arr
            //.OrderBy(word => word.Length)
            //.ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            //8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var res = Arr.Where(word => word.Length > 1 && word[1] == 'i').Reverse().ToList();

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Transformation Operators

            ////1.Return a sequence of just the names of a list of products.
            //var res = listGenerator.ProductList.Select(p => p.ProductName);
            //foreach (var item in res) 
            //{ 
            //    Console.WriteLine(item);
            //}

            ////2.Produce a sequence of the uppercase and lowercase versions of each word in the original array(Anonymous Types).
            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry"};
            //var res = words.Select(word => new
            //{
            //    Upper = word.ToUpper(),
            //    Lower = word.ToLower()
            //});
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"Uppercase: {item.Upper}, Lowercase: {item.Lower}");
            //}

            ////3.Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            //var res = listGenerator.ProductList.Select(p => new
            //{
            //    p.ProductID,
            //    p.ProductName,
            //    Price = p.UnitPrice, // Renaming UnitPrice to Price
            //    p.UnitsInStock
            //});
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"ID: {item.ProductID}, Name: {item.ProductName}, Price: {item.Price}, Stock: {item.UnitsInStock}");
            //}

            ////4.Determine if the value of int in an array match their position in the array.
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res = Arr
            // .Select((value, index) => new { Value = value, MatchesPosition = (value == index) })
            // .ToList();
            //Console.WriteLine("Number: in place?");
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"{item.Value}: {item.MatchesPosition}");
            //}

            ////5.Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };
            //var res = from a in numbersA
            //          from b in numbersB
            //          where a < b
            //          select (a, b);
            //Console.WriteLine("Pairs where a<b");
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"{item.a} is less than {item.b}");
            //}

            ////6.Select all orders where the order total is less than 500.00.
            //var res = listGenerator.CustomerList.SelectMany(C=>C.Orders).Where(C=>C.Total<500);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////7.Select all orders where the order was made in 1998 or later. 
            //var res = listGenerator.CustomerList.SelectMany(C => C.Orders).Where(C => C.OrderDate.Year>= 1998);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Set Operators

            ////1.Find the unique Category names from Product List
            //var res = listGenerator.ProductList.Select(P => P.Category).Distinct();
            //foreach (var item in res) 
            //{ 
            //    Console.WriteLine(item);
            //}

            ////2.Produce a Sequence containing the unique first letter from both product and customer names.
            //var res = (listGenerator.ProductList.Select(P => P.ProductName[0]).Union(listGenerator.CustomerList.Select(C => C.CustomerName[0]))).Distinct().ToList();
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////3.Create one sequence that contains the common first letter from both product and customer names.
            //var res = (listGenerator.ProductList.Select(P => P.ProductName[0]).Intersect(listGenerator.CustomerList.Select(C => C.CustomerName[0]))).Distinct().ToList();
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////4.Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            //var res = (listGenerator.ProductList.Select(P => P.ProductName[0]).Except(listGenerator.CustomerList.Select(C => C.CustomerName[0]))).Distinct().ToList();
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////5.Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            //var res = listGenerator.ProductList
            //.Select(p => p.ProductName.Length >= 3 ? p.ProductName[^3..] : p.ProductName)
            //.Concat(listGenerator.CustomerList.Select(c => c.CustomerName.Length >= 3 ? c.CustomerName[^3..] : c.CustomerName))
            //.ToList();
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region LINQ - Partitioning Operators

            ////1.Get the first 3 orders from customers in Washington
            // var res = listGenerator.CustomerList
            //.Where(c => c.City == "Berlin")////no Berlin Washington
            //.SelectMany(c => c.Orders)
            //.Take(3);
            // foreach (var item in res) 
            // {
            // Console.WriteLine(item);
            // }

            ////2.Get all but the first 2 orders from customers in Washington.
            //var res = listGenerator.CustomerList
            //.Where(c => c.City == "Berlin")
            //.SelectMany(c => c.Orders)
            //.Skip(2);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////3.Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res = numbers
            //.TakeWhile((number, index) => number >= index);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////4.Get the elements of the array starting from the first element divisible by 3.
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var res = numbers
            //.SkipWhile(n => n % 3 != 0);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ////5.Get the elements of the array starting from the first element less than its position.
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 
            //var res = numbers.SkipWhile((n, index) => n >= index);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Quantifiers

            ////1.Determine if any of the words in dictionary_english.txt contain the substring 'ei'.
            //string[] words = File.ReadAllLines("dictionary_english.txt");
            //var wordsWithEi = words.Where(word => word.Contains("ei"));
            //Console.WriteLine("Words containing 'ei':");
            //foreach (var word in wordsWithEi)
            //{
            //    Console.WriteLine(word);
            //}

            ////2.Return a grouped list of products only for categories that have at least one product that is out of stock.
            //var res = listGenerator.ProductList
            //.GroupBy(p => p.Category)
            //.Where(g => g.Any(p => p.UnitsInStock == 0))
            //.Select(g => new { Category = g.Key, Products = g });
            //foreach (var item in res)
            //{
            //    foreach (var itemm in item.Products)
            //    {
            //        Console.WriteLine(item.Category + "  " + itemm);
            //    }
            //}

            ////3.Return a grouped a list of products only for categories that have all of their products in stock.
            //var res = listGenerator.ProductList
            //.GroupBy(p => p.Category)
            //.Where(g => g.All(p => p.UnitsInStock > 0))
            //.Select(g => new { Category = g.Key, Products = g });
            //foreach (var item in res)
            //{
            //    foreach (var itemm in item.Products)
            //    {
            //        Console.WriteLine(item.Category + "  " + itemm);
            //    }
            //}

            #endregion

            #region Grouping Operators

            ////1.Use group by to partition a list of numbers by their remainder when divided by 5
            //List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            //var res = numbers
            //.GroupBy(n => n % 5)
            //.Select(g => new { Remainder = g.Key, Numbers = g });
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"Numbers with remainder of {item.Remainder} when divided by 5");
            //    foreach (var itemm in item.Numbers)
            //    {
            //        Console.WriteLine(" "+itemm);
            //    }
            //}

            ////2.Uses group by to partition a list of words by their first letter.
            //var words = File.ReadAllLines("dictionary_english.txt");
            //var res = words
            //    .GroupBy(word => word[0])
            //    .Select(g => new { FirstLetter = g.Key, Words = g });
            //foreach (var item in res)
            //{
            //    foreach (var word in item.Words)
            //    {
            //        Console.WriteLine(word);
            //    }
            //}

            ////3.Consider this Array as an Input
            ////Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            //string[] Arr = { "from", "salt", "earn", " last", "near", "form"};
            //var res = Arr.GroupBy(word => new string(word.OrderBy(c => c).ToArray()));
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"Group: {string.Join(", ", item)}");
            //}

            #endregion

        }
    }
}
