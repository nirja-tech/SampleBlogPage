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
    public class DetailsModel : PageModel
    {
        private readonly SampleBlogPage.Context.DataContext _context;

        public DetailsModel(SampleBlogPage.Context.DataContext context)
        {
            _context = context;
        }

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
    }
}
