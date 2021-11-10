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
                        AtualizarSerie();
                    break;
                    case "4":
                        ExcluirSerie();
                    break;
                    case "5":
                        VisualizarSerie();
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
                Console.WriteLine();
                Console.WriteLine("Fim da Execução, aperte Enter para sair");
                Console.ReadLine();
        }

            private static string ObterOpcaoUsuario(){
                    Console.WriteLine(" ");
                    Console.WriteLine("Cadastro de Séries TutsFlix");
                    Console.WriteLine(" ");
                    Console.WriteLine("Definir ação: ");
                    Console.WriteLine(" ");
                    Console.WriteLine("1 - Inserir Série a Catálogo  ");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("2 - Listar Séries ");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("3 - Atualizar informações da Série");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("4 - Excluir Série do Catálogo ");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("5 - Visualizar Série");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("C - para Limpar a Tela");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("X - Sair");
                    Console.WriteLine();
                    Console.WriteLine("-//-//-//-//-//-//-//-//-//-//-//-//-//-//-//-//-//-//-//-//-//-//-//-//-");
                    Console.WriteLine();

                    string opcaoUsuario = Console.ReadLine().ToUpper();
                    Console.WriteLine();
            return opcaoUsuario;
        }
            private static void ListarSeries(){
                    Console.WriteLine("Lista de Série");
                    Console.WriteLine(" ");
                    var lista = repositorio.Lista();
                    if (lista.Count == 0)
                    {
                        Console.WriteLine("Nenhuma série está cadastrada, por favor insira alguma série antes de listar");
                        return;
                    }
                    foreach(var serie in lista)
                    {
                        var excluido = serie.retornaExcluido();
                        Console.WriteLine("#ID {0}: - {1}  {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "****Excluido****" : " Acessível ");
                        Console.WriteLine();
                    }
                    Console.ReadLine();
            }
            private static void InserirSerie(){
                    Console.WriteLine("Inserir nova série");
                    Console.WriteLine(" ");
                    /*var inserido = repositorio.Lista();
                    if (inserido.Count == 0)
                    {
                        Console.WriteLine("por favor insira alguma série antes de prosseguir");
                        return;
                    }*/
                    foreach(int i in Enum.GetValues(typeof(Genero)))
                    {
                        Console.WriteLine(" {0} - {1}", i, Enum.GetName(typeof(Genero),i));
                    }
                        Console.WriteLine(" ");
                        Console.Write("Digite o gênero da Série: "); 
                        int entradaGenero = int.Parse(Console.ReadLine());
                        Console.WriteLine(" ");

                        Console.Write("Digite o Título da Série: ");
                        string entradaTitulo = Console.ReadLine();
                        Console.WriteLine(" ");

                        Console.Write("Digite o Ano em que a Série iniciou: ");
                        int entradaAno = int.Parse(Console.ReadLine());
                        Console.WriteLine(" ");

                        Console.Write("Digite a Descrição da Série: ");
                        string entradaDescricao = Console.ReadLine();
                        Console.WriteLine(" ");

                Serie novaSerie = new Serie(id: repositorio.proximoID(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
                    repositorio.Insere(novaSerie);
                    Console.ReadLine();
                    
            }
        
            private static void AtualizarSerie(){
                    Console.WriteLine();
                    Console.Write("Informe o id da Série: ");
                    int indiceSerie = int.Parse(Console.ReadLine());

                    foreach (int i in Enum.GetValues(typeof(Genero))){
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
                    Console.WriteLine(" ");
                    Console.Write("Digite o Gênero de acordo com as opções: ");
                    int entradaGenero = int.Parse(Console.ReadLine());
                    Console.WriteLine(" ");

                    Console.Write("Digite o Título: ");
                    string entradaTitulo = Console.ReadLine();
                    Console.WriteLine(" ");

                    Console.Write("Digite o Ano em que a Série iniciou : ");
                    int entradaAno = int.Parse(Console.ReadLine());
                    Console.WriteLine(" ");

                    Console.Write("Digite a Descrição da Série: ");
                    string entradaDescricao = Console.ReadLine();
                    Console.WriteLine(" ");

                Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
                    repositorio.Atualiza(indiceSerie,atualizaSerie);
                    Console.Write("Informações da série atualizada: " + atualizaSerie);
                    Console.WriteLine(" ");
                    Console.ReadLine();
        }
            private static void ExcluirSerie(){
                    Console.Write("Digite o id da série: " );
                    int indiceSerie = int.Parse(Console.ReadLine());

                    repositorio.Excluir(indiceSerie);
            }

            private static void VisualizarSerie(){
                    Console.Write("Digite o id da série: ");
                    int indiceSerie = int.Parse(Console.ReadLine());

                    var serie = repositorio.RetornaPorID(indiceSerie);

                    Console.WriteLine(serie);
            }
    }
}
