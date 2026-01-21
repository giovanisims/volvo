using System; // This is used for Console and Datetime
using CultBook.model;
using CultBook.view.console;

namespace CultBook.controller.console;

public class CultBook
{
    private FabricaDeLivros fabrica;
    private Pedido pedidoAtual;
    private Menu menu;

    bool loggedIn = false;

    public CultBook()
    {
        menu = new Menu();

        fabrica = new FabricaDeLivros();
    }

    static void Main(string[] args)
    {
        CultBook app = new CultBook();
        bool running = true;

        while (running)
        {

            string choice = app.menu.MostrarMenu();
            Console.Clear(); // Clearing the old menu is good practice

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Login em construção.");
                    app.loggedIn = true;
                    Console.WriteLine("Login realizado com sucesso!");
                    break;
                case "2":
                    Console.WriteLine("Cadastro em construção.");
                    break;
                case "3":
                    app.BuscarLivros();
                    break;
                case "4":
                    app.InserirLivro();
                    break;
                case "5":
                    Console.WriteLine("Função de remover livros em construção.");
                    break;
                case "6":
                    app.VerCarrinho();
                    break;
                case "7":
                    if (app.loggedIn)
                    {
                        Console.WriteLine("Compra realizada com sucesso!");
                        app.pedidoAtual = null;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, faça login primeiro.");
                    }
                    break;
                case "8":
                    Console.WriteLine("Até logo!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPressione Enter para voltar ao menu...");
                Console.ReadLine();
            }
        }
    }

    public void BuscarLivros()
    {
        Livro[] livros = fabrica.BuscarTodos();

        Console.WriteLine("=== LIVROS DISPONÍVEIS ===");
        foreach (Livro l in livros)
        {
            if (l != null){
                l.Imprimir();
            }
        }
    }

public void InserirLivro()
    {
        // 1. Get Input
        Console.Write("Digite o ISBN do livro que deseja comprar: ");
        string isbn = Console.ReadLine();

        // foreach loop was moved to FabricaDeLivro
        Livro selectedBook = fabrica.BuscarLivro(isbn);

        if (selectedBook == null)
        {
            Console.WriteLine("Livro não encontrado");
            return;
        }

        Console.Write($"Livro '{selectedBook.Titulo}' encontrado! Digite a quantidade: ");
        if (!int.TryParse(Console.ReadLine(), out int amnt) || amnt <= 0)
        {
             Console.WriteLine("Quantidade Inválida");
             return;
        }

        if (amnt > selectedBook.Estoque)
        {
            Console.WriteLine("Estoque insuficiente.");
            return;
        }

        if (this.pedidoAtual == null)
        {
            Console.WriteLine("Criando novo pedido...");
            this.pedidoAtual = new Pedido(1, DateTime.Now, "Pix", 0.0, "Aberto");
        }

        ItemDePedido item = new ItemDePedido(selectedBook, amnt);
        this.pedidoAtual.InserirItem(item);

        Console.WriteLine("Item adicionado ao seu pedido com sucesso!");
    }

    public void VerCarrinho()
    {
        Console.WriteLine("=== SEU CARRINHO ===");
        if (this.pedidoAtual == null)
        {
            Console.WriteLine("Seu carrinho está vazio");
        }
        else
        {
            this.pedidoAtual.Imprimir();
        }
    }
}