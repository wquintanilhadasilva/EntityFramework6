using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework6
{
    [Table("pessoas")]
    public class Pessoa: EntidadeAbstrata
    {

        [Column("nome"), MaxLength(100), Required]
        public String Nome { get; set; }

        [Column("nascimento")]
        public DateTime? Nascimento { get; set; }

        [Column("sexo_masculino")]
        public Boolean? Masculino{ get; set; }

    }
}
