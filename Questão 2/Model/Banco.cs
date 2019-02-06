using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Atividade1
{
    public class Banco
    {

        

        List<Agencia> agencias = new List<Agencia>();

        public void AdicionarAgencia(Agencia a)
        {
            agencias.Add(a);
            Console.WriteLine("Agência " + a.Id + " criada com sucesso!");
            Console.WriteLine("Numero de agencias: " + agencias.Count);
        }

        [Key]
        public int Id { get; set; }


        public List<Agencia> Agencias { get; }


    }
}
