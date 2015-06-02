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
        static CardPile current = new CardPile(); //to hold the discard deck
        
        //Suit piles for win condition
        static Card SuitPile1;
        static Card SuitPile2;
        static Card SuitPile3;
        static Card SuitPile4;

        //Play piles and currently revealed card in associated pile
        static int maxCards = 15;
        static int numOfHands = 7;
        static List<Hand> playHands = new List<Hand>();
        static int[] playRevealed = new int[numOfHands];
        
        //Chosen index of playHands, to be changed when player clicks a Hand
        //-1 indicates that it's currently not selected
        static int moveFromNotSet = -1;
        static int moveFrom = moveFromNotSet;

        static Card selected = new Card();
        /// <summary>
        /// Sets up the solitare game from beginning 
        /// </summary>
        public static void SetupGame()
        {
            deck = new CardPile(true);
            deck.ShufflePile();
            for (int i = 0; i < numOfHands; i++)
            {
                playRevealed[i] = i;
                Hand temp = new Hand(deck.DealCards(i + 1));
                playHands.Add(temp);
            }
            current.AddCard(deck.DealOneCard());
        }

        /// <summary>
        /// Sets the currently selected Card, if a card is already selected
        /// then it means you want to move the card, so checks and moves the
        /// hand from pile to pile
        /// </summary>
        /// <param name="card">Pre: Must be an instantiated Card</param>
        /// <returns>Bool: Returns true if a card was </returns>
        public static bool SetSelected(Card card)
        {
            if (selected == null)
            {
                selected = card;
                return false;
            }
            else if (selected != null)
            {
                int error = -1;
                //find new position and run check
                int[] currentPos = GetSelectedPosition(selected);
                if(currentPos[0] == error )
                {
                    return false;
                }
                int pHIndex1 = currentPos[0]; //play hand index
                int cPIndex1 = currentPos[1]; //card play index
                Hand moveFrom = GenerateHand(pHIndex1, cPIndex1);
                if (CheckHandCanBeMoved(moveFrom))
                {
                    currentPos = GetSelectedPosition(card);
                    int pHIndex2 = currentPos[0];
                    int cPIndex2 = currentPos[1];
                    Hand moveTo = GenerateHand(pHIndex2,cPIndex2);
                    if(CheckPossibleMove(moveFrom,moveTo))
                    {
                        AddHandToHand(moveTo, moveFrom);
                        RemoveHand(pHIndex1, cPIndex1);
                    }
                }

                selected = new Card(); // reset the selected Card
                return true;
            }
            return false;
        }


        /// <summary>
        /// Generates a hand from the piles, pile pHIndex and card cPIndex 
        /// till the end of the pile
        /// </summary>
        /// <param name="pHIndex">Pre: Int >= 0</param>
        /// <param name="cPIndex">Pre: Int >= 0</param>
        /// <returns>Hand: Returns the generated hand from given pile 
        /// and card index</returns>
        private static Hand GenerateHand(int pHIndex, int cPIndex)
        {
            Hand hand = new Hand();
            int max = playHands[pHIndex].GetCount();
            for (int i = cPIndex; i < max; i++)
            {
                hand.AddCard(playHands[pHIndex].GetCard(i));
            }
            return hand;
        }
        
        /// <summary>
        /// Removes a set of cards from a generated pile, pile pHindex, card
        /// cPIndex onwards
        /// </summary>
        /// <param name="pHIndex">Pre: Int >= 0</param>
        /// <param name="cPIndex">Pre: Int >= 0</param>
        private static void RemoveHand(int pHIndex, int cPIndex)
        {
            Hand hand = new Hand();
            int max = playHands[pHIndex].GetCount();
            for (int i = cPIndex; i < max; i++)
            {
                playHands[pHIndex].RemoveCardAt(i);
            }
        }

        /// <summary>
        /// Gets the position of the currently selected card
        /// </summary>
        /// <returns>Int[]: returns [i,j], where i is the index of player
        /// hand, j is the selected card index inside that hand. Returns 
        /// [-1,-1] if could not be found</returns>
        public static int[] GetSelectedPosition(Card card)
        {
            int[] position = new int[2];
            for (int i = 0; i < numOfHands; i++)
            {
                for (int j = 0; j < maxCards; j++)
                {
                    if (card.Equals(playHands[i].GetCard(j)))
                    {
                        position[0] = i;
                        position[1] = j;
                        return position;
                    }
                }
            }
            position[0] = -1;
            position[1] = -1;
            return position;
        }

        public static CardPile GetCurrent()
        {
            return current;
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
        public static Hand GetPlayHand(int index)
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
        /// Adds the cards from one hand to another hand in the play board
        /// </summary>
        /// <param name="handTo">Pre: Must be an instantiated hand taken from
        /// the play board</param>
        /// <param name="handFrom">Pre: Must be an instantiated hand taken from
        /// the play board</param>
        public static void AddHandToHand(Hand handTo, Hand handFrom)
        {
            int[] toPos = GetSelectedPosition(handTo.GetCard(0));
            int[] fromPos = GetSelectedPosition(handFrom.GetCard(0));
            for (int i = toPos[1]; i < playHands[fromPos[0]].GetCount(); i++)
            {
                playHands[toPos[0]].AddCard(playHands[fromPos[0]].GetCard(i));
            }
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
