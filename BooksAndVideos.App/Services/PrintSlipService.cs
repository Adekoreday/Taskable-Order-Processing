using BooksAndVideos.App.Entities;
using System.Collections.Generic;
using System;

namespace BooksAndVideos.App.Services
{
    public class PrintSlip : IGeneratePrintSlipService
    {
        public void Print(List<Product> product)
        {
            foreach (Product p in product) {
            Console.WriteLine("Generating Slip adding {0} to slip", p.Name);
            }
        }
    }
}
