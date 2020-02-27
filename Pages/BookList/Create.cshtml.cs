using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookListRazor.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class CreateModel : PageModel
    {
        private readonly BookDbContext _appContent;

        public CreateModel (BookDbContext appContext)
        {
            _appContent = appContext ??
                throw new ArgumentNullException (nameof (appContext));
        }

        public Book Book { get; set; }
        public void OnGet () {}
    }
}
