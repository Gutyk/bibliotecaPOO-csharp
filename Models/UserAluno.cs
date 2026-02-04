namespace Biblioteca.Models;

public class UserProfessor : User
{
    protected override int LimiteLivros => 5;
}

