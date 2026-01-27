using model.livros;
namespace service;

public class LivroService
{
    // Static isnt necessary here but it would be very important if this was actually used in prod
    // but also you wouldnt be creating this list in the controller
    private readonly List<Livro> _livros = new List<Livro>
    {
        new LivroFisico("978-3-16-148410-0", "O Senhor dos Anéis", "Uma épica aventura na Terra Média.", "J.R.R. Tolkien", 10, 59.90m, "Fantasia", 0.8, 15.00m),
        new LivroFisico("978-0-7432-7356-5", "O Código Da Vinci", "Um thriller de mistério envolvendo arte e história.", "Dan Brown", 5, 39.90m, "Suspense", 0.5, 12.00m),
        new LivroFisico("978-1-56619-909-4", "1984", "Um romance distópico sobre vigilância e totalitarismo.", "George Orwell", 8, 29.90m, "Ficção Científica", 0.4, 10.00m),
        new LivroFisico("978-0-452-28423-4", "Orgulho e Preconceito", "Um clássico romance sobre amor e sociedade.", "Jane Austen", 7, 24.90m, "Romance", 0.3, 8.00m),
        new LivroFisico("978-0-14-044913-6", "Crime e Castigo", "Um mergulho profundo na mente de um assassino.", "Fiódor Dostoiévski", 4, 34.90m, "Ficção", 0.6, 13.00m),
        
        new AudioLivro("978-0-06-231609-7", "Sapiens (Audiobook)", "Uma breve história da humanidade.", "Yuval Noah Harari", 6, 79.90m, "História", "João Silva", 15.5),
        new AudioLivro("978-85-359-1419-9", "O Alquimista (Audiobook)", "Jornada espiritual de Santiago.", "Paulo Coelho", 9, 49.90m, "Ficção", "Maria Souza", 6.2),
        new AudioLivro("978-0-525-43314-8", "Becoming (Audiobook)", "Memórias de Michelle Obama.", "Michelle Obama", 5, 69.90m, "Biografia", "Ana Martins", 19.0),
        
        new EBook("978-1-23-456789-0", "A Arte da Guerra", "Tratado militar sobre estratégia e táticas.", "Sun Tzu", 15, 19.90m, "Filosofia", 2.5),
        new EBook("978-1-11-222333-4", "O Poder do Hábito", "Como os hábitos funcionam e como mudá-los.", "Charles Duhigg", 12, 29.90m, "Autoajuda", 3.2)
    };

    // This is just another syntax to do a one line return 
    public List<Livro> GetTodos() => _livros;

    public Livro? GetPorIsbn(string isbn)
    {
        // Find is a built in function of collections to run a foreach and a equals check
        // could also be using LINQ instead but it would be overkill
        return _livros.Find(l => l.Isbn.Equals(isbn));
    }
    
    public void Adicionar(Livro novoLivro)
    {
        _livros.Add(novoLivro);
    }
}