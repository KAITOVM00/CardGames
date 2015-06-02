using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Game_Class_Library;
using System.Threading;

namespace Game_Class_Library
{

    public static class Crazy_Eights_Game
    {
        static CardPile deck;
        static CardPile discard;
        static Hand playerHand;
        static Hand compHand;
        static Card LegalMove;

        const int CLUBS = 3;
        const int HEARTS = 1;
        const int DIAMONDS = 2;
        const int SPADES = 0;

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
        public static Card GetTopOfDiscard()
        {
            return discard.GetLastCardInPile();
        }
        public static void SortPlayerHand()
        {
            playerHand.SortHand();
        }
        public static CardPile GetDeck()
        {
            return deck;
        }
        public static CardPile GetDiscard()
        {
            return discard;
        }
        public static Hand GetPlayerHand()
        {
            return playerHand;
        }
        public static void RemoveCardPlayer(Card card)
        {
            playerHand.RemoveCard(card);
        }
        public static void RemoveCardComputer(Card card)
        {
            compHand.RemoveCard(card);
        }
        public static void AddDiscard(Card card)
        {
            discard.AddCard(card);
        }
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
        public static int WhichCard(Card card)
        {
            int count = 0;
            foreach (Card i in playerHand)
            {
                if (card.Equals(i))
                {
                    return count;
                }
                count++;
            }
            return -1;
        }
        public static Hand GetComputerHand()
        {
            return compHand;
        }
        public static Card GetCurrentCard()
        {
            return discard.GetLastCardInPile();
        }
        public static void DealInitial()
        {
            List<Card> hand1 = deck.DealCards(8);
            List<Card> hand2 = deck.DealCards(8);
            discard.AddCard(deck.DealOneCard());
            playerHand = new Hand(hand1);
            compHand = new Hand(hand2);
        }
        public static void ComputerTurn()
        {
            int msDelay = 1000;
            Thread.Sleep(msDelay);
            bool draw = LegalCompTurn();
            if (draw)
            {
                compHand.AddCard(deck.DealOneCard());
            }
            else
            {
                Card card = BestCompCard();
                CompCardToDiscard(card);
            }
        }
        /// <summary>
        /// BestCompCard finds the best card for a computer to play, prioritzing facevalue first
        /// suit second, and then finally any 8's the computer might have
        /// </summary>
        /// <returns>Card: Returns the best card for the computer to play</returns>
        private static Card BestCompCard()
        {
            Card card;
            Card topOfPile = discard.GetLastCardInPile();
            for (int i = 0; i < compHand.GetCount(); i++)
            {
                card = compHand.GetCard(i);
                bool sameFace = card.GetFaceValue() == topOfPile.GetFaceValue();
                bool notEight = card.GetFaceValue() != FaceValue.Eight;
                if (sameFace && notEight)
                {
                    return card;
                }
            }
            for (int i = 0; i < compHand.GetCount(); i++)
            {
                card = compHand.GetCard(i);
                bool sameSuit = card.GetSuit() == topOfPile.GetSuit();
                bool notEight = card.GetFaceValue() != FaceValue.Eight;
                if (sameSuit && notEight)
                {
                    return card;
                }
            }
            for (int i = 0; i < compHand.GetCount(); i++)
            {
                card = compHand.GetCard(i);
                bool isEight = card.GetFaceValue() == FaceValue.Eight;
                if (isEight)
                {
                    return card;
                }
            }
            return new Card();
        }
        /// <summary>
        /// LegalCompTurn checks if it is possible for the computer to play a 
        /// card from it's hand.
        /// </summary>
        /// <returns>Bool: Returns true if not possible to play, false if otherwise</returns>
        private static bool LegalCompTurn()
        {
            for (int i = 0; i < compHand.GetCount(); i++)
            {
                if(CheckLegalMove(compHand.GetCard(i)))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// AddFromDeck checks if there is a legal move to be made from the player, and then
        /// if no move is found, it adds a card from the deck.
        /// </summary>
        /// <returns>Bool: True if no legal move was found and a card is added, false otherwise</returns>
        public static bool AddFromDeck()
        {
            bool check = false;
            for (int i = 0;i<playerHand.GetCount();i++)
            {
                if(CheckLegalMove(playerHand.GetCard(i)))
                {
                    check = true;
                }
            }
            if (!check)
            {
                playerHand.AddCard(deck.DealOneCard());
                return true;
            }
            return false;
        }
        public static bool CheckTieGame()
        {
            return false;
        }
        private static void CompCardToDiscard(Card card)
        {
            discard.AddCard(card);
            compHand.RemoveCard(card);
        }
        public static void SetLegalMove(Card card)
        {
            LegalMove = card;
        }
        public static bool PlayerTurn(Card card)
        {
            bool check = CheckLegalMove(card);
            if (check)
            {
                AddDiscard(card);
                SetLegalMove(card);
                RemoveCardPlayer(card);
                return true;
            }
            return false;
        }
        public static bool PlayerTurn(Card card, Card newSuit)
        {
            bool check = CheckLegalMove(card);
            if (check)
            {
                AddDiscard(card);
                SetLegalMove(newSuit);
                RemoveCardPlayer(card);
                return true;
            }
            return false;
        }
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
