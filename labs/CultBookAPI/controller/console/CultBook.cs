using model;
using controller.console;
using System.Globalization;

public class CultBook
{
    private bool _logado = false;
    private bool _executando = true;
    private string _regiao = "pt-BR";
    private Configurador _configurador;
    private Ajuda _ajuda;
    private Pedido? pedido;
    // This is just used for keeping the "Numero" attribute from "Pedido" synchorinzed with the interface
    private int qtdpedido = 1;
    private const int OP_LOGIN = 1;
    private const int OP_CADASTRAR = 2;
    private const int OP_BUSCAR_LIVROS = 3;
    private const int OP_INSERIR_CARRINHO = 4;
    private const int OP_REMOVER_CARRINHO = 5;
    private const int OP_VER_CARRINHO = 6;
    private const int OP_COMPRA = 7;
    private const int OP_MUDAR_REGIAO = 8;
    private const int OP_AJUDA = 9;
    private const int OP_SAIR = 10;
    private const int INITIAL_QTDE = 1;
    private const int FIRST_PEDIDO_NUMBER = 1;
    private ServicoAutenticacao Sa = new();
    Random r = new Random();

    private List<Cliente> clientes = new List<Cliente>();

    public CultBook()
    {
        _configurador = new Configurador();
        _ajuda = new Ajuda(_configurador.ArquivoAjuda);
        _regiao = _configurador.Idioma;

        clientes.Add(new Cliente("Giovani Sims", "giovani", "123456", "giovani@email.com", "41 99999-9999",
            new Endereco("Rua XV", 123, "", "Centro", "Curitiba", "PR", "80000-000")));

        clientes.Add(new Cliente("Admin", "admin", "admin123", "admin@cultbook.com", "41 00000-0000",
            new Endereco("Rua Imaculada", 1155, "complemento", "Prado Velho", "Curitiba", "PR", "80215-901")));
    }

    List<Livro> livros = new List<Livro>
    {
        // Normal books (LivroFisico: needs weight and shipping fee)
        new LivroFisico("978-3-16-148410-0", "O Senhor dos Anéis", "Uma épica aventura na Terra Média.", "J.R.R. Tolkien", 10, 59.90m, "Fantasia", 1.2, 15.00m),
        new LivroFisico("978-0-7432-7356-5", "O Código Da Vinci", "Um thriller de mistério envolvendo arte e história.", "Dan Brown", 5, 39.90m, "Suspense", 0.6, 12.00m),
        new LivroFisico("978-1-56619-909-4", "1984", "Um romance distópico sobre vigilância e totalitarismo.", "George Orwell", 8, 29.90m, "Ficção Científica", 0.4, 10.00m),
        new LivroFisico("978-0-452-28423-4", "Orgulho e Preconceito", "Um clássico romance sobre amor e sociedade.", "Jane Austen", 7, 24.90m, "Romance", 0.5, 10.00m),
        new LivroFisico("978-0-14-044913-6", "Crime e Castigo", "Um mergulho profundo na mente de um assassino.", "Fiódor Dostoiévski", 4, 34.90m, "Ficção", 0.8, 12.00m),

        // Audio books (AudioLivro)
        new AudioLivro("123-4-56-78901-2", "Dom Casmurro (Audio)", "Clássico de Machado de Assis.", "Machado de Assis", 5, 19.90m, "Literatura", "Guilherme Briggs", 12.5),
        new AudioLivro("321-6-54-09876-5", "Sapiens (Audio)", "Uma breve história da humanidade.", "Yuval Noah Harari", 3, 45.00m, "História", "Narrador Padrão", 15.0),

        // eBooks (EBook)
        new EBook("978-0-13-235088-4", "Clean Code", "A Handbook of Agile Software Craftsmanship.", "Robert C. Martin", 100, 42.00m, "Tecnologia", 5.5),
        new EBook("978-0-13-449416-6", "The Clean Coder", "A Code of Conduct for Professional Programmers.", "Robert C. Martin", 50, 38.50m, "Tecnologia", 3.2),
        new EBook("978-0-201-63361-0", "Design Patterns", "Elements of Reusable Object-Oriented Software.", "Gang of Four", 20, 55.00m, "Tecnologia", 12.8),
    };

    private void MostrarMenu()
    {
        // Console.Write($"""

        //     =========== CultBook ===========
        //     Horário: {ObterHoraFormatada()}
        //     Região: {_regiao}
        //     {OP_LOGIN}) Login
        //     {OP_CADASTRAR}) Cadastrar
        //     {OP_BUSCAR_LIVROS}) Buscar livros
        //     {OP_INSERIR_CARRINHO}) Inserir livro no carrinho
        //     {OP_REMOVER_CARRINHO}) Remover livro do carrinho
        //     {OP_VER_CARRINHO}) Ver carrinho
        //     {(_logado ? $"{OP_COMPRA}) Efetuar compra" : $"{OP_COMPRA}) Efetuar compra (desabilitado - faça login)")}
        //     {OP_MUDAR_REGIAO}) Mudar Região
        //     {OP_AJUDA}) Ajuda
        //     {OP_SAIR}) Sair
        //     Escolha uma opção: 
        //     """);
    }

    private int LerOpcao()
    {
        return Convert.ToInt32(Console.ReadLine());
    }

    private string ObterHoraFormatada()
    {
        // I wasnt sure if I was just supposed to change the formatting of the time based on region 24h --> 12h 
        // Or if I was supposed to actually change the timezone according to the region choice
        // I opted for the latter
        string timezoneId = _regiao switch
        {
            "pt-BR" => "America/Sao_Paulo",
            "fr-FR" => "Asia/China",
            "en-US" => "America/New_York",
            _ => "UTC"
        };

        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
        DateTime localTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tz);
        return localTime.ToString("T", new CultureInfo(_regiao));

    }

    private void MudarRegiao()
    {
        Console.WriteLine("""
        Escolha sua região:
        1) Brasil (PT-BR)
        2) China (ZH-CN)
        3) EUA (EN-US)
        """);
        int op = LerOpcao();
        _regiao = op switch
        {
            1 => "pt-BR",
            2 => "zh-CN",
            3 => "en-US",
            _ => "pt-BR"
        };
        Console.WriteLine($"Região alterada para: {_regiao}");
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
                Cadastrar();
                break;

            case OP_BUSCAR_LIVROS:
                BuscarLivros();
                break;

            case OP_INSERIR_CARRINHO:
                InserirLivro();
                break;

            case OP_REMOVER_CARRINHO:
                RemoverLivro();
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
                    EfetuarCompra();
                }
                break;

            case OP_MUDAR_REGIAO:
                MudarRegiao();
                break;

            case OP_AJUDA:
                ExibirAjuda();
                break;

            case OP_SAIR:
                _executando = false;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    public void EfetuarCompra()
    {
        if (pedido == null)
        {
            Console.WriteLine("Não há pedido para processar.");
            return;
        }

        decimal totalFrete = 0;
        foreach (var item in pedido.Itens)
        {
            // Check if the Livro is a LivroFisico to access ValorFrete
            if (item.Livro is LivroFisico fisico)
            {   
                // Right now i's pointless to multiply per qtde but iy's still good logic to have
                totalFrete += fisico.ValorFrete * item.Qtde; 
            }
        }

        Console.WriteLine($"""
        Resumo Pedido {qtdpedido}
        {pedido}
        Valor Total dos Itens: {pedido.ValorTotal:C}
        Valor Total do Frete: {totalFrete:C}
        Valor Final: {(pedido.ValorTotal + totalFrete):C}
        """);

        string? confirma = Input("\nDeseja efetuar a compra? (S/N): ")?.ToLower().Trim();

        if (confirma != "s" && confirma != "sim")
        {
            Console.WriteLine("Compra cancelada pelo usuário.");
            return;
        }

        Console.WriteLine("\nCompra efetuada com sucesso!");

        pedido = null;
        qtdpedido++;

    }


    private void Login()
    {
        {
            string? loginDigitado = Input("Usuário: ");
            string? senhaDigitada = Input("Senha: ");

            Cliente? usuario = null;
            foreach (var c in clientes)
            {
                if (c != null && c.Login == loginDigitado)
                {
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


    public void Cadastrar()
    {
        // Actual client info
        string? nome = Input("Nome: ");
        string? login = Input("Login: ");
        string? senha = Input("Senha: ");
        // password needs to be 8 digits with numbers with a letter an a symbol
        if (string.IsNullOrWhiteSpace(senha))
        {
            // I know this is far from teh best implementation for a password generator but it's just for testing purposes
            senha = r.Next(100000, 999999).ToString();
            // ASCII capital alphabet starts at 65 
            senha += (char)r.Next(65, 91);
            senha += (char)r.Next(33, 48); // Some random symbols

            Console.WriteLine($"Senha gerada automaticamente: {senha}");

        }
        string? email = Input("Email: ");
        string? fone = Input("Telefone: ");

        // Address info that the client class needs on creation
        string rua = Input("Rua: ") ?? "";
        int.TryParse(Input("Número: "), out int num);
        string comp = Input("Complemento: ") ?? "";
        string bairro = Input("Bairro: ") ?? "";
        string cidade = Input("Cidade: ") ?? "";
        string estado = Input("Estado: ") ?? "";
        string cep = Input("CEP: ") ?? "";

        Endereco endereco = new Endereco(rua, num, comp, bairro, cidade, estado, cep);
        Cliente cliente = new Cliente(nome ?? "", login ?? "", senha ?? "", email ?? "", fone ?? "", endereco);

        clientes.Add(cliente);
        Console.WriteLine("\nUsuário cadastrado com sucesso!");
    }
    public void BuscarLivros()
    {
        foreach (var livro in livros)
        {
            Console.WriteLine(livro.ToString());
        }
    }

    public void InserirLivro()
    {
        try
        {
            // Lê o livro escolhido do teclado
            Console.WriteLine("=== Inserir Livro no Carrinho ===");
            string? isbn = Input("Digite o ISBN do livro para compra: ")?.Trim();

            // Busca livro selecionado
            Livro? aux = null;
            foreach (var livro in livros)
            {
                if (livro != null && livro.Isbn.Equals(isbn))
                {
                    aux = livro;
                    break;
                }
            }

            // Se não existir, lança exceção
            if (aux == null)
            {
                throw new LivroNaoEncontradoException($"O livro com ISBN {isbn} não foi encontrado no catálogo.");
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
        catch (LivroNaoEncontradoException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    public void RemoverLivro()
    {

        {
            try
            {
                Console.WriteLine("=== Remover Livro no Carrinho ===");
                string? isbn = Input("Digite o ISBN do livro para removed do carrinho: ")?.Trim();

                ItemDePedido? aux = null;


                if (pedido != null)
                {
                    foreach (var item in pedido.Itens)
                    {
                        if (item.Livro.Isbn.Equals(isbn))
                        {
                            aux = item;
                        }
                    }

                }

                if (aux == null)
                {
                    throw new LivroNaoEncontradoException($"O livro com ISBN {isbn} não foi encontrado no carrinho.");
                }


                pedido?.Itens.Remove(aux);

                if (pedido != null)
                {
                    pedido.ValorTotal -= aux.Preco * aux.Qtde;
                }

                Console.WriteLine($"Livro removido do carrinho com sucesso!");



            }
            catch (LivroNaoEncontradoException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
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

    // Helper methods are really cool, not sure where you are supposed to place thm tho
    private string? Input(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    private void ExibirAjuda()
    {
        Console.WriteLine("\n=== AJUDA ===");
        Console.WriteLine(_ajuda.GetTexto());
        Console.WriteLine("=============\n");
    }
}

public class LivroNaoEncontradoException : Exception
{
    public LivroNaoEncontradoException() { }

    public LivroNaoEncontradoException(string message) : base(message) { }

    public LivroNaoEncontradoException(string message, Exception inner) : base(message, inner) { }
}