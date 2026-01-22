namespace model;

public interface IAutenticavel
{
    string Login { get; set; }
    bool ValidarSenha(string senha);
}