using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Game_Class_Library;
using System.Threading;

namespace Game_Class_Library
{
    /// <summary>
    /// Contains the class, all the variables and methods used for the
    /// playing of the Crazy Eights Game in conjunction with the 
    /// Crazy Eights Form CEForm
    /// 
    /// Authors: Nathan Perkins
    /// Date: 01/06/2015
    /// </summary>
    public static class Crazy_Eights_Game
    {
        static CardPile deck; //to hold the draw deck
        static CardPile discard; //to hold the discard deck
        static Hand playerHand; //holds the players hand
        static Hand compHand; //holds the computers hand
        static Card LegalMove; //holds the current legal move, a phantom card that can be changed with wild cards
        static int maxHandSize = 13; //maximum hand size

        /// <summary>
        /// Sets up the game from the starting point, 8 cards per player,
        /// and a card added to the discard deck
        /// </summary>
        public static void SetupGame()
        {
            deck = new CardPile(true);
            deck.ShufflePile();
            discard = new CardPile();
            discard.AddCard(deck.DealOneCard());
            int startHand = 8;
            playerHand = new Hand(deck.DealCards(startHand));
            compHand = new Hand(deck.DealCards(startHand));
            LegalMove = discard.GetLastCardInPile();
        }

        /// <summary>
        /// Swaps the deck and discard if the deck has run out of cards, then
        /// places the last card from the discard pile back onto the discard deck
        /// </summary>
        public static void DeckDiscardSwap()
        {
            if (deck.GetCount() == 0)
            {
                deck = discard;
                deck.RemoveLastCard();
                Card card = discard.GetLastCardInPile();
                discard = new CardPile();
                discard.AddCard(card);
            }
        }

        /// <summary>
        /// Get's the top of the discard Deck
        /// </summary>
        /// <returns>Card: Returns the top of the discard deck</returns>
        public static Card GetTopOfDiscard()
        {
            return discard.GetLastCardInPile();
        }

        /// <summary>
        /// Sorts the players hand in the order specifed by the Card class
        /// </summary>
        public static void SortPlayerHand()
        {
            playerHand.SortHand();
        }

        /// <summary>
        /// Gets the deck pile for drawing
        /// </summary>
        /// <returns>CardPile: Returns the deck card pile</returns>
        public static CardPile GetDeck()
        {
            return deck;
        }

        /// <summary>
        /// Gets the discard pile for playing 
        /// </summary>
        /// <returns>CardPile: Returns the discard card pile</returns>
        public static CardPile GetDiscard()
        {
            return discard;
        }

        /// <summary>
        /// Gets the players hand
        /// </summary>
        /// <returns>Hand: Returns the players hand</returns>
        public static Hand GetPlayerHand()
        {
            return playerHand;
        }


        /// <summary>
        /// Checks a given card and determines if it's a legal move
        /// </summary>
        /// <param name="card">Pre: Must be an instantiated Card</param>
        /// <returns>Bool: Returns true if it is a legal move, false otherwise</returns>
        public static bool CheckLegalMove(Card card)
        {
            if (card.GetFaceValue() == FaceValue.Eight)
            {
                return true;
            }
            else if (card.GetSuit() == LegalMove.GetSuit())
            {
                return true;
            }
            else if (card.GetFaceValue() == LegalMove.GetFaceValue())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Instantiates all the games variables, used in the setup function. Sets hands, deck and discard
        /// </summary>
        private static void DealInitial()
        {
            List<Card> hand1 = deck.DealCards(8);
            List<Card> hand2 = deck.DealCards(8);
            discard.AddCard(deck.DealOneCard());
            playerHand = new Hand(hand1);
            compHand = new Hand(hand2);
            SetLegalMove(discard.GetLastCardInPile());
        }

        /// <summary>
        /// Takes the computers turn
        /// </summary>
        public static void ComputerTurn()
        {
            bool playSuccess = BestCompCard();
            if (!playSuccess)
            {
                compHand.AddCard(deck.DealOneCard());
                DeckDiscardSwap();
            }

        }

        /// <summary>
        /// BestCompCard finds the best card for a computer to play, prioritzing facevalue first
        /// suit second, and then finally any 8's the computer might have
        /// </summary>
        /// <returns>Bool: Returns true if a card was added to the discard from computers hand
        /// returns false if no card could be added</returns>
        private static bool BestCompCard()
        {
            int maxIndex = compHand.GetCount();
            for (int i = 0; i < maxIndex; i++)
            {
                Card comp = compHand.GetCard(i);
                if (comp.GetFaceValue() == LegalMove.GetFaceValue())
                {
                    CompPlayCard(comp, i);
                    return true;
                }
            }
            for (int i = 0; i < maxIndex; i++)
            {
                Card comp = compHand.GetCard(i);
                if (comp.GetSuit() == LegalMove.GetSuit())
                {
                    CompPlayCard(comp, i);
                    return true;
                }
            }
            for (int i = 0; i < maxIndex; i++)
            {
                Card comp = compHand.GetCard(i);
                if (comp.GetFaceValue() == FaceValue.Eight)
                {
                    CompPlayCard(comp, i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Plays a card for the computers turn
        /// </summary>
        /// <param name="card">Pre: Must be an instantiated card</param>
        private static void CompPlayCard(Card card,int indexLoc)
        {
            discard.AddCard(card);
            compHand.RemoveCardAt(indexLoc);
            SetLegalMove(card);
        }

        /// <summary>
        /// AddFromDeck checks if there is a legal move to be made from the player, and then
        /// if no move is found, it adds a card from the deck.
        /// </summary>
        /// <returns>Bool: True if no legal move was found and a card is added, false otherwise</returns>
        public static bool AddFromDeck()
        {
            bool canPlay = false;
            canPlay = CheckAllLegalMoves(playerHand);
            if (!canPlay)
            {
                playerHand.AddCard(deck.DealOneCard());
                return true;
            }
            return false;
        }
        

        /// <summary>
        /// Checks a given hand for any legal moves
        /// </summary>
        /// <param name="hand">Pre: Must be an instantiated hand</param>
        /// <returns>Bool: True if a move is found, false if otherwise.</returns>
        private static bool CheckAllLegalMoves(Hand hand)
        {
            for (int i = 0; i < playerHand.GetCount(); i++)
            {
                if (CheckLegalMove(playerHand.GetCard(i)))
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Checks if the game is tied.
        /// </summary>
        /// <returns>Bool: Returns true if the game is tied, false otherwise</returns>
        public static bool CheckTie()
        {
            return false;
        }

        /// <summary>
        /// Sets the legal Move for the deck, specified in case for the wild card which can change the suit played
        /// </summary>
        /// <param name="card">Pre: Must be an instantiated card</param>
        public static void SetLegalMove(Card card)
        {
            LegalMove = card;
        }

        /// <summary>
        /// Takes the players turn, based on the card selected from the windows form
        /// </summary>
        /// <param name="card">Pre: Must be an instantiated card currently held in the human players hand</param>
        /// <returns>Bool: True if card was played, false otherwise</returns>
        public static bool PlayerTurn(Card card)
        {
            bool check = CheckLegalMove(card);
            if (check)
            {
                discard.AddCard(card);
                SetLegalMove(card);
                playerHand.RemoveCard(card);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Takes the players turn, based on the card selected from the windows form
        /// </summary>
        /// <param name="card">Pre: Must be an instantiated card currently held in the human players hand</param>
        /// <param name="newSuit">Pre: Must be an instantiated card, contains the new suit to change to</param>
        /// <returns>Bool: True if card was played, false otherwise</returns>
        public static bool PlayerTurn(Card card, Card newSuit)
        {
            bool check = CheckLegalMove(card);
            if (check)
            {
                discard.AddCard(card);
                SetLegalMove(newSuit);
                playerHand.RemoveCard(card);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the selected card is the wild card, 8
        /// </summary>
        /// <param name="card">Pre: Must be an instantiated card</param>
        /// <returns>Bool: True if selected card is a wild card, false otherwise</returns>
        public static bool IsEight(Card card)
        {
            if (card.GetFaceValue() == FaceValue.Eight)
            {
                return true;
            }
            return false;
        }
    }//end class
}
