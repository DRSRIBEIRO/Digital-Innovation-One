using System;

namespace Dio.Comedia
{
    class Program
    {
        static ComedianRepository repository = new ComedianRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaousuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarComediante();
                        break;
                    case "2":
                        InserirComediante();
                        break;
                    case "3":
                        AtualizarComediante();
                        break;
                    case "4":
                        ExcluirComediante();
                        break;
                    case "5":
                        VisualizarComediante();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaousuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void ListarComediante()
        {

            Console.WriteLine("ListarSeries");

            var lista = repository.Lista();

            if (lista.Count == 0)
            {

                Console.WriteLine("Nenhum Comediante Cadastrado.");
                return;
            }

            foreach (var Comedian in lista)
            { 
                var excluido = Comedian.RetornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", Comedian.RetornaId(), Comedian.RetornaNomeComediante(), (excluido ? "+Excluido+" : ""));
            }
        }

        private static void InserirComediante()
        {
            Console.WriteLine("Inserir novo Comediante");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do comediante: ");
            string entradaNomeComediante = Console.ReadLine();

            Console.Write("Digite o ano da comedia: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da comedia: ");
            string entradaDescricao = Console.ReadLine();

            Comedian novoComediante = new Comedian(
                id: repository.ProximoId(),
                genero: (Genero)entradaGenero,
                nomeComediante: entradaNomeComediante,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repository.Insere(novoComediante);

        }

        private static void AtualizarComediante()
        {
            Console.WriteLine("Digite o id do Comediante: ");
            int indiceComediante = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do comediante: ");
            string entradaNomeComediante = Console.ReadLine();

            Console.Write("Digite o ano da comedia: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da comedia: ");
            string entradaDescricao = Console.ReadLine();

            Comedian atualizaComediante = new Comedian(
                id: indiceComediante,
                genero: (Genero)entradaGenero,
                nomeComediante: entradaNomeComediante,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repository.Atualiza(indiceComediante, atualizaComediante);
        }

        private static void ExcluirComediante()
        {
            Console.Write("Digite o id do Comediante a excluir: ");
            int indiceComediante = int.Parse(Console.ReadLine());

            repository.Exclui(indiceComediante);
        }

        private static void VisualizarComediante()
        {
            Console.Write("Digite o id do Comediante");
            int indiceComediante = int.Parse(Console.ReadLine());

            var comediante = repository.RetornaPorId(indiceComediante);
            Console.WriteLine(comediante);
        }

        private static string ObterOpcaousuario()
        {

            Console.WriteLine();
            Console.WriteLine("Comediantes ao seu Dispor");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Lista de Comediantes");
            Console.WriteLine("2 - Inserir novo Comediante");
            Console.WriteLine("3 - Atualizar Comediante");
            Console.WriteLine("4 - Excluir Comediante");
            Console.WriteLine("5 - Visualizar Comediante");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
