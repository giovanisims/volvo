namespace model;

using System.IO;

public class Ajuda
{
    private string _texto;

    public Ajuda(string arquivo)
    {
        string path = Path.Combine("config", arquivo);
        try
        {
            _texto = File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            _texto = "Arquivo de ajuda não encontrado";
        }
        catch (Exception ex)
        {
             _texto = $"Erro ao carregar ajuda";
        }
    }

    public string GetTexto()
    {
        return _texto;
    }
}