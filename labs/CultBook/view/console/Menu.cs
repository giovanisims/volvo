namespace CultBook.view.console;

public class Menu
{
    public string MostrarMenu()
    {
        Console.WriteLine("""

        ==============================
             Welcome To CultBook!     
        ==============================
        [1] Login
        [2] Sign-Up
        [3] Look-Up Books
        [4] Add Books To Cart
        [5] Remove Books From Cart
        [6] See Cart
        [7] Complete Purchase
        [8] Quit
        ==============================
        """);

        Console.Write("Choose an option: ");
        return Console.ReadLine(); // Returns the input of the user
    }
}