using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {

            int pageSize = 10;
            var temp = new BooksListViewModel
            {
                Books = _repo.Books
                .OrderBy(x => x.BookId)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }

            };
            return View(temp);
        }
    }
}
