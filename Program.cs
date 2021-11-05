using System;


namespace Cadastro_de_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
      
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() !="X"){

                switch(opcaoUsuario)
                {
                    case "1":
                        InserirSerie();
                    break;

                    case "2":
                        ListarSeries();      
                    break;
                    case "3":
                     //   AtualizarSerie();
                    break;
                    case "4":
                      //  ExcluirSerie();
                    break;
                    case "5":
                   //     VisualizarSerie();
                    break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

                Console.WriteLine("Obrigado!");
                Console.ReadLine();
        }

            private static void ListarSeries(){
                    Console.WriteLine("Litar Séries");
                    var lista = repositorio.Lista();
                    if (lista.Count == 0)
                    {
                        Console.WriteLine("Nenhuma série cadastrada");
                        return;
                    }
                    foreach(var serie in lista)
                    {
                        Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                    }
            }
            private static void InserirSerie(){
                    Console.WriteLine("Inserir nova série");
                   foreach(int i in Enum.GetValues(typeof(Genero)))
                    {
                            Console.WriteLine(" {0} - {1}", i, Enum.GetName(typeof(Genero),i));
                    }
                        Console.Write("Digite o gênero da Série: "); 
                        int entradaGenero = int.Parse(Console.ReadLine());
                        Console.Write("digite o Título da Série: ");
                        string entradaTitulo = Console.ReadLine();
                        Console.Write("digite o Ano em que a Série iniciou : ");
                        int entradaAno = int.Parse(Console.ReadLine());
                        Console.Write("Digite a Descrição da Série: ");
                        string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(id: repositorio.proximoID(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
                    repositorio.Insere(novaSerie);
                    Console.Write(novaSerie);
            }
            private static string ObterOpcaoUsuario(){
                    Console.WriteLine();
                    Console.WriteLine("bem vindo ao TutsFlix");
                    Console.WriteLine("O que deseja fazer?");

                    Console.WriteLine("1 - Inserir Série a Catálogo  ");
                    Console.WriteLine("2 - Listar Séries ");
                    Console.WriteLine("3 - Atualizar Série");
                    Console.WriteLine("4 - Excluir Série do Catálogo ");
                    Console.WriteLine("5 - Visualizar Série");
                    Console.WriteLine("C - para Limpar a Tela");
                    Console.WriteLine("X - Sair");
                    Console.WriteLine();

                    string opcaoUsuario = Console.ReadLine().ToUpper();
                    Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
