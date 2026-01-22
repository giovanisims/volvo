using model;
using controller.console;

public class CultBook
{
    private bool _logado = false;
    private bool _executando = true;

    private Pedido? pedido;

    private const int OP_LOGIN = 1;
    private const int OP_CADASTRAR = 2;
    private const int OP_BUSCAR_LIVROS = 3;
    private const int OP_INSERIR_CARRINHO = 4;
    private const int OP_REMOVER_CARRINHO = 5;
    private const int OP_VER_CARRINHO = 6;
    private const int OP_COMPRA = 7;
    private const int OP_SAIR = 8;
    private const int INITIAL_QTDE = 1;
    private const int FIRST_PEDIDO_NUMBER = 1;
    private ServicoAutenticacao Sa = new();

    private Cliente[] clientes = new Cliente[]
    {
        new Cliente("Giovani Sims", "giovani", "123456", "giovani@email.com", "41 99999-9999", 
            new Endereco("Rua XV", 123, "", "Centro", "Curitiba", "PR", "80000-000")),
        new Cliente("Admin", "admin", "admin123", "admin@cultbook.com", "41 00000-0000", 
            new Endereco("Rua Imaculada", 1155, "complemento", "Prado Velho", "Curitiba", "PR", "80215-901"))
    };

    Livro[] livros = new Livro[]
    {
        // Normal books (LivroFisico: needs weight and shipping fee)
        new LivroFisico("978-3-16-148410-0", "O Senhor dos Anéis", "Uma épica aventura na Terra Média.", "J.R.R. Tolkien", 10, 59.90, "Fantasia", 1.2, 15.00),
        new LivroFisico("978-0-7432-7356-5", "O Código Da Vinci", "Um thriller de mistério envolvendo arte e história.", "Dan Brown", 5, 39.90, "Suspense", 0.6, 12.00),
        new LivroFisico("978-1-56619-909-4", "1984", "Um romance distópico sobre vigilância e totalitarismo.", "George Orwell", 8, 29.90, "Ficção Científica", 0.4, 10.00),
        new LivroFisico("978-0-452-28423-4", "Orgulho e Preconceito", "Um clássico romance sobre amor e sociedade.", "Jane Austen", 7, 24.90, "Romance", 0.5, 10.00),
        new LivroFisico("978-0-14-044913-6", "Crime e Castigo", "Um mergulho profundo na mente de um assassino.", "Fiódor Dostoiévski", 4, 34.90, "Ficção", 0.8, 12.00),

        // Audio books (AudioLivro)
        new AudioLivro("123-4-56-78901-2", "Dom Casmurro (Audio)", "Clássico de Machado de Assis.", "Machado de Assis", 5, 19.90, "Literatura", "Guilherme Briggs", 12.5),
        new AudioLivro("321-6-54-09876-5", "Sapiens (Audio)", "Uma breve história da humanidade.", "Yuval Noah Harari", 3, 45.00, "História", "Narrador Padrão", 15.0),

        // eBooks (EBook)
        new EBook("978-0-13-235088-4", "Clean Code", "A Handbook of Agile Software Craftsmanship.", "Robert C. Martin", 100, 42.00, "Tecnologia", 5.5),
        new EBook("978-0-13-449416-6", "The Clean Coder", "A Code of Conduct for Professional Programmers.", "Robert C. Martin", 50, 38.50, "Tecnologia", 3.2),
        new EBook("978-0-201-63361-0", "Design Patterns", "Elements of Reusable Object-Oriented Software.", "Gang of Four", 20, 55.00, "Tecnologia", 12.8),
    };

    public static void Main(string[] args)
    {
        CultBook app = new CultBook();
        app.Executar();
    }

    private void Executar()
    {
        while (_executando)
        {
            MostrarMenu();
            int opcao = LerOpcao();
            ProcessarOpcao(opcao);
        }
    }

    private void MostrarMenu()
    {
        Console.Write($"""

            =========== CultBook ===========
            {OP_LOGIN}) Login
            {OP_CADASTRAR}) Cadastrar
            {OP_BUSCAR_LIVROS}) Buscar livros
            {OP_INSERIR_CARRINHO}) Inserir livro no carrinho
            {OP_REMOVER_CARRINHO}) Remover livro do carrinho
            {OP_VER_CARRINHO}) Ver carrinho
            {(_logado ? $"{OP_COMPRA}) Efetuar compra" : $"{OP_COMPRA}) Efetuar compra (desabilitado - faça login)")}
            {OP_SAIR}) Sair
            Escolha uma opção: 
            """);
    }

    private int LerOpcao()
    {
        return Convert.ToInt32(Console.ReadLine());
    }

    private void ProcessarOpcao(int opcao)
    {
        Console.WriteLine();

        switch (opcao)
        {
            case OP_LOGIN:
                Login();
                break;

            case OP_CADASTRAR:
                Console.WriteLine("Cadastrar em construção.");
                break;

            case OP_BUSCAR_LIVROS:
                BuscarLivros();
                break;

            case OP_INSERIR_CARRINHO:
                InserirLivro();
                break;

            case OP_REMOVER_CARRINHO:
                Console.WriteLine("Remover livro do carrinho em construção.");
                break;

            case OP_VER_CARRINHO:
                VerCarrinho();
                break;

            case OP_COMPRA:
                if (!_logado)
                {
                    Console.WriteLine("Efetuar compra está desabilitado. Faça login primeiro.");
                }
                else
                {
                    Console.WriteLine("Efetuar compra em construção.");
                }
                break;

            case OP_SAIR:
                _executando = false;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    private void Login()
    {
       {
        Console.Write("Usuário: ");
        string? loginDigitado = Console.ReadLine();
        Console.Write("Senha: ");
        string? senhaDigitada = Console.ReadLine();

        Cliente? usuario = null;
        foreach (var c in clientes)
        {
            if (c.Login == loginDigitado) {
                usuario = c;
                break;
            }
        }
        
        // I would never implement authentication this way but the diagram specifies
        // that the RealizarLogin function has to return void so I had to do it like this
        if (usuario != null)
        {
            _logado = usuario.ValidarSenha(senhaDigitada ?? "");
            
            Sa.RealizarLogin(usuario, senhaDigitada ?? "");
        }
        else
        {
            Console.WriteLine("Usuário não encontrado.");
            _logado = false;
        }
    }
    }

    public void BuscarLivros()
    {
        for (int i = 0; i < livros.Length; i++)
        {
            if (livros[i] != null)
            {
                Console.WriteLine(livros[i].ToString());
            }
        }
    }

    public void InserirLivro()
    {
        // Lê o livro escolhido do teclado
        Console.WriteLine("=== Inserir Livro no Carrinho ===");
        Console.Write("Digite o ISBN do livro para compra: ");
        String? isbn = Console.ReadLine();

        // Busca livro selecionado
        Livro? aux = null;
        for (int i = 0; i < livros.Length; i++)
        {
            if (livros[i] != null && livros[i].Isbn.Equals(isbn))
            {
                aux = livros[i];
                break;
            }
        }

        // Se não existir, interrompe
        if (aux == null)
        {
            return;
        }

        // Cria item
        ItemDePedido item = new ItemDePedido(aux, INITIAL_QTDE, aux.Preco);

        // Cria pedido se não existir
        if (pedido == null)
        {
            pedido = new Pedido(FIRST_PEDIDO_NUMBER, "2024-01-01", "Cartão de Crédito", "Em Processamento", item);
        }
        else
        {
            pedido.InserirItem(item);
        }

        Console.WriteLine($"Livro adicionado ao carrinho com sucesso!");
    }

    public void VerCarrinho()
    {
        if (pedido != null)
        {
            Console.WriteLine(pedido.ToString());
        }
        else
        {
            Console.WriteLine("Carrinho vazio.");
        }
    }
}