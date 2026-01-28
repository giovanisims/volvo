namespace service;

using model.clientes;

public class ServicoAutenticacao
{
    public bool ValidarLogin(IAutenticavel usuario, string senhaTentativa)
    {
        return usuario.ValidarSenha(senhaTentativa);
    }
}