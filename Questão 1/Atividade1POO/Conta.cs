using System;
using System.Collections.Generic;
using System.Text;

public abstract class Conta
{

    private string titular = string.Empty;

    private decimal saldo;

    public Conta(string t)
    {
        this.titular = t;
    }

    public string Titular
    {
        get { return titular; }
        set { titular = value; }
    }
    public decimal Saldo { get; set; }

    public abstract int Id
    {
        get; set;
    }

    public virtual void Depositar(decimal valor)
    {
        Saldo += valor;
    }

    public virtual void Sacar(decimal valor)
    {
        if (valor <= Saldo)
        {
            Saldo -= valor;
        }
    }
}