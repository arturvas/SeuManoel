using Microsoft.EntityFrameworkCore;

namespace SeuManoel.API.Core.Models
{
    public class SeuManoelContext : DbContext
    {
        public SeuManoelContext(DbContextOptions<SeuManoelContext> options)
            : base(options) { }
        
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
