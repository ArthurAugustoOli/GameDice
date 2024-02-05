using System;
using System.Threading;
class GameDice
{
	static void Main()
	{
		string Name1, Name2;
		
		Nameiqual:
		Console.WriteLine("Porfavor escreva o nome do primeiro jogador: ");
		Name1 = Console.ReadLine();
		
		Console.WriteLine("Ok, agora digite o nome do segundo jogador: ");
		Name2 =Console.ReadLine();
		if(Name1==Name2)
		{
			Console.Clear();
			Console.WriteLine("Os nomes são iguais. isso não pode acontecer.");
			goto Nameiqual;
		}
		Console.Clear();
		Console.WriteLine("{0} e {1}, vamos explicar as regras do jogo agora.\n1° - Os dois jogadores começam com 100$ na carteira.\n2° - Após a segunda rodada os jogadores podem apostar o valor que quiser nos seus dados.\n3° - O valor minimo apostado tem que ser 5$ e sua carteira, DE JEITO ALGUM, DEVE CHEGAR A MENOS QUE 5 REAIS...\n4° - Toda rodada é separada em 3 partes.\nA unica condição de vitoria é tirar todo o dinheiro do outro jogador ou impossibilitar ele de apostar o minimo.", Name1, Name2);
		Console.WriteLine("\nSe entendido, aperte qualquer tecla.");
		Console.ReadKey();
		Console.Clear();
		Thread.Sleep(1000);
		
		
		Console.WriteLine("+++++++++++++++++++ MAS COMO FUNCIONA O JOGO +++++++++++++++++++\n A primeira é rolado um dado de 10 lados e não é mostrado aos jogadores.\n  A segunda, é rolado um dado de 6 números e é mostrado ao jogadores com a possiblidade deles apostarem. Cada um pode apostar um valor diverso sendo maior que 5$.\n   E na terceira parte, é rolado um dado de quartro lados e mostrado aos jogadores, Na terceira parte, tambem é dado a oportunidade de apostar pela ultima vez.\n    E por fim é mostrado a soma de todas as partes e o vencedor leva todo o valor da aposta."); 
		Console.WriteLine("\nSe entendido, aperte qualquer tecla.");
		Console.ReadKey();
		Console.Clear();
		Thread.Sleep(1000);

		Game(Name1, Name2);
		
		
	}
	
	static void Game(string Name1, string Name2)
	{
		
		Random Dice = new Random();
		int Fd1,Fd2, DiceOf1, DiceOf2, TotalD1, TotalD2, MidGameTotalD1, MidGameTotalD2;
		int ApostWallet, CurrentWallet1, CurrentWallet2, Wallet1, Wallet2;
		Wallet1 = 100;
		Wallet2 = 100;

			Rodada1:
	
	
	
	
		
		DiceOf1 = Dice.Next(10);
		DiceOf2 = Dice.Next(10);
		if(DiceOf1 == DiceOf2)
		{
			goto Rodada1;
		}
		Fd1 = DiceOf1;
		Fd2 = DiceOf2;
		TotalD1 = DiceOf1;
		TotalD2 = DiceOf2;
		
		Console.WriteLine("Os primeiros dados ja foram rolados");
		Console.WriteLine("\nSe entendido, aperte qualquer tecla.");
		Console.ReadKey();
		Console.Clear();
		Thread.Sleep(500);
		
			Rodada2:
		
		
		DiceOf1 = Dice.Next(6);
		DiceOf2 = Dice.Next(6);
		if(DiceOf1 == DiceOf2)
		{
			goto Rodada2;
		}
		TotalD1 = DiceOf1 + TotalD1;
		TotalD2 = DiceOf2 + TotalD2;
		MidGameTotalD1 = DiceOf1;
		MidGameTotalD2 = DiceOf2;
		
		
	RepeatP2:
		
		
		Console.WriteLine("+++ Começo da Segunda Rodada. +++");
		Console.WriteLine("Os dados da segunda rodadas dos players são:\n{0} tirou {1} nos dados\n{2} tirou {3} nos dados", Name1, DiceOf1, Name2, DiceOf2);
		Console.WriteLine("\nSe entendido, aperte qualquer tecla.");
		Console.ReadKey();
		Console.Clear();
		Console.WriteLine(Name1 + " tirou " + DiceOf1 + "\n" + Name2 + " tirou " + DiceOf2);
		
		
	apostSave:
		
		if(Wallet1 < 5 | Wallet2 < 5)
		{
			Console.Clear();
			Console.WriteLine("Ops, parece que temos um vencedor...");
			Win(Name1, Name2, Wallet1, Wallet2);
		}
		Console.WriteLine("     +=++=+     \nVAMOS AS APOSTAS\n     +=++=+     ");
		Console.WriteLine("{0} o quanto de $ você deseja apostar?", Name1);
		CurrentWallet1 = Int32.Parse(Console.ReadLine());
		if (CurrentWallet1 < 5)
		{
			Console.WriteLine("O valor apostado foi menor que 5$. Reescreva o valor.");
			Console.WriteLine("Se entendeu, aperte qualquer botão.");
			Console.ReadKey();
			Console.Clear();
			Thread.Sleep(500);
			Console.WriteLine(Name1 + " tirou " + DiceOf1 + "\n" + Name2 + " tirou " + DiceOf2);
			goto apostSave;
		}
		Wallet1 = Wallet1 - CurrentWallet1;
		
		
	apostSave2:
		
		
		Console.WriteLine("{0} o quanto de $ você deseja apostar?", Name2);
		CurrentWallet2 = Int32.Parse(Console.ReadLine());
		if (CurrentWallet2 < 5)
		{
			Console.WriteLine("O valor apostado foi menor que 5$. Reescreva o valor.");
			Console.WriteLine("Se entendeu, aperte qualquer botão.");
			Console.ReadKey();
			Console.Clear();
			Thread.Sleep(500);
			Console.WriteLine(Name1 + " tirou " + DiceOf1 + "\n" + Name2 + " tirou " + DiceOf2);
			goto apostSave2;
		}
		Wallet2 = Wallet2 - CurrentWallet2;
		ApostWallet = CurrentWallet1 + CurrentWallet2;
		Console.Clear();
		Console.WriteLine("     +=++=+     \nFIM DAS APOSTAS\n     +=++=+     ");
		Console.WriteLine("\n"+Name1 + " tirou " + DiceOf1 + "\n" + Name2 + " tirou " + DiceOf2);
		Console.WriteLine("\n"+Name1 + " apostou " + CurrentWallet1 + "$\n" + Name2 + " apostou " + CurrentWallet2+"$");
		CurrentWallet1 = 0;
		CurrentWallet2 = 0;
		
			Rodada3:
		DiceOf1 = Dice.Next(4);
		DiceOf2 = Dice.Next(4);
		if(DiceOf1 == DiceOf2)
		{
			goto Rodada3;
		}
		TotalD1 = DiceOf1 + TotalD1;
		TotalD2 = DiceOf2 + TotalD2;
		MidGameTotalD1 = DiceOf1 + MidGameTotalD1;
		MidGameTotalD2 = DiceOf2 + MidGameTotalD2;
		
	
	RepeatP3:
	
	
		Console.WriteLine("+++ Começo da terceira Rodada. +++");
		Console.WriteLine("Os dados da teceira rodadas dos players são:\n{0} tirou {1} nos dados\n{2} tirou {3} nos dados", Name1, DiceOf1, Name2, DiceOf2);
		Console.WriteLine("\nSe entendido, aperte qualquer tecla.");
		Console.ReadKey();
		Console.Clear();
		Console.WriteLine(Name1 + " tirou " + DiceOf1 + "\n" + Name2 + " tirou " + DiceOf2);
		Console.WriteLine("Até agora...\n{0} esta com o total de {1} dados\n{2} esta com o total de {3} dados", Name1, MidGameTotalD1,Name2,MidGameTotalD2);
		
	apostSaveP3:
		
		
		
		if(Wallet1 < 5 | Wallet2 < 5)
		{
			Console.Clear();
			Console.WriteLine("Ops, parece que temos um vencedor...");
			Win(Name1, Name2, Wallet1, Wallet2);
		}
		Console.WriteLine("     +=++=+     \nVAMOS AS APOSTAS\n     +=++=+     ");
		Console.WriteLine("{0} você tem {1} na carteira.\no quanto de $ você deseja apostar?", Name1,Wallet1);
		CurrentWallet1 = Int32.Parse(Console.ReadLine());
		if (CurrentWallet1 < 5)
		{
			Console.WriteLine("O valor apostado foi menor que 5$. Reescreva o valor.");
			Console.WriteLine("Se entendeu, aperte qualquer botão.");
			Console.ReadKey();
			Console.Clear();
			Thread.Sleep(500);
			Console.WriteLine(Name1 + " tirou " + DiceOf1 + "\n" + Name2 + " tirou " + DiceOf2);
			goto apostSaveP3;
		}
		Wallet1 = Wallet1 - CurrentWallet1;
		
	ApostSave2P3:

		Console.WriteLine("{0} você tem {1} na carteira.\no quanto de $ você deseja apostar?", Name2,Wallet2);
		CurrentWallet2 = Int32.Parse(Console.ReadLine());
		if (CurrentWallet2 < 5)
		{
			Console.WriteLine("O valor apostado foi menor que 5$. Reescreva o valor.");
			Console.WriteLine("Se entendeu, aperte qualquer botão.");
			Console.ReadKey();
			Console.Clear();
			Thread.Sleep(500);
			Console.WriteLine(Name1 + " tirou " + DiceOf1 + "\n" + Name2 + " tirou " + DiceOf2);
			goto ApostSave2P3;
		}
		Wallet2 = Wallet2 - CurrentWallet2;
		ApostWallet = CurrentWallet1 + CurrentWallet2;
		Console.Clear();
		Console.WriteLine("     +=++=+     \nFIM DAS APOSTAS\n     +=++=+     ");
		Console.WriteLine("\n"+Name1 + " tirou " + DiceOf1 + "\n" + Name2 + " tirou " + DiceOf2);
		Console.WriteLine("\n"+Name1 + " apostou " + CurrentWallet1 + "$\n" + Name2 + " apostou " + CurrentWallet2+"$");
		CurrentWallet1 = 0;
		CurrentWallet2 = 0;
		
		Console.WriteLine("Se entendeu, aperte qualquer botão.");
		Console.ReadKey();
		Console.Clear();
		Thread.Sleep(600);

		Console.WriteLine("Por fim, o vencedor da aposta recebera {0}$...", ApostWallet);
		
		Console.WriteLine("Vocês estão prontos para ver o resultado? Se sim aperte qualquer botão.");
		Console.ReadKey();
		Console.Clear();
		Thread.Sleep(550);
		Console.WriteLine(". ");
		Thread.Sleep(650);
		Console.WriteLine(". ");
		Thread.Sleep(750);
		Console.WriteLine(". ");
		Thread.Sleep(1000);
		

		Console.WriteLine("Os primeiros dados rolados foram: \n{0} tirou {1}\n{2} tirou {3}\n....", Name1, Fd1, Name2, Fd2);
		Console.WriteLine("\nAssim os número total de dados de cada jogador foi:\n{0} tem o total de {1} pontos de dados.\n{2} tem o total de {3} pontos de dados.", Name1, TotalD1, Name2, TotalD2);

	SistemaDeVitoriaDaRodada:

		if (TotalD1 > TotalD2)
			{

			Console.WriteLine("     +=++=+     \nO VENCEDOR DA RODADA É {0}\n     +=++=+     ", Name1);
			Wallet1 = Wallet1 + ApostWallet;
			ApostWallet = 0;
			CurrentWallet1 = 0;
			CurrentWallet2 = 0;
			if(Wallet1 < 5 | Wallet2 < 5)
		{
			Console.Clear();
			Console.WriteLine("Ops, parece que temos um vencedor...");
			Win(Name1,  Name2,  Wallet1, Wallet2);
		}
			Console.WriteLine("Bom, agora vamos continuar com a partida. aperte qualquer tecla para continuar");
			Console.ReadKey();
			Console.Clear();
			goto Rodada1;

			}		
		else
			{

			Console.WriteLine("     +=++=+     \nO VENCEDOR DA RODADA É {0}\n     +=++=+     ", Name2);
			Wallet2 = Wallet2 + ApostWallet;
			ApostWallet = 0;
			CurrentWallet1 = 0;
			CurrentWallet2 = 0;
			if(Wallet1 < 5 | Wallet2 < 5)
			{
			Console.Clear();
			Console.WriteLine("Ops, parece que temos um vencedor...");
			Win( Name1,  Name2, Wallet1,  Wallet2);
			}
			Console.WriteLine("Bom, agora vamos continuar com a partida. aperte qualquer tecla para continuar");
			Console.ReadKey();
			Console.Clear();
			goto Rodada1;

			}	
			
			
			
			
	}
	
	
	static void Win(string Name1, string Name2, int Wallet1, int Wallet2)
	{
		if (Wallet1 < Wallet2)
		{
			Console.WriteLine("O {0} esta com {1}$ na carteira, logo ele esta impossibilitado de apostar.\nIsso significa que...", Name1, Wallet1);
			Thread.Sleep(550);
				Console.WriteLine(". ");
					Thread.Sleep(650);
				Console.WriteLine(". ");
					Thread.Sleep(750);
				Console.WriteLine(". ");
					Thread.Sleep(1000);
			Console.WriteLine("| !   {0}   ! |\n É O GRANDE GANHADOR...", Name2);
			Console.WriteLine("\n\nEnfim, o jogo acabou. Clique em qualquer butão para ver os créditos");
			Console.ReadKey();
			Console.Clear();
			Credits();
			
		}	
		else
		{
			Console.WriteLine("O {0} esta com {1}$ na carteira, logo ele esta impossibilitado de apostar.\nIsso significa que...", Name2, Wallet2);
			Thread.Sleep(550);
				Console.WriteLine(". ");
					Thread.Sleep(650);
				Console.WriteLine(". ");
					Thread.Sleep(750);
				Console.WriteLine(". ");
					Thread.Sleep(1000);
			Console.WriteLine("| !   {0}   ! |\n É O GRANDE GANHADOR...", Name1);
			Console.WriteLine("\n\nEnfim, o jogo acabou. Clique em qualquer butão para ver os créditos");
			Console.ReadKey();
			Console.Clear();
			Credits();
		}
		
		
	}
	static void Credits()
	{
		Console.WriteLine("\n\n\n\n______________________\nThanks for Atencion!!!\n\n...\nMade by Arthur Augusto.\n...\n\n\nPress any key...");
		Console.ReadKey();
		Environment.Exit(0);
	}
				//Arthur do futuro, o jogo ta mt bom, falta ainda implantar o sistema de vitoriaa geral, if Carteira menor q 10 reais derrota na hora, enfim, tambem tava pensando em mudar o limite da carteira pra 5, e etc. boa sorte, acaba com isso pfv.	
}