using GestaoHIS.API.Model;
using Microsoft.EntityFrameworkCore;


namespace GestaoHIS.API.Repository
{
    public class GestaoHISContext : DbContext
    {
        public GestaoHISContext(DbContextOptions<GestaoHISContext> options) : base(options) { }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<ParceiroPais> ParceiroPaises { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<GestaoHIS.API.Model.Cliente> Cliente { get; set; }
        public DbSet<GestaoHIS.API.Model.SalesInvoice> SalesInvoice { get; set; }
        public DbSet<GestaoHIS.API.Model.SalesItem> SalesItem { get; set; }
        public DbSet<GestaoHIS.API.Model.SalesOrder> SalesOrder { get; set; }
    }
}
