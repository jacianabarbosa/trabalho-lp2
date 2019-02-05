using System;
using System.Collections.Generic;
using System.Text;

public class Banco
{

    public int idBanco { get; set; }

    List<Agencia> agencias = new List<Agencia>();

    public void AdicionarAgencia(Agencia a)
    {
        agencias.Add(a);
        Console.WriteLine("Agência " + a.idAgencia + " criada com sucesso!");
        Console.WriteLine("Numero de agencias: " + agencias.Count);
    }

    public List<Agencia> Agencias { get; }

    public Agencia buscaAgencia(int num)
    {
        Agencia ag = null;
        foreach (var agencia in agencias)
        {
            if (agencia.idAgencia == num)
            {
                ag = agencia;
                return ag;
            }
        }
        Console.WriteLine("A agência digitada não exite, por favor, verifique se o ID está correto:");
        return null;


    }

    public void listaIdAgencias()
    {
        foreach (var agencia in agencias)
        {
            Console.WriteLine("Agencia = " + agencia.idAgencia);
        }
    }
}