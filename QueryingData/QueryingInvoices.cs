using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Jennifer Faron
//Assignment 4, Question 9.3
//Querying Invoices

namespace Assignment4
{
   class QueryingInvoices
   {
      public static void Main(string[] args)
      {
         var invoices = new[]
         {
            new Invoice(83, "Electric Sander", 7, 57.98M),
            new Invoice(24, "Power saw", 18, 99.99M),
            new Invoice(7, "Sledge hammer", 11, 21.50M),
            new Invoice(77, "Hammer", 76, 11.99M),
            new Invoice(39, "Lawn mower", 3, 79.50M),
            new Invoice(68, "Screwdriver", 106, 6.99M),
            new Invoice(56, "Jig saw", 21, 11.00M),
            new Invoice(3, "Wrench", 34, 7.50M)

         };

         Console.WriteLine("Original array:");
         foreach (var element in invoices)
         {
            Console.WriteLine(element);
         }


         var descriptionSorted =
            from i in invoices
            orderby i.PartDescription
            select i;

         Console.WriteLine("\nInvoices sorted by part description:");
         foreach(var element in descriptionSorted)
         {
            Console.WriteLine(element);
         }

         var priceSorted =
            from i in invoices
            orderby i.Price
            select i;

         Console.WriteLine("\nInvoices sorted by price:");
         foreach(var element in priceSorted)
         {
            Console.WriteLine(element);
         }

         var descriptionAndQuantity =
            from i in invoices
            orderby i.Quantity
            select new { i.Quantity, i.PartDescription };

         Console.WriteLine("\nInvoices with Quantity and Part Descriptions, sorted by Quantity:");
         foreach(var element in descriptionAndQuantity)
         {
            Console.WriteLine(element);
         }


         var invoiceValue =
            from i in invoices
            let InvoiceTotal = i.Quantity * i.Price
            orderby InvoiceTotal
            select new { InvoiceTotal, i.PartDescription };

         Console.WriteLine("\nInvoice Totals and Part Descriptions, sorted by Invoice Totals:");
         foreach(var element in invoiceValue)
         {
            Console.WriteLine(element);
         }


         var between2And5 =
            from i in invoices
            let InvoiceTotal = i.Quantity * i.Price
            where (InvoiceTotal >= 200) && (InvoiceTotal <= 500)
            orderby InvoiceTotal
            select new { InvoiceTotal, i.PartDescription };

         Console.WriteLine("\nInvoice Totals and Part Descriptions between 200 and 500 dollars:");
         foreach(var element in between2And5)
         {
            Console.WriteLine(element);
         }


         Console.WriteLine();
      }
   }
}
