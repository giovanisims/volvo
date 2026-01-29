using model.livros;
using model.dto;
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

    // Select iterates through each Livro object in the _livros list and check them agains the switch expression 
    // to figure out what to add-on depending on the type, and then I'm not 100% sure why you need the toList
    // but I think it's because the Select function doesnt return a normal List
    public List<LivroDTO?> GetTodos() => _livros.Select(MapParaDto).ToList();

    public Livro? GetModelPorIsbn(string isbn) => _livros.Find(l => l.Isbn == isbn);

    public LivroDTO? GetPorIsbn(string isbn)
    {
        var livro = GetModelPorIsbn(isbn);
        return livro != null ? MapParaDto(livro) : null;    
    }

    /*
    We need this help method otherwse all the GET requests are going to be based
    on the abstract book class which is of course missing the properties added in
    the daughter classee i.e:
    
    {
    "isbn": "978-0-7432-7356-5",
    "titulo": "O Código Da Vinci",
    "descricao": "Um thriller de mistério envolvendo arte e história.",
    "autor": "Dan Brown",
    "estoque": 5,
    "preco": 39.9,
    "categoria": "Suspense" 
    }, 

    This book belongs to the "LivroFisico" class however because the JSON serializer
    Was defined with only the Livro class it's missing both "Peso" and "ValorFrete"
    */ 
    private LivroDTO MapParaDto(Livro livro) => livro switch
    {
        LivroFisico f => new LivroDTO 
        { 
            Tipo = "fisico", Isbn = f.Isbn, Titulo = f.Titulo, Descricao = f.Descricao, 
            Autor = f.Autor, Estoque = f.Estoque, Preco = f.Preco, Categoria = f.Categoria,
            Peso = f.Peso, ValorFrete = f.ValorFrete 
        },
        AudioLivro a => new LivroDTO 
        { 
            Tipo = "audio", Isbn = a.Isbn, Titulo = a.Titulo, Descricao = a.Descricao, 
            Autor = a.Autor, Estoque = a.Estoque, Preco = a.Preco, Categoria = a.Categoria,
            Narrador = a.Narrador, TempoDeDuracao = a.TempoDeDuracao 
        },
        EBook e => new LivroDTO 
        { 
            Tipo = "ebook", Isbn = e.Isbn, Titulo = e.Titulo, Descricao = e.Descricao, 
            Autor = e.Autor, Estoque = e.Estoque, Preco = e.Preco, Categoria = e.Categoria,
            Tamanho = e.Tamanho 
        },
        _ => throw new ArgumentException("Tipo de livro desconhecido")
    };

    
    public Livro? Adicionar(LivroDTO dto)
    {
        // switch expressions are really cool
        Livro? novoLivro = dto.Tipo.ToLower() switch
        {
            "fisico" => new LivroFisico(dto.Isbn, dto.Titulo, dto.Descricao, dto.Autor, dto.Estoque, dto.Preco, dto.Categoria, dto.Peso ?? 0, dto.ValorFrete ?? 0),
            "audio" => new AudioLivro(dto.Isbn, dto.Titulo, dto.Descricao, dto.Autor, dto.Estoque, dto.Preco, dto.Categoria, dto.Narrador ?? "", dto.TempoDeDuracao ?? 0),
            "ebook" => new EBook(dto.Isbn, dto.Titulo, dto.Descricao, dto.Autor, dto.Estoque, dto.Preco, dto.Categoria, dto.Tamanho ?? 0),
            _ => null
        };

        if (novoLivro != null)
        {
            _livros.Add(novoLivro);
        }

        return novoLivro;
    }
}

