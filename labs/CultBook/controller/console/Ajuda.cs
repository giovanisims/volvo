namespace model;

using System.IO;

public class Ajuda
{
    private string _texto;

    public Ajuda(string arquivo)
    {
        string path = Path.Combine("config", arquivo);
        if (File.Exists(path))
        {
            _texto = File.ReadAllText(path);
        }
        else
        {
            _texto = "Arquivo de ajuda não encontrado.";
        }
    }

    public string GetTexto()
    {
        return _texto;
    }
}