using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework6
{
    [Table("historicos")]
    public class HistoricoUsuario: EntidadeAbstrata
    {
        [Column("data_acao")]
        public DateTime Data { get; set; }

        [Column("acao")]
        public String Acao { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }
}
