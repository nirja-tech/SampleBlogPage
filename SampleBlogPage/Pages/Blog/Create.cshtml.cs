using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleBlogPage.Context;
using SampleBlogPage.Models;

namespace SampleBlogPage.Pages.Blog
{
    public class CreateModel : PageModel
    {
        private readonly SampleBlogPage.Context.DataContext _context;

        public CreateModel(SampleBlogPage.Context.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BlogPage BlogPage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Blogs.Add(BlogPage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
