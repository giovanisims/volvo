namespace service;

using model.clientes;

public class ServicoAutenticacao
{
    public bool RealizarLogin(IAutenticavel usuario, string senhaTentativa)
    {
        return usuario.ValidarSenha(senhaTentativa);
    }
}