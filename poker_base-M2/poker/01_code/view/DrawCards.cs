using System;
using System.Collections.Generic;
using poker.code.model;

namespace poker.code.view
{
	/*
	Class to draw cards elegant cards in terminal.
	*/
	class DrawCards
	{
		/*
		DrawCards cards outlines (edges)
		*/
		private static void DrawCardOutline(int xcoor, int ycoor)
		{
			Console.ForegroundColor = ConsoleColor.White;
			
			int x = xcoor * 12;
			int y = ycoor;
			
			Console.SetCursorPosition(x, y);
			Console.Write(" __________\n"); //top edge of the card
			
			for (int i = 0; i < 7; i++)
			{
				Console.SetCursorPosition(x,y + 1 + i);
				
				if ( i != 6)
					Console.WriteLine("|          |");//left and right edges of the cards
				else
					Console.WriteLine("|__________|");//bottom edge of the card
			}
		}
		
		/*
		Display suit and value of the card inside its outline.
		*/		
		public static void DrawCardSuitValue(Card card, int xcoor, int ycoor)
		{
			//char cardSuit = ' ';
			string cardSuit = "";
			int x = xcoor * 12;
			int y = ycoor;

			//hearts and diamonds are red, clubs and spades are black
			switch(parse_suite(card.suit_.ToString()))
			{
				case 1://Card.SUIT.Hearts:
					cardSuit = "\u2665"; //'♥'
					//cardSuit = 'H';
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case 2://Card.SUIT.Diamonds:
					cardSuit = "\u25C6"; //'♦';
					//cardSuit = 'D';
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case 3://Card.SUIT.Clubs:
					cardSuit = "\u2663";//'♣';
					//cardSuit = 'D';
					Console.ForegroundColor = ConsoleColor.White;
					break;
				case 4://Card.SUIT.Spades:
					cardSuit = "\u2660";//'♠';
					//cardSuit = 'S';
					Console.ForegroundColor = ConsoleColor.White;
					break;
			}

			//display the encoded character and value of the card
			Console.SetCursorPosition(x + 3, y + 2);
			string simbol_ = "";
			
			if(parse_value(card, ref simbol_))
				Console.Write(simbol_);
			else
				Console.WriteLine(card.get_value());
			
			Console.SetCursorPosition(x + 3, y + 3);
			Console.Write(cardSuit);			
		}

		private static int parse_suite(string suite)
		{// parse enum rank to numerical value
			if (suite == "Hearts")
				return 1;
			else if (suite == "Diamonds")
				return 2;
			else if (suite == "Clubs")
				return 3;
			else if (suite == "Spades")
				return 4;
			return 0;
		}

		private static bool parse_value(Card c, ref string simbol)
		{ // parse especial values: J(11) | Q(12) | K(13) | A(1 ou 14)
			bool check = false;
			if (c.get_value() >= 11 && c.get_value() <= 14)
			{
				check = true;
				switch(c.get_value())
				{
					case 11:
						simbol = "J";
						break;
					case 12:
						simbol = "Q";
						break;
					case 13: 
						simbol = "K";
						break;
					case 14: 
						simbol = "A";
						break;
				}
			}
			//else if (c.get_value() == 14)
			//{
			//	simbol = "A";
		//		check = true;
		//	}

			return check;
		}

		public static void display_cards (List<Card> list, int x_, int y_)
		{
			//Console.Clear();
			int x = x_;//0; //x position of the cursor
			int y = y_;//1; //y position of the cursor
			//UnicodeEncoding enc = new UnicodeEncoding(true, false, false);
			Console.OutputEncoding = System.Text.Encoding.UTF8; 
			
			//display player hand
			Console.ForegroundColor = ConsoleColor.White;
			//Console.WriteLine("PLAYER'S HAND");
			for (int i = 0; i < list.Count; i++)
			{
				DrawCards.DrawCardOutline(x, y);
				DrawCards.DrawCardSuitValue(list[i], x, y);
				x++; //move to the right
			}
			
			y = 10; //move the row of computer cards below the players cards
			x = 0; //reset x position
			Console.SetCursorPosition(x, y);
			Console.ForegroundColor = ConsoleColor.White;

			//display computer hand
			/*Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(x, 10);
			Console.WriteLine("COMPUTER'S HAND");
			for (int i = 5; i < 10; i++)
			{
				DrawCards.DrawCardOutline(x, y);
				DrawCards.DrawCardSuitValue(sortedComputerHand[i -5], x, y);
				x++; //move to the right
			}*/
		}
	}
}
