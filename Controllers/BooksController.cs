using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookListRazor.Model;

using Microsoft.AspNetCore.Mvc;

namespace BooksListRazor.Controllers
{
    [Route ("api/Books")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BookDbContext _dbContext;

        public BooksController (BookDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException (nameof (dbContext));
        }

        [HttpGet]
        public IActionResult GetAll ()
        {
            return Json (new { data = _dbContext.Books.ToList () });
        }
    }
}
