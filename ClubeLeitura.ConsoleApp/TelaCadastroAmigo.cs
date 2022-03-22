using System;

namespace ClubeLeitura.ConsoleApp
{
    internal class TelaCadastroAmigo
    {

        public Amigo[] amigos;
        public Notificador notificador;
        public int indiceAmigos;

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo novo amigo");

            Amigo amigo = ObterAmigo();

            indiceAmigos++;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;

            notificador.ApresentarMensagem("Amigo cadastrado com sucesso!", "Sucesso");
        }

        private Amigo ObterAmigo()
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsavel do amigo: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o email do amigo: ");
            string email = Console.ReadLine();

            Console.Write("Digite o endereço do amigo: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo();

            amigo.nomeAmigo = nome;
            amigo.nomeResponsavel = nomeResponsavel;
            amigo.telefone = telefone;
            amigo.email = email;
            amigo.endereco = endereco;

            return amigo;
        }

        public void VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                Amigo a = amigos[i];

                Console.WriteLine("Nome: " + a.nomeAmigo);
                Console.WriteLine("Nome do responsável: " + a.nomeResponsavel);
                Console.WriteLine("Telefone: " + a.telefone);
                Console.WriteLine("Email: " + a.telefone);
                Console.WriteLine("Endereço: " + a.endereco);

                Console.WriteLine();
            }
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");

            VisualizarAmigos("Pesquisando");

            Console.Write("Digite o nome do amigo que deseja editar: ");
            string nome = Console.ReadLine();

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].nomeAmigo == nome)
                {
                    Amigo amigo = ObterAmigo();

                    amigos[i].nomeAmigo = nome;
                    amigos[i] = amigo;

                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo editado com sucesso", "Sucesso");
        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            VisualizarAmigos("Pesquisando");

            Console.Write("Digite o nome do amigo que deseja excluir: ");
            string nome = Console.ReadLine();

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].nomeAmigo == nome)
                {
                    amigos[i] = null;
                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }

    }
}
