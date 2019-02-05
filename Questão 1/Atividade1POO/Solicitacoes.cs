using System;
using System.Collections.Generic;
using System.Text;
public class Solicitacoes
{
    public void realizarSolicitacao(Banco banco)
    {
        Console.WriteLine("Digite o Id da agência: ");
        int numAgencia = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o tipo da conta: 1 - Corrente/ 2 - Poupança");
        int tipoConta = int.Parse(Console.ReadLine());

        if (tipoConta == 1)
        {
            Console.WriteLine("Digite o numero da conta: ");
            int numConta = int.Parse(Console.ReadLine());

            Agencia agencia = banco.buscaAgencia(numAgencia);

            if (agencia == null)
            {
                return;
            }
            ContaCorrente cc = agencia.getCCorrente(numConta);
            if (cc == null)
            {
                return;
            }

            Console.WriteLine("O que deseja realizar: ");
            Console.WriteLine("1 - Consultar Saldo /n 2 - Sacar /n 3 -  Depositar");

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
                Console.WriteLine("SAQUE");
                Console.WriteLine("Digite o valor para saque: ");
                decimal saque = decimal.Parse(Console.ReadLine());

                if (cc.Saldo < saque)
                {
                    Console.WriteLine("Você não possui Saldo suficiente!");
                }
                else
                {
                    cc.Sacar(saque);
                }

            }
            else if (operacao == 3)
            {
                Console.WriteLine("DEPÓSITO");
                Console.WriteLine("Digite o valor para depositar: ");
                cc.Depositar(decimal.Parse(Console.ReadLine()));
            }
        }
        else if (tipoConta == 2)
        {
            Console.WriteLine("Digite o numero da conta: ");
            int num_conta = int.Parse(Console.ReadLine());
            Agencia agencia = banco.buscaAgencia(numAgencia);
            if (agencia == null)
            {
                return;
            }
            ContaPoupanca cp = agencia.getCPoupanca(num_conta);
            if (cp == null)
            {
                return;
            }

            Console.WriteLine("O que deseja realizar: ");
            Console.WriteLine("1 - Consultar Saldo /n 2 - Sacar /n 3 -  Depositar");
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
                Console.WriteLine("SAQUE");
                Console.WriteLine("Digite o valor para saque: ");
                decimal saque = decimal.Parse(Console.ReadLine());

                if (cp.Saldo < saque)
                {
                    Console.WriteLine("Você não possui Saldo suficiente!");
                }
                else
                {
                    cp.Sacar(saque);
                }
            }
            else if (operacao == 3)
            {
                Console.WriteLine("DEPÓSITO");
                Console.WriteLine("Digite o valor para depositar: ");
                cp.Depositar(decimal.Parse(Console.ReadLine()));
            }
        }
    }
}