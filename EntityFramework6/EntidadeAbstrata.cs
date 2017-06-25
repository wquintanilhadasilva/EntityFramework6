using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework6
{
    public abstract class EntidadeAbstrata
    {
        [Key, Column("id")]
        public int Id { get; set; }
    }
}
