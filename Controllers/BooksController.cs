using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookListRazor.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll ()
        {
            return Json (new { data = await _dbContext.Books.ToListAsync () });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (Guid id)
        {
            var bookFromDb = await _dbContext.Books.FirstOrDefaultAsync (u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json (new { success = false, message = "Error while Deleting" });
            }
            _dbContext.Books.Remove (bookFromDb);
            await _dbContext.SaveChangesAsync ();
            return Json (new { succues = true, message = "Delete successful" });
        }
    }
}
