using Microsoft.AspNetCore.Mvc;
using model;

namespace controller.console;

// The ApiController decorator automates a bunch of necessary and useful behaviors
[ApiController] 
[Route("api/[controller]")]
// ControllerBase is a built-in class that provides methods for a bunch of common HTTP codes,
// and properties used for modifying incoming and outgoing traffic
public class LivroController : ControllerBase
{
    // Static isnt necessary here but it would be very important if this was actually used in prod
    // but also you wouldnt be creating this list in the controller
    private static List<Livro> _livros = new List<Livro>
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

    [HttpGet]
    // IActionResult is usedfor HTTP compatibility, it converts the return into a JSON
    // And HTTP protocol details.
    // You can also implement IActionResult<T> you keep the felxibility of IAction and still have type-safety
    public IActionResult BuscarLivros()
    {
        // Ok is a helper method used for suceessful requests
        // it sets the HTTP status to 200 --> Wraps the data in an OkObjectResults -->
        // Check what format it should reply in and serializes the list
        return Ok(_livros);
    }

    // The user who made the request gets a clean JSON like 
    /*
    [
    { "foo": "bar", "bar": "foo", ... },
    { "foo": "bar", "bar": "foo", ... }
    ]

    instead of getting the whole response like: 
    {
    "statusCode": 200,
    "value": [ foo, bar, ... ],
    "contentType": null
    }
    Unless you have a 400 error and then it send the full problem report
    */

    // This is a route parameter not a query parameter
    // we are using it to create the pattern for REST URls
    [HttpGet("{isbn}")] 
    public IActionResult BuscarPorIsbn(string isbn)
    {
        // Find is a built in function of collections to run a foreach and a equals check
        // could also be using LINQ instead but it would be overkill
        var livro = _livros.Find(l => l.Isbn.Equals(isbn));
        return livro != null ? Ok(livro) : NotFound();
    }
}