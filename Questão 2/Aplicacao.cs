using System;
using System.Linq;


namespace Atividade1
{
    public class Aplicacao
    {
        public const decimal Juros = 0.6M;

        

        static void Main(string[] args)
        {

            using (var dbcontext = new StoreContext())
            {

                dbcontext.Set<Banco>().RemoveRange(dbcontext.Bancos);
                Banco bb = new Banco();
                dbcontext.Bancos.Add(bb);
                dbcontext.SaveChanges();



                while (true)
                {
                    
                    MenuAgencia();
                    int op = int.Parse(Console.ReadLine());

                    if (op == 1)
                    {
                        Agencia agencia = new Agencia();
                        dbcontext.Agencias.Add(agencia);
                        dbcontext.SaveChanges();

                    }
                    else if (op == 2)
                    {
                        Cliente cliente = new Cliente();
                        Console.WriteLine("Digite o nome do cliente: ");
                        string nome_cliente = Console.ReadLine();
                        cliente.Nome = nome_cliente;
                        dbcontext.Clientes.Add(cliente);
                        dbcontext.SaveChanges();

                        Console.WriteLine("Que tipo de conta deseja criar:\n");
                        Console.WriteLine("1 - Corrente / 2 - Poupança: ");
                        int tipo_conta = int.Parse(Console.ReadLine());
                        if (tipo_conta == 1)
                        {
                            ContaCorrente cc = new ContaCorrente(cliente.Nome);
                            Console.WriteLine("Digite o Id da agência: ");
                            int numAgencia = int.Parse(Console.ReadLine());

                            Agencia agencia = Aplicacao.buscaAgencia(numAgencia);
                            if (agencia != null)
                            {
                                cc.AgenciaId = agencia.Id;
                                dbcontext.ContasCorrentes.Add(cc);
                                dbcontext.SaveChanges();
                                Console.WriteLine("Conta " + cc.Id + " de titular " + cc.Titular + " criada com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Por favor tente novamente!");
                            }

                        }
                        else if (tipo_conta == 2)
                        {
                            ContaPoupanca cp = new ContaPoupanca(Juros, DateTime.Now, cliente.Nome);
                            Console.WriteLine("Digite o Id da agência: ");
                            int numAgencia = int.Parse(Console.ReadLine());

                            Agencia agencia = Aplicacao.buscaAgencia(numAgencia);
                            if (agencia != null)
                            {
                                cp.AgenciaId = agencia.Id;
                                dbcontext.ContasPoupanca.Add(cp);
                                dbcontext.SaveChanges();
                                Console.WriteLine("Conta " + cp.Id + " de titular " + cp.Titular + " criada com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Por favor tente novamente!");
                            }

                        }
                    }
                    else if (op == 3)
                    {
                        Solicitacao solicitacao = new Solicitacao();
                        solicitacao.realizarSolicitacao(bb);
                        dbcontext.Solicitacoes.Add(solicitacao);
                        dbcontext.SaveChanges();

                    }
                    else if (op == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("OPÇÃO INVÁLIDA");
                    }


                }
            }
        }

        public static void MenuAgencia()
        {
             Console.WriteLine("|------------------------|");
             Console.WriteLine("| Cadastrar Agência -- 1 |");
             Console.WriteLine("| Criar Conta -------- 2 |");
             Console.WriteLine("| Abrir uma Sessão --- 3 |");
             Console.WriteLine("| Encerrar programa -- 0 |");
             Console.WriteLine("|------------------------|");
        }

        
        public static Agencia buscaAgencia(int num)
        {

            using (var db = new StoreContext())
            {
                try
                {
                    var agencia = db.Agencias
                    .Single(a => a.Id == num);
                    return agencia;
                }
                catch (Exception)
                {
                    Console.WriteLine("A agência digitada não existe, por favor, verifique se o ID está correto:");
                    return null;
                }
            }
        }

        public static Cliente buscaCliente(int num)
        {

            using (var db = new StoreContext())
            {
                try
                {
                    var cliente = db.Clientes
                    .Single(c => c.Id == num);
                    return cliente;
                }
                catch (Exception)
                {
                    Console.WriteLine("O cliente não está cadastrado, por favor, verifique se o ID está correto:");
                    return null;
                }
            }
        }

        public static ContaCorrente buscaContaCorrente(int num)
        {

            using (var db = new StoreContext())
            {
                try
                {
                    var cc = db.ContasCorrentes
                    .Single(c => c.Id == num);
                    return cc;
                }
                catch (Exception)
                {
                    Console.WriteLine("A conta não está cadastrada, por favor, verifique se o ID está correto:");
                    return null;
                }
            }
        }

        public static ContaPoupanca buscaContaPoupanca(int num)
        {

            using (var db = new StoreContext())
            {
                try
                {
                    var cp = db.ContasPoupanca
                    .Single(p => p.Id == num);
                    return cp;
                }
                catch (Exception)
                {
                    Console.WriteLine("A conta não está cadastrada, por favor, verifique se o ID está correto:");
                    return null;
                }
            }
        }

        



    }
}