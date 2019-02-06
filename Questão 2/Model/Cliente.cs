using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Atividade1
{
    public class Cliente
    {
        
        public string Nome { get; set; }

        [Key]
        public int Id { get; set; }
    }

    
}
