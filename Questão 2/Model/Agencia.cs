using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Atividade1
{
    public class Agencia
    {

        [Key]
        public int Id { get; set; }

        public List<ContaCorrente> ContaCorrentes { get; set; }
        public List<ContaPoupanca> ContaPoupancas { get; set; }
        public List<Solicitacao> Solicitacoes { get; set; }





    }
}
