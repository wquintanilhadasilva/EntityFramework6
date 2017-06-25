using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework6
{
    [Table("usuarios")]
    public class Usuario : EntidadeAbstrata
    {

        public Usuario()
        {
            this.Perfis = new List<Perfil>();
            this.Historico = new List<HistoricoUsuario>();
        }

        [MaxLength(20), Required]
        public String Login { get; set; }

        [MaxLength(15), Required]
        public String Senha { get; set; }

        public int? PessoaID { get; set; }
        [ForeignKey("PessoaID")]
        public virtual Pessoa Pessoa { get; set; }

        public virtual IList<Perfil> Perfis { get; set; }

        public virtual IList<HistoricoUsuario> Historico { get; set; }
    }
}
