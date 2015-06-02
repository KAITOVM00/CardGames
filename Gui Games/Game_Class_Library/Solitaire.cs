using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Game_Class_Library;

namespace Game_Class_Library
{
    /// <summary>
    /// Contains the Solitaire Class to be used in conjunction with the
    /// solitaire form with playing the game. Contains all the methods and
    /// variables needed.
    /// </summary>
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
        static List<Hand> playHands = new List<Hand>();
        static int[] playRevealed = new int[numOfPlayerPiles];
        
        //Chosen index of playHands, to be changed when player clicks a Hand
        //-1 indicates that it's currently not selected
        static int moveFromNotSet = -1;
        static int moveFrom = moveFromNotSet;
        /// <summary>
        /// Sets up the solitare game from beginning 
        /// </summary>
        public static void SetupGame()
        {
            deck = new CardPile(true);
            for (int i = 0; i < numOfPlayerPiles; i++)
            {
                playRevealed[i] = i;
                playHands[i] = new Hand(deck.DealCards(i+1));
            }
            current.AddCard(deck.DealOneCard());
        }
        public static int[] GetRevealed()
        {
            return playRevealed;
        }
        /// <summary>
        /// Returns a play pile corresponding to the 'Hand' of one of the 
        /// seven lines of cards
        /// </summary>
        /// <param name="index">Pre: index between 0 and 6</param>
        /// <returns>Hand: Returns the hand of corresponding index</returns>
        public static Hand GetPlayHands(int index)
        {
            return playHands[index];
        }

        /// <summary>
        /// Returns all the play Hands for the corresponding windows form
        /// </summary>
        /// <returns>List[hand]: List of All Hands</returns>
        public static List<Hand> GetAllPlayHands()
        {
            return playHands;
        }

        /// <summary>
        /// Selector function for moving cards around on the game form, 
        /// taking two inputs, the index of the Hand list, and the index
        /// of which card and cards below that card to move
        /// </summary>
        /// <param name="moveTo">Pre: integer between 0 and 6</param>
        /// <param name="cardIndex">Pre: integer between 0 and 12</param>
        /// <returns></returns>
        public static bool AddHandToHand(int move, int cardIndex)
        {
            if (moveFrom == moveFromNotSet)
            {
                moveFrom = move;
                return true;
            }
            if (moveFrom != moveFromNotSet)
            {

            }
            return false;
        }

        /// <summary>
        /// Checks if two hands can be moved on top of each other
        /// </summary>
        /// <param name="handFrom">Pre: Instantiated Hand with Cards >0</param>
        /// <param name="handTo">Pre: Instantiated Hand with Cards >0</param>
        /// <returns>Bool: Returns true if possible to move Cards, false otherwise</returns>
        private static bool CheckPossibleMove(Hand handFrom, Hand handTo)
        {
            int toTotal = handTo.GetCount();
            int fromTotal = handFrom.GetCount();
            int noCards = 0;
            int firstCard = 0;
            if (CheckHandCanBeMoved(handFrom))
            {
                if (toTotal == noCards) //IE if the move to Hand has no cards in it
                {
                    if (handFrom.GetCard(firstCard).GetFaceValue() == FaceValue.King)
                    {
                        return true;
                    }
                }
                if (toTotal + fromTotal > maxCards) //greater than possible hand size
                {
                    return false;
                }
                Hand totalHand = AddHands(handFrom, handTo);
                if (CheckHandCanBeMoved(totalHand))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds two hands together, without affecting the current play
        /// </summary>
        /// <param name="handFrom">Pre: Must be an instantiated hand</param>
        /// <param name="handTo">Pre: Must be an instantiated hand</param>
        /// <returns>Hand: Returns the two hands added together</returns>
        private static Hand AddHands(Hand handFrom, Hand handTo)
        {
            int fromLength = handFrom.GetCount();
            for (int i = 0; i < fromLength;i++)
            {
                handTo.AddCard(handFrom.GetCard(i));
            }
            return handTo;
        }

        /// <summary>
        /// Checks if a given hand can be moved, finding if each card in the
        /// hand is an alternate colour, and is one less in value than the 
        /// one above
        /// </summary>
        /// <param name="hand">Pre: Must be an instantiated Hand</param>
        /// <returns>Bool: True if it can be moved, false otherwise</returns>
        private static bool CheckHandCanBeMoved(Hand hand)
        {
            int handLength = hand.GetCount();
            int cardIncrement = 1;
            for (int i = 1; i < handLength; i++)
            {
                Colour prevColour = hand.GetCard(i - 1).GetColour();
                Colour currentColour = hand.GetCard(i).GetColour();
                FaceValue prevFace = hand.GetCard(i - 1).GetFaceValue();
                FaceValue currentFace = hand.GetCard(i).GetFaceValue();
                if (prevColour != currentColour)
                {
                    return false;
                }
                if(((int)prevFace - (int)currentFace) != cardIncrement)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
