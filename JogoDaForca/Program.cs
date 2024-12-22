namespace JogoDaForca
{
    public class Palavra
    {
        public string palavraGerada { get; private set; }
        public string palavraEscondida { get; private set; }
        public int tentativasMaximas { get; private set; }

        private List<string> listaDePalavras = new List<string> { "arroz", "cravo", "semente", "folha", "banana" };

        private static Random random = new Random();

        public Palavra()
        {
            int randomIndex = random.Next(listaDePalavras.Count);
            palavraGerada = listaDePalavras[randomIndex];
            tentativasMaximas = 5;
        }

        public string RetornaPalavraEscondida()
        {
            for (int i = 0; i < palavraGerada.Length; i++)
            {
                palavraEscondida += "_";
            }
            return palavraEscondida;

        }

        public void AdivinharPalavra()
        {

            string palavraEscondida = RetornaPalavraEscondida();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("|----------------------------|");
                Console.WriteLine("| Bem vindo ao jogo da forca |");
                Console.WriteLine("|----------------------------|");
                Console.WriteLine("Tentativas disponíves:" + tentativasMaximas);

                Console.WriteLine("Palavra: " + palavraEscondida);

                Console.Write("Tentativa: ");

                try
                {
                    char tentativaLetra = Char.Parse(Console.ReadLine());

                    if (palavraGerada.Contains(tentativaLetra))
                    {
                        for (int i = 0; i < palavraGerada.Length; i++)
                        {
                            if (palavraGerada[i] == tentativaLetra)
                            {
                                char[] palavraEscondidaArray = palavraEscondida.ToCharArray();

                                palavraEscondidaArray[i] = palavraGerada[i];

                                palavraEscondida = new string(palavraEscondidaArray);
                            }
                        }
                    }
                    else
                    {
                        tentativasMaximas -= 1;

                        if (tentativasMaximas <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Você perdeu!, a palavra escondida era:" + palavraGerada);
                            break;
                        }
                    }
                } catch
                {
                    Console.Clear();
                    Console.WriteLine("Digite uma letra entre A-Z");
                    Console.WriteLine();
                    Console.WriteLine("Digite algo para sair.");
                    Console.ReadKey();
                }

                if (palavraEscondida == palavraGerada)
                {
                    Console.Clear();
                    Console.WriteLine("Parabéns, você venceu!, a palavra escondida era:" + palavraGerada);
                    break;
                }

                Console.WriteLine("Palavra: " + palavraEscondida);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {

                Palavra palavraGerada = new Palavra();
                Console.WriteLine("Palavra gerada: " + palavraGerada.palavraGerada);

                palavraGerada.AdivinharPalavra();
            }
        }
    }
}
