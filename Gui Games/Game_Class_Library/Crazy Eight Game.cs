using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Game_Class_Library;

namespace Game_Class_Library
{

    public static class Crazy_Eights_Game
    {
        static CardPile deck;
        static CardPile discard;
        static Hand playerHand;
        static Hand compHand;
        static Card LegalMove;
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
        public static void RemoveCardComputer(int index)
        {
            compHand.RemoveCardAt(index);
        }
        public static void AddDiscard(Card card)
        {
            discard.AddCard(card);
        }
        public static bool CheckLegalMove(Card card)
        {
            if (card.GetSuit() == LegalMove.GetSuit())
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
            
        }
        private static bool CheckTieGame()
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
