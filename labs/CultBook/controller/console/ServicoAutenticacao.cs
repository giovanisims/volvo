namespace controller.console;

using model;

public class ServicoAutenticacao
{
    public void RealizarLogin(IAutenticavel usuario, string senhaTentativa)
    {
        if (usuario.ValidarSenha(senhaTentativa))
        {
            Console.WriteLine($"Bem vindo {usuario}!");
        }
        else
        {
            Console.WriteLine("Login incorreto");
        }
    }
}