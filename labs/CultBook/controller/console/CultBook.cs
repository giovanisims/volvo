using CultBook.model;
using CultBook.view.console;

namespace CultBook.controller.console;

public class CultBook
{
    private Livro[] livrosDaLoja;
    private Pedido pedidoAtual;
    private MostrarMenu menu;

    bool loggedIn = false;

    public CultBook()
    {
        menu = new MostrarMenu();
    }

    static void Main(string[] args)
    {
        CultBook cb = new CultBook();
        bool running = true;

        while (running) {
            
            menu.Menu();
            break;
        }
    }
}