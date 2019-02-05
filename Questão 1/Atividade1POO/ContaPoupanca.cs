using System;
using System.Collections.Generic;
using System.Text;

public class ContaPoupanca : Conta
{
    private decimal taxaJuros;
    private DateTime dataAniversario;

    public ContaPoupanca(decimal j, DateTime d, string t) : base(t)
    {
        taxaJuros = j;
        dataAniversario = d;
    }

    public decimal Juros { get; set; }
    public DateTime DataAniversario { get; set; }

    public void AdicionarRendimento()
    {
        if (DateTime.Now.Equals(dataAniversario))
        {
            decimal rendimento;
            rendimento = Saldo * taxaJuros;
            Depositar(rendimento);
        }
    }
    public override int Id
    {
        get; set;
    }
}