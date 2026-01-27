namespace service;

using model.clientes;

public class ServicoAutenticacao
{
    public void RealizarLogin(IAutenticavel usuario, string senhaTentativa)
    {
        if (usuario.ValidarSenha(senhaTentativa))
        {
            Console.WriteLine($"Bem vindo {usuario.Login}!");
        }
        else
        {
            Console.WriteLine("Login incorreto");
        }
    }
}