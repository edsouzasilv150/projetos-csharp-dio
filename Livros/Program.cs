using System;

namespace Livros
{
    class Program
    {
        static LivroRepositorio repositorio = new LivroRepositorio(); 
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarLivros();
                        break;
                    case "2":
                        InserirLivro();
                        break;
                    case "3":
                        AtualizarLivro();
                        break;
                    case "4":
                        ExcluirLivros();
                        break;
                    case "5":
                        VisualizarLivros();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                            throw new ArgumentOutOfRangeException();                        
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirLivros()
            {
                Console.Write("Digite o código do Livro:");
                int indiceLivro = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceLivro);
            }
        private static void VisualizarLivros()
        {
            Console.Write("Digite o código do Livro: ");
            int indiceLivro = int.Parse(Console.ReadLine());

            var livro = repositorio.RetornaPorId(indiceLivro);

            Console.WriteLine(livro);
        }
    
        private static void AtualizarLivro()
        {
            Console.Write("Digite o código do Livro: ");
            int indiceLivro =  int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do Livro:");  
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da edição do Livro:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição do Livro:");
            string entradaDescricao = Console.ReadLine();

            Livro atualizaLivro = new Livro(id: indiceLivro,
                                                                genero: (Genero) entradaGenero,
                                                                titulo: entradaTitulo,
                                                                ano: entradaAno,
                                                                descricao: entradaDescricao);

            repositorio.Atualiza(indiceLivro, atualizaLivro);
        }
    private static void ListarLivros() 
    {
            Console.WriteLine("Listar Livros");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Livro cadastrado");
                return;
            }

            foreach (var livro in lista)
            {
        var excluido =  livro.retornaExcluido();  

                Console.WriteLine("#ID {0}: - {1} {2}", livro.retornaId(), livro.retornaTitulo(), (excluido ? "*Excluído*" : ""));

            }
        }
private static void InserirLivro()
        {
            Console.WriteLine("Inserir novo Livro");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do Livro:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de edição Livro:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do Livro:");
            string entradaDescricao = Console.ReadLine();

            Livro novoLivro = new Livro(id: repositorio.ProximoId(),
                                        
                                                                    genero: (Genero)entradaGenero,
                                                                    titulo: entradaTitulo,
                                                                    ano: entradaAno,
                                                                    descricao: entradaDescricao);

            repositorio.Insere(novoLivro);
        }

    private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Livros a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar livro");
            Console.WriteLine("2- Inserir nova livro");
            Console.WriteLine("3- Atualizar livro");
            Console.WriteLine("4- Excluir livro");
            Console.WriteLine("5- Visualizar livro");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }        
    }
}
