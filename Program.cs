using System;
using DIO_GAMES.Classes;
using DIO_GAMES.Enums;

namespace DIO_GAMES
{
    class Program
    {
        static GamesRepositorio repositorio = new GamesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = PegarOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarGames();
                        break;
                    case "2":
                        InserirGame();
                        break;
                    case "3":
                        AtualizarGame();
                        break;
                    case "4":
                        ExcluirGame();
                        break;
                    case "5":
                        VisualizarGame();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = PegarOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarGames()
        {
            Console.WriteLine("Listar games");
            if (repositorio.Lista().Count != 0)
            {
                foreach (var game in repositorio.Lista())
                {
                    Console.WriteLine($"Id {game.Id}: - {game.retornaTitulo()} {(game.retornaExcluido() ? "--EXCLUÍDO--" : "")} ");
                }
                return;
            }
            Console.WriteLine("Nenhum game foi cadastrado ainda!");
        }

        private static void InserirGame()
        {
            Console.WriteLine("Adicionar novo game");
            Games novoGame = CriaNovoGame();
            if (novoGame == null)
            {
                return;
            }
            repositorio.Insere(novoGame);
            Console.WriteLine();
            Console.WriteLine("Jogo adicionado com sucesso!!!");
        }

        private static void AtualizarGame()
        {
            Console.Write("Digite o Id do game: ");
            int indiceGame;

            if (!int.TryParse(Console.ReadLine(), out indiceGame))
            {
                Console.WriteLine("Id inválido");
            }
            else if (!repositorio.VerificaValidezId(indiceGame))
            {
                Console.WriteLine($"Não existe um jogo com o id {indiceGame}");
            }
            else if (repositorio.Lista()[indiceGame].retornaExcluido())
            {
                Console.WriteLine("Esse jogo foi excluído, portanto não receberá mais atualizações");
            }
            else
            {
                Games gameAtualizado = CriaNovoGame();
                if (gameAtualizado == null)
                {
                    return;
                }
                repositorio.Atualiza(indiceGame, gameAtualizado);
                Console.WriteLine();
                Console.WriteLine("Jogo atualizado com sucesso!!!");
            }
        }

        private static void ExcluirGame()
        {
            Console.Write("Digite o id do Game: ");
            int indiceGame;

            if (!int.TryParse(Console.ReadLine(), out indiceGame))
            {
                Console.WriteLine("Id inválido");
            }
            else if (!repositorio.VerificaValidezId(indiceGame))
            {
                Console.WriteLine($"Não existe um jogo com o id {indiceGame}");
            }
            else if (repositorio.Lista()[indiceGame].retornaExcluido())
            {
                Console.WriteLine("Esse jogo já foi excluído");
            }
            else
            {
                Console.WriteLine($"Tem certeza que quer excluir o jogo com id {indiceGame}?");
                Console.WriteLine("Se sim, digite 'S', caso contrário digite qualquer outra coisa");
                string confirmacao = Console.ReadLine();
                if (confirmacao.ToUpper() == "S")
                {
                    repositorio.Exclui(indiceGame);
                    Console.WriteLine();
                    Console.WriteLine("Jogo excluído com sucesso !!!");
                    return;
                }
                Console.WriteLine("Exclusão cancelada");
            }
        }

        private static void VisualizarGame()
        {
            Console.Write("Digite o id do Game: ");
            int indiceGame;

            if (!int.TryParse(Console.ReadLine(), out indiceGame))
            {
                Console.WriteLine("Id inválido");
                return;
            }
            if (!repositorio.VerificaValidezId(indiceGame))
            {
                Console.WriteLine($"Não existe um jogo com o id {indiceGame}");
                return;
            }
            Console.WriteLine(repositorio.RetornaPorId(indiceGame));
        }

        private static string PegarOpcaoUsuario()
        {
            Console.WriteLine($"{Environment.NewLine}CRUD de games - DIO Games");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar games");
            Console.WriteLine("2- Inserir novo game");
            Console.WriteLine("3- Atualizar game");
            Console.WriteLine("4- Excluir game");
            Console.WriteLine("5- Visualizar game");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine($"X- Sair{Environment.NewLine}");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void listaGeneros()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
        }

        private static Games CriaNovoGame()
        {
            listaGeneros();
            Console.Write("Digite o número do genêro do novo jogo a ser cadastrado:");
            int entradaGenero;
            if (!int.TryParse(Console.ReadLine(), out entradaGenero))
            {
                Console.WriteLine("Gênero Inválido - Não foi passado um número inteiro");
                return null;
            }
            if (entradaGenero > Enum.GetNames(typeof(Genero)).Length)
            {
                Console.WriteLine("Gênero Inválido - Gênero não existe");
                return null;
            }
            Console.Write("Digite o título do game: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o ano de lançamento do game: ");
            int entradaAno;
            if (!int.TryParse(Console.ReadLine(), out entradaAno))
            {
                Console.WriteLine("Ano inválido");
                return null;
            }
            Console.Write("Digite a descrição do game: ");
            string entradaDescricao = Console.ReadLine();
            Console.Write("Digite a desenvolvedora do game: ");
            string entradaDev = Console.ReadLine();

            Games novoGame = new Games(repositorio.ProximoId(), (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno, entradaDev);
            return novoGame;
        }
    }

}