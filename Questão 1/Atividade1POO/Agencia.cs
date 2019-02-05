using System;
using System.Collections.Generic;
using System.Text;

public class Agencia
{
    public int idAgencia { get; set; }

    List<ContaCorrente> contasCorrente = new List<ContaCorrente>();
    List<ContaPoupanca> contasPoupanca = new List<ContaPoupanca>();
    List<Solicitacoes> solicitacoes = new List<Solicitacoes>();

    public void AdicionarContaCorrente(ContaCorrente cc)
    {
        contasCorrente.Add(cc);
        Console.WriteLine("Conta " + cc.Id + " de titular " + cc.Titular + " criada com sucesso!");
    }

    public void AdicionarContaPoupanca(ContaPoupanca cp)
    {
        contasPoupanca.Add(cp);
        Console.WriteLine("Conta " + cp.Id + " de titular " + cp.Titular + " criada com sucesso!");
    }

    public ContaCorrente getCCorrente(int num)
    {
        ContaCorrente cc = null;
        foreach (var conta in contasCorrente)
        {
            if (conta.Id == num)
            {
                cc = conta;
                return cc;
            }
        }

        Console.WriteLine("A conta não está cadastrada! Verifique seu número!");
        return null;



    }
    public ContaPoupanca getCPoupanca(int num)
    {
        ContaPoupanca cp = null;
        foreach (var conta in contasPoupanca)
        {
            if (conta.Id == num)
            {
                cp = conta;
                return cp;
            }
        }
        Console.WriteLine("A conta não está cadastrada! Verifique seu número!");
        return null;

    }
}
