using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Game_Class_Library;

namespace Game_Class_Library
{
    public static class Solitaire
    {
        static CardPile deck; //to hold the draw deck
        static CardPile current; //to hold the discard deck
        //Suit piles for win condition
        static Card SuitPile1;
        static Card SuitPile2;
        static Card SuitPile3;
        static Card SuitPile4;

        //Play piles and currently revealed card in associated pile
        static int maxCards = 13;
        static int numOfPlayerPiles = 7;
        static List<Hand> playPiles = new List<Hand>();
        static int[] playRevealed = new int[numOfPlayerPiles];

        /// <summary>
        /// Sets up the solitare game from beginning 
        /// </summary>
        public static void SetupGame()
        {
            deck = new CardPile(true);
            for (int i = 0; i < numOfPlayerPiles; i++)
            {
                playRevealed[i] = i;
                playPiles[i] = new Hand(deck.DealCards(i+1));
            }
        }
        public static int[] GetRevealed()
        {
            return playRevealed;
        }
    }
}
