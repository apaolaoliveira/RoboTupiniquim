namespace RoboTupiniquim
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Contexto

            Console.WriteLine("Robô Tupiniquim");
            Console.WriteLine("Monte um tabuleiro, mova o robô e descubra as suas coordenadas finais.");
            Console.WriteLine();

            //variáveis

            string strTabuleiro, strMovimentacao, strPosicaoInicial, strPosicaoFinal;

            int xMin = 0, yMin = 0, xMax, yMax, xRobo, yRobo;

            char bussola;

            bool continuar;

            do
            {
                //Input
                //Tabuleiro

                Console.WriteLine();
                Console.Write("Digite a dimensão X Y máxima do tabuleiro, como 5 5: ");
                strTabuleiro = Console.ReadLine();

                string[] tabuleiro = strTabuleiro.Split(" ");
                xMax = Convert.ToInt32(tabuleiro[0]);
                yMax = Convert.ToInt32(tabuleiro[1]);

                //Posição Inicial

                Console.WriteLine();
                Console.WriteLine("Informe a posição inicial do Tupiniquim (1 2 N --> X, Y, Direção que o robô está virado).");
                Console.WriteLine("[N] Norte, [S] Sul, [L] Leste, [O] Oeste.");
                Console.WriteLine();
                Console.Write("Posição Inicial: ");
                strPosicaoInicial = Console.ReadLine().ToUpper();

                string[] posicaoInicial = strPosicaoInicial.Split(" ");
                xRobo = Convert.ToInt32(posicaoInicial[0]);
                yRobo = Convert.ToInt32(posicaoInicial[1]);
                bussola = Convert.ToChar(posicaoInicial[2]);

                //Bússola 

                Console.WriteLine();
                Console.WriteLine("Informe os comandos para o robô se mover, por exemplo EMEMEMEMM.");
                Console.WriteLine("[D] Direita, [E] Esquerda, [M] Mover para frente.");
                Console.WriteLine();
                Console.Write("Movimentações: ");
                strMovimentacao = Console.ReadLine().ToUpper();

                char[] movimento = strMovimentacao.ToCharArray();

                //Processamento

                for (int i = 0; i < movimento.Length; i++)
                {

                    if (movimento[i] == 'E') // ir para esquerda
                    {
                        switch (bussola)
                        {
                            case 'N': bussola = 'O'; break;
                            case 'S': bussola = 'L'; break;
                            case 'L': bussola = 'N'; break;
                            case 'O': bussola = 'S'; break;
                        }
                    }
                    else if (movimento[i] == 'D') // ir para direita
                    {
                        switch (bussola)
                        {
                            case 'N': bussola = 'L'; break;
                            case 'S': bussola = 'O'; break;
                            case 'L': bussola = 'S'; break;
                            case 'O': bussola = 'N'; break;
                        }
                    }
                    else if (movimento[i] == 'M') // seguir em frente
                    {
                        switch (bussola)
                        {
                            case 'N': yRobo = Math.Min(yRobo + 1, yMax); break; // limite superior
                            case 'S': yRobo = Math.Max(yRobo - 1, yMin); break; // limite inferior
                            case 'L': xRobo = Math.Min(xRobo + 1, xMax); break; // limite direito
                            case 'O': xRobo = Math.Max(xRobo - 1, xMin); break; // limite esquerdo
                        }
                    }
                }

                //Output

                Console.WriteLine();
                Console.WriteLine($"Coordenadas finais: {xRobo}, {yRobo}, {bussola}");
                Console.WriteLine();

                //Ir novamente ou sair do console

                Console.Write("Digite [S] para sair ou [A] para adicionar mais um robô para o mapeamento: ");
                var adicionaRobo = Convert.ToChar(Console.ReadLine().ToUpper());

                continuar = adicionaRobo == 'A';

                Console.Clear();

            } while (continuar == true);
        }
    }
}

