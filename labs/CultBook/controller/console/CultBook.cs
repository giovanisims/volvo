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
    }

    static void Main(string[] args)
    {
        CultBook app = new CultBook();
        bool running = true;

        while (running)
        {

            string choice = app.menu.MostrarMenu();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Login em construção.");
                    app.loggedIn = true;
                    Console.WriteLine("Logged-In successfully!");
                    break;
                case "2":
                    Console.WriteLine("Sign-Up em construção.");
                    break;
                case "3":
                    app.BuscarLivros();
                    Console.WriteLine("Look-Up Books em construção.");
                    break;
                case "4":
                    app.InserirLivro();
                    Console.WriteLine("Add Books To Cart em construção.");
                    break;
                case "5":
                    Console.WriteLine("Remove Books From Cart em construção.");
                    break;
                case "6":
                    app.VerCarrinho();
                    Console.WriteLine("See Cart em construção.");
                    break;
                case "7":
                    if (app.loggedIn)
                    {
                        Console.WriteLine("Purchase successfull");
                    }
                    else
                    {
                        Console.WriteLine("Please login first.");
                    }
                    break;
                case "8":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}