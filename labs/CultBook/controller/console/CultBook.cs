using model;

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

    Livro[] livros = new Livro[]
    {
        new Livro("978-3-16-148410-0", "O Senhor dos Anéis", "Uma épica aventura na Terra Média.", "J.R.R. Tolkien", 10, 59.90, "Fantasia"),
        new Livro("978-0-7432-7356-5", "O Código Da Vinci", "Um thriller de mistério envolvendo arte e história.", "Dan Brown", 5, 39.90, "Suspense"),
        new Livro("978-1-56619-909-4", "1984", "Um romance distópico sobre vigilância e totalitarismo.", "George Orwell", 8, 29.90, "Ficção Científica"),
        new Livro("978-0-452-28423-4", "Orgulho e Preconceito", "Um clássico romance sobre amor e sociedade.", "Jane Austen", 7, 24.90, "Romance"),
        new Livro("978-0-14-044913-6", "Crime e Castigo", "Um mergulho profundo na mente de um assassino.", "Fiódor Dostoiévski", 4, 34.90, "Ficção")
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
        Console.WriteLine("Login em construção.");
        _logado = true; // "login executado" habilita compra
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