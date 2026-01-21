namespace CultBook.view.console;

public class Menu
{
    public string MostrarMenu()
    {
        Console.WriteLine("""

        ==============================
             Bem-vindo ao CultBook!     
        ==============================
        [1] Login
        [2] Cadastrar
        [3] Buscar Livros
        [4] Adicionar Livros ao Carrinho
        [5] Remover Livros do Carrinho
        [6] Ver Carrinho
        [7] Finalizar Compra
        [8] Sair
        ==============================
        """);

        Console.Write("Escolha uma opção: ");
        return Console.ReadLine(); // Returns the input of the user
    }
}