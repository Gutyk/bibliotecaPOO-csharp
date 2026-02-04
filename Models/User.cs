using Biblioteca.Models;

namespace Biblioteca.Models;

public abstract class User
{
    public string Nome { get; set; }
    public int UserId { get; set; }

    public List<Livro> LivrosEmprestados { get; private set; }

    protected abstract int LimiteLivros { get; }

    protected User()
    {
        LivrosEmprestados = new List<Livro>();
    }

    public void EmprestarLivro(Livro livro)
    {
        if (LivrosEmprestados.Count >= LimiteLivros)
            throw new InvalidOperationException("Limite atingido.");

        if (!livro.Disponivel)
            throw new InvalidOperationException("Livro indisponível.");

        LivrosEmprestados.Add(livro);
        livro.Emprestar();
    }

    public void DevolverLivro(Livro livro)
    {
        if (!LivrosEmprestados.Remove(livro))
            throw new InvalidOperationException("Livro não pertence ao usuário.");

        livro.Devolver();
    }
}
