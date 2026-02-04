using Biblioteca.Models;

namespace Biblioteca.Interfaces;
public interface IEmprestimo
{
    void EmprestarLivro(Livro livro);
    void DevolverLivro(Livro livro);
}
