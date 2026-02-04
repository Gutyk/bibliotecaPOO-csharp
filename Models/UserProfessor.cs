namespace Biblioteca.Models;

public class UserAluno : User
{
    protected override int LimiteLivros => 2;
}

