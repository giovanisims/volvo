namespace controller.console;

using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Configurador
{
    public string Regiao { get; set; }
    public string Idioma { get; set; }
    public string ArquivoAjuda { get; set; }

    public Configurador()
    {
        try 
        {
            string path = "config/config.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var config = JsonSerializer.Deserialize<Configurador>(json, options);
                
                if (config != null)
                {
                    Regiao = config.Regiao;
                    Idioma = config.Idioma;
                    ArquivoAjuda = config.ArquivoAjuda;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar configurações: {ex.Message}");
        }
    }

    [JsonConstructor]
    public Configurador(string regiao, string idioma, string arquivoAjuda)
    {
        Regiao = regiao;
        Idioma = idioma;
        ArquivoAjuda = arquivoAjuda;
    }

    public override string ToString()
    {
        return $"Região: {Regiao}, Idioma: {Idioma}, Arquivo de Ajuda: {ArquivoAjuda}";
    }
}