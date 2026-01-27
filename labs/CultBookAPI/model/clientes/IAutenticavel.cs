namespace model.clientes;

public interface IAutenticavel
{
    string Login { get; set; }
    bool ValidarSenha(string senha);
}