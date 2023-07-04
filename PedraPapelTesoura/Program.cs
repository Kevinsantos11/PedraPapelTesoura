using System;

class Program
{
    static int rodadas;

    static string escolhaDoJogador;

    static string escolhaDoBot;

    static string[] jogoDoBot =
    {
        "PEDRA",
        "PAPEL",
        "TESOURA"
    };



    public static void Main(string[] args)
    {
        Start();
    }

    public static void Start()
    {
        DesenhaCabe();

        int numer_inicial;

        numer_inicial = Int32.Parse(Console.ReadLine());

        while (numer_inicial != 1)
        {
            DesenhaCabe();
            Console.WriteLine("Opção invalida, digite 1 para começar");
            numer_inicial = Int32.Parse(Console.ReadLine());
        }

        DefineRodadas();


    }

    public static void DesenhaCabe()
    {
        Console.Clear();
        Console.WriteLine("******************************");
        Console.WriteLine("*   Pedra, Papel e Tesoura   *");
        Console.WriteLine("******************************");
        Console.WriteLine("\n\n\n");
        Console.WriteLine("*  Digite \"1\" para começar  *");
    }

    public static void DesenhaCabet()
    {
        Console.Clear();
        Console.WriteLine("******************************");
        Console.WriteLine("*   Pedra, Papel e Tesoura   *");
        Console.WriteLine("******************************");
        Console.WriteLine("\n\n\n");
    }

    public static void DefineRodadas()
    {
        DesenhaCabet();
        Console.WriteLine("Quantas rodadas você quer jogar? 3, 5 ou 7");
        rodadas = Int32.Parse(Console.ReadLine());

        while (rodadas != 3 && rodadas != 5 && rodadas != 7)
        {
            DesenhaCabet();
            Console.WriteLine("Digite um valor entre os números recomendados: 3, 5 ou 7");
            rodadas = Int32.Parse(Console.ReadLine());
        }

        ControlaRodadas();

    }


    public static void ControlaRodadas()
    {
        bool fimDeJogo = false;
        int rodadaAtual = 1;
        int pontosUsuario = 0;
        int pontosDoBot = 0;
        int metade = rodadas / 2;

        while (fimDeJogo != true)
        {
            Random rnd = new Random();
            int aleatorio = rnd.Next(3);
            escolhaDoBot = jogoDoBot[aleatorio];

            DesenhaCabet();
            Console.WriteLine("****** rodada " + rodadaAtual + "/" + rodadas + " ******");
            Console.WriteLine("User: " + pontosUsuario + " pontos | Bot: " + pontosDoBot + " pontos");
            Console.WriteLine("Escolha: pedra,papel ou tesoura");
            escolhaDoJogador = Console.ReadLine().ToUpper();
            Console.WriteLine("O bot escolheu: " + escolhaDoBot);

            int retorno = Jogo();

            if (retorno == 0)
            {
                Console.WriteLine("Empate");
                Console.WriteLine("Digite qualquer coisa para continuar");
                Console.ReadLine();
            }

            else if (retorno == 1)
            {
                Console.WriteLine("Você venceu");
                Console.WriteLine("Digite qualquer coisa para continuar");
                pontosUsuario++;
                rodadaAtual++;
                Console.ReadLine();

                if (pontosUsuario > metade)
                {
                    DesenhaCabe();
                    Console.WriteLine("Você venceu.");
                    fimDeJogo = true;
                }
            }

            else if (retorno == 2)
            {
                Console.WriteLine("Você perdeu");
                Console.WriteLine("Digite qualquer coisa para continuar");
                pontosDoBot++;
                rodadaAtual++;
                Console.ReadLine();

                if (pontosDoBot > metade)
                {
                    DesenhaCabe();
                    Console.Clear();
                    Console.WriteLine("O bot venceu.");
                    fimDeJogo = true;
                }
            }

        }

        string usuario = "p";

        while (usuario != "S" && usuario != "N")
        {
            Console.WriteLine("Se deseja recomeçar, digite S, se não, digite N.");
            usuario = Console.ReadLine().ToUpper();
            Console.Clear();
        }

        if (usuario == "S")
        {
            DefineRodadas();
        }

        else
        {
            Console.WriteLine("Até mais");
        }

    }

    public static int Jogo()
    {
        if (escolhaDoJogador != "PEDRA" && escolhaDoJogador != "TESOURA" && escolhaDoJogador != "PAPEL")
        {
            Console.WriteLine("\nNão digitou o pedido, então perdera um ponto.\n");
        }

        if (escolhaDoBot == escolhaDoJogador)
        {
            return 0;
        }

        else if (escolhaDoJogador == "PEDRA" && escolhaDoBot == "TESOURA")
        {
            return 1;
        }

        else if (escolhaDoJogador == "PAPEL" && escolhaDoBot == "PEDRA")
        {
            return 1;
        }

        else if (escolhaDoJogador == "TESOURA" && escolhaDoBot == "PAPEL")
        {
            return 1;
        }

        else
        {
            return 2;
        }

    }

}