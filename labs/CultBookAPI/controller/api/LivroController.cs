using Microsoft.AspNetCore.Mvc;
using model.livros;
using service;

namespace controller.api;

// The ApiController decorator automates a bunch of necessary and useful behaviors
[ApiController]
// this [Controller] will automatically assign the route based on the class name
[Route("api/[controller]")]
// ControllerBase is a built-in class that provides methods for a bunch of common HTTP codes,
// and properties used for modifying incoming and outgoing traffic
public class LivroController : ControllerBase
{

    private readonly LivroService _livroService;

    public LivroController(LivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpGet]
    // IActionResult is usedfor HTTP compatibility, it converts the return into a JSON
    // And HTTP protocol details.
    // You can also implement IActionResult<T> you keep the felxibility of IAction and still have type-safety

    // Ok is a helper method used for suceessful requests
    // it sets the HTTP status to 200 --> Wraps the data in an OkObjectResults -->
    // Check what format it should reply in and serializes the list
    public IActionResult BuscarLivros() => Ok(_livroService.GetTodos());

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
        var livro = _livroService.GetPorIsbn(isbn);
        return livro != null ? Ok(livro) : NotFound();
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] Livro novoLivro)
    {
        _livroService.Adicionar(novoLivro);
        return CreatedAtAction(nameof(BuscarPorIsbn), new { isbn = novoLivro.Isbn }, novoLivro);
    }
}