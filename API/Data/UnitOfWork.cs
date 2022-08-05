using System.Threading.Tasks;
using API.Interfaces;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        
        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
