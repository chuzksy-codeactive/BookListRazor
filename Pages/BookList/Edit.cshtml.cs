using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookListRazor.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly BookDbContext _dbContext;

        [BindProperty]
        public Book Book { get; set; }

        public EditModel (BookDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException (nameof (dbContext));
        }
        public async Task OnGet (Guid bookId)
        {
            Book = await _dbContext.Books.FindAsync(bookId);
        }

        public async Task<IActionResult> OnPost ()
        {
            if(ModelState.IsValid)
            {
                var bookFromDb = await _dbContext.Books.FindAsync(Book.Id);
                bookFromDb.Name = Book.Name;
                bookFromDb.ISBN = Book.ISBN;
                bookFromDb.Author = Book.Author;

                await _dbContext.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
