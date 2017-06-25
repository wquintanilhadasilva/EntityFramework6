using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace EntityFramework6
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("bancoEstudos") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<HistoricoUsuario> Historicos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
