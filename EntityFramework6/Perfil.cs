using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework6
{
    [Table("perfis")]
    public class Perfil: EntidadeAbstrata
    {
        [Column("descricao")]
        public String Descricao { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }
    }
}
