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
        public async Task OnGet (Guid id)
        {
            Book = await _dbContext.Books.FindAsync(id);
        }
    }
}
