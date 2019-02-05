using System;

namespace Atividade1POO
{
    class Program
    {
        public const decimal Juros = 0.6M;

        static void Main(string[] args)
        {
            int id = 1;
            int idContaCorrente = 1;
            int idContaPoupanca = 1;
            int op;

            Banco banco = new Banco();

            while (true)
            {
                banco.listaIdAgencias();

                Console.WriteLine("---------------------------");
                Console.WriteLine("1 - Cadastrar Agência");
                Console.WriteLine("2 - Criar Conta");
                Console.WriteLine("3 - Abrir uma Sessão");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("---------------------------");

                op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    Agencia agencia = new Agencia();
                    agencia.idAgencia = id;
                    banco.AdicionarAgencia(agencia);
                    id++;

                }
                else if (op == 2)
                {
                    Cliente cliente = new Cliente();
                    Console.WriteLine("Nome do Cliente: ");
                    string nomeCliente = Console.ReadLine();
                    cliente.nome = nomeCliente;

                    Console.WriteLine("Tipo da Conta:\n");
                    Console.WriteLine("1 - Corrente / 2 - Poupança: ");

                    int tipoConta = int.Parse(Console.ReadLine());

                    if (tipoConta == 1)
                    {
                        ContaCorrente cc = new ContaCorrente(cliente.nome);
                        Console.WriteLine("Digite o Id da agência: ");
                        int numAgencia = int.Parse(Console.ReadLine());

                        Agencia agencia = banco.buscaAgencia(numAgencia);

                        if (agencia != null)
                        {
                            cc.Id = idContaCorrente;
                            agencia.AdicionarContaCorrente(cc);
                            idContaCorrente++;
                        }
                        else
                        {
                            Console.WriteLine("Por favor tente novamente!");
                        }

                    }
                    else if (tipoConta == 2)
                    {
                        ContaPoupanca cp = new ContaPoupanca(Juros, DateTime.Now, cliente.nome);
                        Console.WriteLine("Digite o Id da agência: ");
                        int numAgencia = int.Parse(Console.ReadLine());

                        Agencia agencia = banco.buscaAgencia(numAgencia);

                        if (agencia != null)
                        {
                            cp.Id = idContaPoupanca;
                            agencia.AdicionarContaPoupanca(cp);
                            idContaPoupanca++;
                        }
                        else
                        {
                            Console.WriteLine("Por favor tente novamente!");
                        }

                    }
                }
                else if (op == 3)
                {
                    Solicitacoes solicitacao = new Solicitacoes();
                    solicitacao.realizarSolicitacao(banco);

                }
                else if (op == 0)
                {
                    break;
                }
            }
        }
    }
}