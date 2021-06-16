using GestaoHYS.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace GestaoHIS.Infrastructure.Repository
{
    public class GestaoHISContext : DbContext
    {
        public GestaoHISContext(DbContextOptions<GestaoHISContext> options) : base(options) { }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<ParceiroPais> ParceiroPaises { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<SalesInvoice> SalesInvoice { get; set; }
        public DbSet<SalesItem> SalesItem { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
    }
}
