    using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Atividade1
{
    public class Solicitacao
    {
        
        public void realizarSolicitacao(Banco banco)
        {
            Console.WriteLine("Digite o Id da agência: ");
            int numAgencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o tipo da conta: 1 - Corrente/ 2 - Poupança");
            int tipo_conta = int.Parse(Console.ReadLine());

            if (tipo_conta == 1)
            {

                Agencia agencia = Aplicacao.buscaAgencia(numAgencia);
                if (agencia == null)
                {
                    return;
                }

                Console.WriteLine("Digite o numero da conta: ");
                int num_conta = int.Parse(Console.ReadLine());

                ContaCorrente cc = Aplicacao.buscaContaCorrente(num_conta);
                if (cc == null)
                {
                    return;
                }

                Console.WriteLine("O que deseja realizar: ");
                Console.WriteLine("1 - Consultar Saldo / 2 - Sacar / 3 -  Depositar");
                int operacao = int.Parse(Console.ReadLine());

                if (operacao == 1)
                {
                    Console.WriteLine("********************");
                    Console.WriteLine("Conta = " + cc.Id);
                    Console.WriteLine("Titular = " + cc.Titular);
                    Console.WriteLine("Seu saldo é = R$ " + cc.Saldo);
                    Console.WriteLine("********************");
                }
                else if (operacao == 2)
                {
                    //Console.WriteLine("SAQUE");
                    //Console.WriteLine("Digite o valor para saque: ");
                    //cc.Sacar(decimal.Parse(Console.ReadLine()));
                    using (var db = new StoreContext())
                    {
                        Console.WriteLine("SAQUE");
                        Console.WriteLine("Digite o valor para saque: ");
                        var founded = db.Set<ContaCorrente>().First(c => c.Id == cc.Id);
                        founded.Sacar(decimal.Parse(Console.ReadLine()));
                        db.SaveChanges();
                    }
                }
                else if (operacao == 3)
                {
                    //Console.WriteLine("DEPÓSITO");
                    //Console.WriteLine("Digite o valor para depositar: ");
                    //cc.Depositar(decimal.Parse(Console.ReadLine()));
                    using (var db = new StoreContext())
                    {
                        Console.WriteLine("DEPÓSITO");
                        Console.WriteLine("Digite o valor para depositar: ");
                        var founded = db.Set<ContaCorrente>().First(c => c.Id == cc.Id);
                        founded.Depositar(decimal.Parse(Console.ReadLine()));
                        db.SaveChanges();
                    }

                }
            }
            else if (tipo_conta == 2)
            {
                Console.WriteLine("Digite o numero da conta: ");
                int num_conta = int.Parse(Console.ReadLine());
                Agencia agencia = Aplicacao.buscaAgencia(numAgencia);
                if (agencia == null)
                {
                    return;
                }
                ContaPoupanca cp = Aplicacao.buscaContaPoupanca(num_conta);
                if (cp == null)
                {
                    return;
                }

                Console.WriteLine("O que deseja realizar: ");
                Console.WriteLine("1 - Consultar Saldo / 2 - Sacar / 3 -  Depositar");
                int operacao = int.Parse(Console.ReadLine());

                if (operacao == 1)
                {
                    Console.WriteLine("********************");
                    Console.WriteLine("Conta = " + cp.Id);
                    Console.WriteLine("Titular = " + cp.Titular);
                    Console.WriteLine("Seu saldo é = R$ " + cp.Saldo);
                    Console.WriteLine("********************");
                }
                else if (operacao == 2)
                {
                    //Console.WriteLine("SAQUE");
                    //Console.WriteLine("Digite o valor para saque: ");
                    //cp.Sacar(decimal.Parse(Console.ReadLine()));

                    using (var db = new StoreContext())
                    {
                        Console.WriteLine("SAQUE");
                        Console.WriteLine("Digite o valor para saque: ");
                        var founded = db.Set<ContaPoupanca>().First(p => p.Id == cp.Id);
                        founded.Sacar(decimal.Parse(Console.ReadLine()));
                        db.SaveChanges();
                    }
                }
                else if (operacao == 3)
                {
                    //Console.WriteLine("DEPÓSITO");
                    //Console.WriteLine("Digite o valor para depositar: ");
                    //cp.Depositar(decimal.Parse(Console.ReadLine()));

                    using (var db = new StoreContext())
                    {
                        Console.WriteLine("DEPÓSITO");
                        Console.WriteLine("Digite o valor para depositar: ");
                        var founded = db.Set<ContaPoupanca>().First(p => p.Id == cp.Id);
                        founded.Depositar(decimal.Parse(Console.ReadLine()));
                        db.SaveChanges();
                    }




                }
            }
        }


        [Key]
        public int Id { get; set; }

    }
}
