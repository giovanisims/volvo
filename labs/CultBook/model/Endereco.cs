namespace CultBook.model;

public class Endereco
{
    public string Rua{get; set;}
    public int Numero{get; set;}
    public string Complemento{get; set;}
    public string Bairro{get; set;}
    public string Cidade{get; set;}
    public string Estado{get; set;}
    public string Cep{get; set;}

    public Endereco() { }

    public Endereco(string rua, int numero, string complemento, string bairro, string cidade, string estado, string cep)
    {
        Rua = rua;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
    }

    // public void Imprimir()
    // {
    //     Console.WriteLine($"Endereço: {Rua}, {Numero}, Comp: {Complemento} - {Bairro}, {Cidade}/{Estado} - CEP: {Cep}");
    // }
}