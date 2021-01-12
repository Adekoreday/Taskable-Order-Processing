using BooksAndVideos.App.Entities;
using System.Collections.Generic;

namespace BooksAndVideos.App.Services
{
    public interface IGeneratePrintSlipService
    {
       void Print(List<Product> p);
    }
}
