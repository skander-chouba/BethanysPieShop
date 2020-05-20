using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(AppDbContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return _context.Categories;
            }
        }
    }
}
