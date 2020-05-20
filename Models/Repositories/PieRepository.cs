using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PieRepository> _logger;

        public PieRepository(AppDbContext context, ILogger<PieRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Pie> AllPies 
        {
            get
            {
                return _context.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _context.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            try
            {
                return _context.Pies.SingleOrDefault(pie => pie.PieId == pieId);
            }
            catch (Exception ex)
            {

                _logger.LogError("Couldn't get Pie by it's ID:", ex);
                return null;
            }
        }
    }
}
