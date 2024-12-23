namespace JogoDaForca
{

    public class Boneco
    {
        private List<string> boneco;
        public Boneco()
        {

            boneco = new List<string>();

            boneco.Add("|-----↓   \n" +
                       "|     |   \n" +
                       "|     O   \n" +
                       "|    -|-  \n" +
                       "|    / \\ \n");

            boneco.Add("|-----↓   \n" +
                       "|     |   \n" +
                       "|     O   \n" +
                       "|    -|-  \n" +
                       "|    /    \n");

            boneco.Add("|-----↓   \n" +
                       "|     |   \n" +
                       "|     O   \n" +
                       "|    -|-  \n" +
                       "|         \n");

            boneco.Add("|-----↓   \n" +
                       "|     |   \n" +
                       "|     O   \n" +
                       "|    -|   \n" +
                       "|         \n");

            boneco.Add("|-----↓   \n" +
                       "|     |   \n" +
                       "|     O   \n" +
                       "|    |    \n" +
                       "|         \n");

            boneco.Add("|-----↓   \n" +
                       "|     |   \n" +
                       "|     O   \n" +
                       "|         \n" +
                       "|         \n");

            boneco.Add("|-----↓   \n" +
                       "|     |   \n" +
                       "|     X   \n" +
                       "|         \n" +
                       "|         \n");
        }

        public string GetBonecoByIndex(int index)
        {
            return boneco[index];
        }

    }

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
            tentativasMaximas = 7;
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

            Boneco boneco = new Boneco();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("|----------------------------|");
                Console.WriteLine("| Bem vindo ao jogo da forca |");
                Console.WriteLine("|----------------------------|");

                switch (tentativasMaximas)
                {
                    case 7:
                        Console.WriteLine(boneco.GetBonecoByIndex(0));
                        break;
                    case 6:
                        Console.WriteLine(boneco.GetBonecoByIndex(1));
                        break;
                    case 5:
                        Console.WriteLine(boneco.GetBonecoByIndex(2));
                        break;
                    case 4:
                        Console.WriteLine(boneco.GetBonecoByIndex(3));
                        break;
                    case 3:
                        Console.WriteLine(boneco.GetBonecoByIndex(4));
                        break;
                    case 2:
                        Console.WriteLine(boneco.GetBonecoByIndex(5));
                        break;
                    case 1:
                        break;
                }

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

                        if (tentativasMaximas == 1)
                        {
                            Console.Clear();

                            Console.WriteLine(boneco.GetBonecoByIndex(6));

                            Console.WriteLine("Você perdeu!, a palavra escondida era:" + palavraGerada);
                            break;
                        }
                    }
                }
                catch
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
