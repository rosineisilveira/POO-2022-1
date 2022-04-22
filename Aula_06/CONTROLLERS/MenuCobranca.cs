using System;
using Aula_06.DOMAIN;
using Aula_06.SERVICES;

namespace Aula_06.CONTROLLERS
{
    public class MenuCobranca
    {
        ClienteServices controle = new ClienteServices();
        ContaServices controleConta = new ContaServices();

        public void Menu()
        {
            string op = string.Empty;

            while( op != "0" )
            {
                Console.WriteLine("DIDITE 1 PARA ADICIONAR UM CLIENTE");
                Console.WriteLine("DIGITE 2 PARA LISTAR TODOS OS CLIENTES");
                Console.WriteLine("DIGITE 3 PARA REMOVER UM CLIENTE");
                Console.WriteLine("DIGITE 4 PARA ALTERAR DADOS DE UM CLIENTE");
                Console.WriteLine("DIGITE 5 PARA BUSCAR DADOS DE UM CLIENTE");
                Console.WriteLine("DIGITE 6 PARA ADICIONAR UMA CONTA A UM CLIENTE");
                Console.WriteLine("DIGITE 7 PARA ADICIONAR A DATA DE PAGAMENTO DE UMA CONTA");
                Console.WriteLine("DIGITE 8 PARA LISTAR AS CONTAS DE UM CLIENTE");
                Console.WriteLine("DIGITE 9 PARA REMOVER UMA CONTA");

                Console.WriteLine("DIGITE 0 PARA SAIR DA APLICAÇÃO");

                op = Console.ReadLine();
                
                switch (op)
                {
                     case "0":

                        break;

                     case "1":
                        Console.WriteLine("Digite o nome do cliente");
                        string nome = Console.ReadLine().Trim();

                        Console.WriteLine("Digite o telefone do cliente");
                        string fone = Console.ReadLine().Trim();

                        Console.WriteLine("Digite o id do cliente");
                        int id = int.Parse(Console.ReadLine());

                        string retorno = controle.CreateCliente(id,nome,fone);
                        
                        Console.WriteLine(retorno);
                        Console.WriteLine("---------------------------------------------------------------");

                        break;

                    case "2":

                        Console.WriteLine(controle.ListClientes());
                        Console.WriteLine("---------------------------------------------------------------");

                       break;
                    
                    case "3" :

                        Console.WriteLine("Digite o id do cliente");
                        int remover = int.Parse(Console.ReadLine());
                        string removido = controle.RemoveCliente (remover);
                        Console.WriteLine(removido);
                        Console.WriteLine("---------------------------------------------------------------");

                        break;

                    case "4" :

                        Console.WriteLine("Digite o id do cliente");
                        int idAt = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o nome do cliente");
                        string nomeAt = Console.ReadLine().Trim();

                        Console.WriteLine("Digite o telefone do cliente");
                        string foneAt = Console.ReadLine().Trim();

                        string atualizar = controle.AtualizarCliente(idAt,nomeAt,foneAt);

                        Console.WriteLine(atualizar);
                        Console.WriteLine("---------------------------------------------------------------");

                        break;

                    case "5" :

                        Console.WriteLine("Digite o id do cliente");
                        int idCliente = int.Parse(Console.ReadLine());
                        string busca = controle.BuscarCliente (idCliente);
                        Console.WriteLine(busca);
                        Console.WriteLine("---------------------------------------------------------------");

                        break;

                    case "6" :

                        Console.WriteLine("Digite ID do cliente");
                        int idC = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite id da conta");
                        int idConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a data da emissão");
                        DateTime dataEmissao = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a data de vencimento");
                        DateTime dataVenc = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o valor");
                        decimal valor = decimal.Parse(Console.ReadLine());

                        string cobranca = controleConta.CreateConta(idC,idConta,dataEmissao,dataVenc,valor);
                        
                        Console.WriteLine(cobranca);
                        Console.WriteLine("---------------------------------------------------------------");

                        break;

                     case "7" :

                        Console.WriteLine("Digite o id do cliente");
                        int idPagCliente = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o id da conta");
                        int idPagConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a data de pagamento");
                        DateTime dataPag = DateTime.Parse(Console.ReadLine());


                        string pagamento = controleConta.AtualizarConta (idPagCliente,idPagConta,dataPag);
                        Console.WriteLine(pagamento);
                        Console.WriteLine("---------------------------------------------------------------");

                        break;

                    case "8" :

                        Console.WriteLine("Digite o id do cliente");
                        int idContaCliente = int.Parse(Console.ReadLine());
                        string buscar = controleConta.ListContas (idContaCliente);
                        Console.WriteLine(buscar);
                        Console.WriteLine("---------------------------------------------------------------");

                        break;

                     case "9" :

                        Console.WriteLine("Digite o id do cliente");
                        int idClienteRemove = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o id dA conta");
                        int idContaRemove = int.Parse(Console.ReadLine());

                        string removerConta = controleConta.RemoveConta (idClienteRemove,idContaRemove);
                        Console.WriteLine(removerConta);
                        Console.WriteLine("---------------------------------------------------------------");

                        break;
 
                    default:
                     Console.WriteLine("invalido");
                        continue;
                }
               
            }
        }
    }
}