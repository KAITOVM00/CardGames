using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Shared_Game_Class_Library
{
    public enum Suit { Clubs, Diamonds, Hearts, Spades }
    public enum FaceValue { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    public enum Colour { Black, Red }
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        private FaceValue faceValue;
        private Suit suit;
        private Colour colour;
        public Card()
        {

        }
        public Card(FaceValue face_value, Suit suit_value)
        {
            faceValue = face_value;
            suit = suit_value;
        }
        public Card(FaceValue face_value, Suit suit_value, Colour colour_value)
        {
            faceValue = face_value;
            suit = suit_value;
            colour = colour_value;
        }
        public FaceValue GetFaceValue()
        {
            return faceValue;
        }
        public Suit GetSuit()
        {
            return suit;
        }
        public Colour GetColour()
        {
            return colour;
        }
        public bool Equals(Card comp)
        {
            if ((this.suit == comp.suit) && (this.faceValue == comp.faceValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CompareTo(Card comp)
        {
            if (this.suit < comp.suit)
            {
                return -1;
            }
            else if (this.suit > comp.suit)
            {
                return 1;
            }
            else
            {
                if (this.faceValue < comp.faceValue)
                {
                    return -1;
                }
                else if (this.faceValue > comp.faceValue)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    public class Hand : IEnumerable
    {
        private List<Card> cards = new List<Card>();

        public Hand()
        {

        }
        public Hand(List<Card> new_hand)
        {
            cards = new_hand;
        }
        public int GetCount()
        {
            return cards.Count;
        }
        public Card GetCard(int index)
        {
            return cards[index];
        }
        public void AddCard(Card addCard)
        {
            cards.Add(addCard);
        }
        public bool ContainsCard(Card comp)
        {
            foreach (Card card in cards)
            {
                if (comp.Equals(card))
                {
                    return true;
                }
            }
            return false;
        }
        public void RemoveCard(Card comp)
        {
            cards.Remove(comp);
        }
        public void RemoveCardAt(int index)
        {
            cards.RemoveAt(index);
        }
        public void SortHand()
        {
            cards.Sort(); //probably wrong
        }
        public IEnumerator GetEnumerator()
        {
            return cards.GetEnumerator();
        }
    }

    public class CardPile
    {
        private List<Card> pile = new List<Card>();
        public static int NUM_SUITS = 4;
        public static int NUM_CARDS_PER_SUIT = 13;
        Random random = new Random();
        public CardPile()
        {

        }
        public CardPile(bool full)
        {
            if (full)
            {
                foreach (Suit i in Enum.GetValues(typeof(Suit)))
                {
                    foreach (FaceValue j in Enum.GetValues(typeof(FaceValue)))
                    {
                        pile.Add(new Card(j, i));
                    }
                }
            }
        }//end CardPile
        public void AddCard(Card card)
        {
            pile.Add(card);
        }
        public int GetCount()
        {
            return pile.Count;
        }
        public Card GetLastCardInPile()
        {
            int topDeck = pile.Count();
            return pile[topDeck - 1];
        }
        public void RemoveLastCard()
        {
            int topDeck = pile.Count();
            pile.RemoveAt(topDeck - 1);
        }
        public void ShufflePile()
        {
            for (int i = pile.Count - 1; i > 0; i--) //fisher-yates shuffle
            {
                int k = random.Next(0, i + 1);
                Card temp = pile[i];
                pile[i] = pile[k];
                pile[k] = temp;
            }
        }
        public Card DealOneCard()
        {
            Card card = GetLastCardInPile();
            RemoveLastCard();
            return card;
        }
        public List<Card> DealCards(int num)
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < num; i++)
            {
                cards.Add(DealOneCard());
            }
            return cards;
        }
    }
}
