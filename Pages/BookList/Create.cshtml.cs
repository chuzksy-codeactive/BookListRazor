using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookListRazor.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly BookDbContext _dbContext;

        public CreateModel (BookDbContext appContext)
        {
            _dbContext = appContext ??
                throw new ArgumentNullException (nameof (appContext));
        }

        [BindProperty]
        public Book Book { get; set; }
        public void OnGet () {}

        public async Task<IActionResult> OnPost ()
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Books.AddAsync (Book);
                await _dbContext.SaveChangesAsync ();
                return Redirect ("Index");
            }
            else
            {
                return Page ();
            }
        }
    }
}
