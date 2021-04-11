using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleBlogPage.Context;
using SampleBlogPage.Models;

namespace SampleBlogPage.Pages.Blog
{
    public class DeleteModel : PageModel
    {
        private readonly SampleBlogPage.Context.DataContext _context;

        public DeleteModel(SampleBlogPage.Context.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlogPage BlogPage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogPage = await _context.Blogs.FirstOrDefaultAsync(m => m.ID == id);

            if (BlogPage == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogPage = await _context.Blogs.FindAsync(id);

            if (BlogPage != null)
            {
                _context.Blogs.Remove(BlogPage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
