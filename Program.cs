using Biblioteca.Models;
using Biblioteca.Services;

var biblioteca = new BibliotecaService();

bool executando = true;

while (executando)
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE BIBLIOTECA ===");
    Console.WriteLine("1 - Cadastrar livro");
    Console.WriteLine("2 - Cadastrar usuário");
    Console.WriteLine("3 - Emprestar livro");
    Console.WriteLine("4 - Devolver livro");
    Console.WriteLine("5 - Listar livros");
    Console.WriteLine("6 - Listar usuários");
    Console.WriteLine("0 - Sair");
    Console.Write("Opção: ");

    var opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                CadastrarLivro();
                break;

            case "2":
                CadastrarUsuario();
                break;

            case "3":
                EmprestarLivro();
                break;

            case "4":
                DevolverLivro();
                break;

            case "5":
                ListarLivros();
                break;

            case "6":
                ListarUsuarios();
                break;

            case "0":
                executando = false;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                Pausa();
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
        Pausa();
    }

    void CadastrarLivro()
    {
        Console.Write("ID do livro: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Autor: ");
        string autor = Console.ReadLine();

        var livro = new Livro(id, titulo, autor);
        biblioteca.AdicionarLivro(livro);

        Console.WriteLine("Livro cadastrado com sucesso!");
        Pausa();
    }


    void CadastrarUsuario()
    {
        Console.Write("ID do usuário: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Tipo de usuário:");
        Console.WriteLine("1 - Aluno");
        Console.WriteLine("2 - Professor");
        Console.Write("Opção: ");

        var tipo = Console.ReadLine();

        User usuario = tipo switch
        {
            "1" => new UserAluno(),
            "2" => new UserProfessor(),
            _ => throw new Exception("Tipo inválido")
        };

        usuario.UserId = id;
        usuario.Nome = nome;

        biblioteca.AdicionarUsuario(usuario);

        Console.WriteLine("Usuário cadastrado com sucesso!");
        Pausa();
    }

    void EmprestarLivro()
    {
        Console.Write("ID do usuário: ");
        int userId = int.Parse(Console.ReadLine());

        Console.Write("ID do livro: ");
        int livroId = int.Parse(Console.ReadLine());

        biblioteca.EmprestarLivro(userId, livroId);

        Console.WriteLine("Livro emprestado com sucesso!");
        Pausa();
    }

    void DevolverLivro()
    {
        Console.Write("ID do usuário: ");
        int userId = int.Parse(Console.ReadLine());

        Console.Write("ID do livro: ");
        int livroId = int.Parse(Console.ReadLine());

        biblioteca.DevolverLivro(userId, livroId);

        Console.WriteLine("Livro devolvido com sucesso!");
        Pausa();
    }

    void ListarLivros()
    {
        Console.WriteLine("=== LIVROS ===");

        foreach (var livro in biblioteca.Livros)
        {
            Console.WriteLine(
                $"ID: {livro.Id} | {livro.Titulo} - {livro.Autor} | {(livro.Disponivel ? "Disponível" : "Emprestado")}"
            );
        }

        Pausa();
    }

    void ListarUsuarios()
    {
        Console.WriteLine("=== USUÁRIOS ===");

        foreach (var user in biblioteca.Usuarios)
        {
            Console.WriteLine(
                $"ID: {user.UserId} | Nome: {user.Nome} | Livros: {user.LivrosEmprestados.Count}"
            );
        }

        Pausa();
    }

    void Pausa()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

}
