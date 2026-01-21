using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using CultBook.model;
using CultBook.view.console;

namespace CultBook.controller.console;

public class CultBook
{
    private Livro[] livrosDaLoja;
    private Pedido pedidoAtual;
    private Menu menu;

    bool loggedIn = false;

    public CultBook()
    {
        menu = new Menu();

        livrosDaLoja = new Livro[5];
        livrosDaLoja[0] = new Livro("111", "C# Guide", "Learn C#", "Microsoft", 10, 50.00, "img1", DateTime.Now, "Tech");
        livrosDaLoja[1] = new Livro("222", "Clean Code", "Best practices", "Uncle Bob", 5, 120.00, "img2", DateTime.Now, "Tech");
        livrosDaLoja[2] = new Livro("333", "The Witcher", "Geralt's journey", "Sapkowski", 2, 45.00, "img3", DateTime.Now, "Fantasy");
        livrosDaLoja[3] = new Livro("444", "Dune", "Sand worms", "Herbert", 8, 60.00, "img4", DateTime.Now, "SciFi");
        livrosDaLoja[4] = new Livro("555", "1984", "Big Brother", "Orwell", 10, 30.00, "img5", DateTime.Now, "Fiction");
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
                        pedidoAtual == null;
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
        foreach (Livro l in livrosDaLoja)
        {
            l.Imprimir();
        }
    }

    public void InserirLivro()
    {
        Livro selectedBook = null;
        int amnt = 0;

        // Check if book exists
        Console.Write("Digite o ISBN do livro que deseja comprar: ");
        string isbn = Console.ReadLine();
        foreach (Livro l in livrosDaLoja)
        {
            if (l != null && isbn == l.Isbn)
            {
                selectedBook = l;
                break;
            }
        }

        if (selectedBook == null)
        {
            Console.WriteLine("Livro não encontrado");
            return;
        }


        // Check if the amount of books is valid
        Console.WriteLine("Quantas copias voce quer?");
        amnt = int.Parse(Console.ReadLine());
        if (amnt > selectedBook.Estoque || amnt <= 0)
        {
            Console.WriteLine("Quantidade Invalida");
            return;
        }

        // Check if the order exists
        if (this.pedidoAtual == null)
        {
            Console.WriteLine("Criando novo pedido...");
            // remember to remove this placeholder later !!!!
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