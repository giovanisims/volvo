namespace CultBook.model;

public class FabricaDeLivros
{
    private Livro[] livros;

    public FabricaDeLivros()
    {
        livros = new Livro[] {
            new Livro("111", "The C# Yellow Book", "Learn C#", "Rob Miles", 10, 19.99, "img1.jpg", DateTime.Now, "Education"),
            new Livro("222", "Clean Code", "Agile Software Craftsmanship", "Robert C. Martin", 5, 45.00, "img2.jpg", DateTime.Now, "Programming"),
            new Livro("333", "Design Patterns", "Elements of Reusable Object-Oriented Software", "Erich Gamma", 8, 55.00, "img3.jpg", DateTime.Now, "Architecture"),
            new Livro("444", "Domain-Driven Design", "Tackling Complexity in the Heart of Software", "Eric Evans", 12, 60.00, "img4.jpg", DateTime.Now, "Architecture"),
            new Livro("555", "Effective Java", "Best practices for Java", "Joshua Bloch", 15, 40.00, "img5.jpg", DateTime.Now, "Programming")
        };
    }

    public Livro[] BuscarLivros()
    {
        return livros;
    }

    public Livro BuscarLivro(string isbn)
    {
        foreach(var livro in livros)
        {
            if (livro.Isbn == isbn)
            {
                return livro;
            }
        }
        return null;
    }
}
