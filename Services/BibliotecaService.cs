using Biblioteca.Models;

namespace Biblioteca.Services;

public class BibliotecaService
{
    private readonly List<Livro> _livros = new();
    private readonly List<User> _usuarios = new();

    public IReadOnlyList<Livro> Livros => _livros;
    public IReadOnlyList<User> Usuarios => _usuarios;

    public void AdicionarLivro(Livro livro) => _livros.Add(livro);
    public void AdicionarUsuario(User usuario) => _usuarios.Add(usuario);

    public Livro BuscarLivroPorId(int id)
        => _livros.FirstOrDefault(l => l.Id == id)
           ?? throw new Exception("Livro não encontrado.");

    public User BuscarUsuarioPorId(int id)
        => _usuarios.FirstOrDefault(u => u.UserId == id)
           ?? throw new Exception("Usuário não encontrado.");

    public void EmprestarLivro(int userId, int livroId)
    {
        var usuario = BuscarUsuarioPorId(userId);
        var livro = BuscarLivroPorId(livroId);

        usuario.EmprestarLivro(livro);
    }

    public void DevolverLivro(int userId, int livroId)
    {
        var usuario = BuscarUsuarioPorId(userId);
        var livro = BuscarLivroPorId(livroId);

        usuario.DevolverLivro(livro);
    }
}
