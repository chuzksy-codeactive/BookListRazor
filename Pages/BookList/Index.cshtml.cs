using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookListRazor.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly BookDbContext _dbContext;
        public IEnumerable<Book> Books { get; set; }

        public IndexModel (BookDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException (nameof (dbContext));
        }
        public async Task OnGetAsync ()
        {
            Books = await _dbContext.Books.ToListAsync ();
        }

        public async Task<IActionResult> OnPostDelete (Guid bookId)
        {
            var book = await _dbContext.Books.FindAsync (bookId);

            if (book == null)
            {
                return NotFound ();
            }

            _dbContext.Remove (book);
            await _dbContext.SaveChangesAsync ();

            return RedirectToPage ("Index"); 
        }
    }
}
