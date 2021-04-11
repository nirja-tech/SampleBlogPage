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
    public class IndexModel : PageModel
    {
        private readonly SampleBlogPage.Context.DataContext _context;

        public IndexModel(SampleBlogPage.Context.DataContext context)
        {
            _context = context;
        }

        public IList<BlogPage> BlogPage { get;set; }
       
        public async Task OnGetAsync()
        {
            var query = _context.Blogs.OrderByDescending(x => x.ID).Take(5).ToList();
           
            BlogPage = await _context.Blogs.ToListAsync();
        }
    }
}
