using DIO.Series.Classes;
using DIO.Series.Enums;
using System;

namespace DIO.Series
{
    internal class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            var opcaoUsuario = ObterOpcaoUsuario();

            while (!opcaoUsuario.Equals("X"))
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
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
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var listaSerie = serieRepositorio.Lista();
            if (listaSerie.Count.Equals(0))
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in listaSerie)
            {
                Console.WriteLine($"#ID {serie.RetornaId()}: {serie.RetornaTitulo()}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Insere nova série");
            foreach (var item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{(int)item} - {Enum.GetName(typeof(Genero), item)}");
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            var serie = new Serie
                (
                    serieRepositorio.ProximoId(),
                    (Genero)entradaGenero,
                    entradaTitulo,
                    entradaDescricao,
                    entradaAno
                );

            serieRepositorio.Insere(serie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (var item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{(int)item} - {Enum.GetName(typeof(Genero), item)}");
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            var serie = new Serie
                (
                    idSerie,
                    (Genero)entradaGenero,
                    entradaTitulo,
                    entradaDescricao,
                    entradaAno
                );

            serieRepositorio.Atualizar(idSerie, serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            serieRepositorio.Excluir(idSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = serieRepositorio.RetornaPorId(idSerie);
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informa a opção desejada:");


            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserie nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
