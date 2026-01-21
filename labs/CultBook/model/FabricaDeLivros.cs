
namespace CultBook.model
{
    public class FabricaDeLivros
    {
        private Livro[] livros;

        public FabricaDeLivros()
        {
            livros = new Livro[5];
            livros[0] = new Livro("111", "C# Guide", "Learn C#", "Microsoft", 10, 50.00, "img1", DateTime.Now, "Tech");
            livros[1] = new Livro("222", "Clean Code", "Best practices", "Uncle Bob", 5, 120.00, "img2", DateTime.Now, "Tech");
            livros[2] = new Livro("333", "The Witcher", "Geralt's journey", "Sapkowski", 2, 45.00, "img3", DateTime.Now, "Fantasy");
            livros[3] = new Livro("444", "Dune", "Sand worms", "Herbert", 8, 60.00, "img4", DateTime.Now, "SciFi");
            livros[4] = new Livro("555", "1984", "Big Brother", "Orwell", 10, 30.00, "img5", DateTime.Now, "Fiction");
        }

        public Livro[] BuscarTodos()
        {
            return livros;
        }

        public Livro BuscarLivro(string isbn)
        {
            foreach (Livro l in livros)
            {
                if (l != null && l.Isbn == isbn)
                {
                    return l;
                }
            }
            return null;
        }
    }
}