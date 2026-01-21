using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace CultBook.controller.console;

public class CultBook
{
    bool logedIn = false;

    static void Main(string[] args)
    {
        bool running = true;

        CultBook cb = new CultBook();

        while (running)
        {
            running = cb.MostrarMenu();
        }
    }

    public bool MostrarMenu()
    {

        Console.WriteLine($"""
        ==============================
             Welcome To CultBook!     
        ==============================
        [1] Login
        [2] Sign-Up
        [3] Look-Up Books
        [4] Add Books To Cart
        [5] Remove Books From Cart
        [6] Look-Up Cart
        [7] Complete Purchase
        [8] Quit
        """);

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine($"Você logou com sucesso");
                logedIn = true;
                Console.WriteLine($"Opção {choice} em construção");
                break;
            case "2":
                Console.WriteLine($"Opção {choice} em construção");
                break;
            case "3":
                Console.WriteLine($"Opção {choice} em construção");
                break;
            case "4":
                Console.WriteLine($"Opção {choice} em construção");
                break;
            case "5":
                Console.WriteLine($"Opção {choice} em construção");
                break;
            case "6":
                Console.WriteLine($"Opção {choice} em construção");
                break;
            case "7":
                if (logedIn)
                {
                    Console.WriteLine("Compra liberada");
                }
                else
                {
                    Console.WriteLine("É necessario fazer login antes de completar a compra");
                }
                break;
            case "8":
                Console.WriteLine("Goodbye!");
                return false;
                break;
            case "_":
                Console.WriteLine("Invalid Option");
                break;
        }

        return true;
    }
}