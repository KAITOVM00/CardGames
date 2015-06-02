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
    /// <summary>
    /// Describes the class used for the modelling of Cards, including all
    /// the variables and methods
    /// </summary>
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        private FaceValue faceValue; //Face value of the card
        private Suit suit; //Suit of the card
        private Colour colour; //Colour of the card

        /// <summary>
        /// Basic Constructor of the Card class
        /// </summary>
        public Card()
        {

        }

        /// <summary>
        /// Creates a Card with the specified face and suit
        /// </summary>
        /// <param name="face_value">Pre: Must be a value within the facevalue Enum</param>
        /// <param name="suit_value">Pre: Must be a value within the suit Enum</param>
        public Card(FaceValue face_value, Suit suit_value)
        {
            faceValue = face_value;
            suit = suit_value;
        }

        /// <summary>
        /// Creates a Card with the specified face and suit and colour
        /// </summary>
        /// <param name="face_value">Pre: Must be a value within the facevalue Enum</param>
        /// <param name="suit_value">Pre: Must be a value within the suit Enum</param>
        /// <param name="colour_value">Pre: Must be a value within the Colour Enum</param>
        public Card(FaceValue face_value, Suit suit_value, Colour colour_value)
        {
            faceValue = face_value;
            suit = suit_value;
            colour = colour_value;
        }

        /// <summary>
        /// Gets the facevalue of the card
        /// </summary>
        /// <returns>Facevalue: returns the facevalue of the card</returns>
        public FaceValue GetFaceValue()
        {
            return faceValue;
        }

        /// <summary>
        /// Gets the Suit of the card
        /// </summary>
        /// <returns>Suit: returns the suit of the card</returns>
        public Suit GetSuit()
        {
            return suit;
        }

        /// <summary>
        /// Gets the colour of the card
        /// </summary>
        /// <returns>Colour: returns the colour of the card</returns>
        public Colour GetColour()
        {
            return colour;
        }

        /// <summary>
        /// Compares the current card with a specified card
        /// </summary>
        /// <param name="comp">Pre: Must be an instantiated card</param>
        /// <returns>Bool: returns true if the facevalue and suit of both
        /// cards are equal, false otherwise</returns>
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

        /// <summary>
        /// Compares the current cards facevalue and suit against a 
        /// specified card, overwriting the system CompareTo method.
        /// Preference is given for Suit first, then face value.
        /// </summary>
        /// <param name="comp">Pre: Must be an instantiated Card</param>
        /// <returns>Int: -1 if lower in priority, 0 if equal, 1 if 
        /// greater in priority</returns>
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

    /// <summary>
    /// Specifies the Hand class for a list of cards
    /// </summary>
    public class Hand : IEnumerable
    {
        private List<Card> cards = new List<Card>(); //List of cards for the hand

        /// <summary>
        /// Basic constructor for the Hand class
        /// </summary>
        public Hand()
        {

        }

        /// <summary>
        /// Constructor for the Hand class, instantiating with a list of cards
        /// </summary>
        /// <param name="new_hand">List[Cards]: Must be an instantiated list of cards</Card></param>
        public Hand(List<Card> new_hand)
        {
            cards = new_hand;
        }

        /// <summary>
        /// Gets the count of the number of cards in the hand list
        /// </summary>
        /// <returns>Int: Returns the number of cards in the hand list</returns>
        public int GetCount()
        {
            return cards.Count;
        }

        /// <summary>
        /// Gets the specified card in the list
        /// </summary>
        /// <param name="index">Pre: >=0 </param>
        /// <returns>Card: Returns the card at specified index</returns>
        public Card GetCard(int index)
        {
            return cards[index];
        }

        /// <summary>
        /// Adds a card to the list
        /// </summary>
        /// <param name="addCard">Pre: Must be an instantiated Card</param>
        public void AddCard(Card addCard)
        {
            cards.Add(addCard);
        }

        /// <summary>
        /// Checks if a specified card is in the Hand
        /// </summary>
        /// <param name="comp">Pre: Must be an instantiated Card</param>
        /// <returns>Bool: Returns true if the card is in the hand
        /// false otherwise</returns>
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

        /// <summary>
        /// Removes a card from the hand
        /// </summary>
        /// <param name="comp">Pre: Must be an instantiated Card contained in Hand</param>
        public void RemoveCard(Card comp)
        {
            cards.Remove(comp);
        }

        /// <summary>
        /// Removes a Card from the hand at a specified index
        /// </summary>
        /// <param name="index">Pre: >=0</param>
        public void RemoveCardAt(int index)
        {
            cards.RemoveAt(index);
        }

        /// <summary>
        /// Sorts the Hand as per the Card.CompareTo Method
        /// </summary>
        public void SortHand()
        {
            cards.Sort();
        }

        /// <summary>
        /// Does some things I Don't need to know about
        /// </summary>
        /// <returns>IEnumerator: Some variable I don't need to
        /// know about</returns>
        public IEnumerator GetEnumerator()
        {
            return cards.GetEnumerator();
        }
    }

    /// <summary>
    /// Specifies the class to model a Card Pile like a deck of cards
    /// </summary>
    public class CardPile
    {
        private List<Card> pile = new List<Card>(); //list of cards
        public static int NUM_SUITS = 4; //total number of suits
        public static int NUM_CARDS_PER_SUIT = 13; //total number of cards
        Random random = new Random(); //random variable for shuffle
        
        /// <summary>
        /// Basic Constructor for Card Pile class
        /// </summary>
        public CardPile()
        {

        }

        /// <summary>
        /// Constructor for Card pile class, creates a full deck if true
        /// is given as input
        /// </summary>
        /// <param name="full">Pre: True or false</param>
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

        /// <summary>
        /// Adds a card to the deck
        /// </summary>
        /// <param name="card">Pre: Must be an instantiated Card</param>
        public void AddCard(Card card)
        {
            pile.Add(card);
        }

        /// <summary>
        /// Gets the number of cards in the deck
        /// </summary>
        /// <returns>Int: Returns the number of cards in the deck</returns>
        public int GetCount()
        {
            return pile.Count;
        }

        /// <summary>
        /// Gets the top of the deck, but does not remove it
        /// </summary>
        /// <returns>Card: Returns the top of the deck</returns>
        public Card GetLastCardInPile()
        {
            int topDeck = pile.Count();
            return pile[topDeck - 1];
        }

        /// <summary>
        /// Removes the top card of the deck
        /// </summary>
        public void RemoveLastCard()
        {
            int topDeck = pile.Count();
            pile.RemoveAt(topDeck - 1);
        }

        /// <summary>
        /// Shuffles the deck using fisher-yates shuffle method
        /// </summary>
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

        /// <summary>
        /// Gets the top card of the deck, removing it in the process
        /// </summary>
        /// <returns>Card: Returns the top card of the deck</returns>
        public Card DealOneCard()
        {
            Card card = GetLastCardInPile();
            RemoveLastCard();
            return card;
        }

        /// <summary>
        /// Gets a number of cards from the top of the deck, removing
        /// them in the process
        /// </summary>
        /// <param name="num">Pre: >=0</param>
        /// <returns>List[Card]: Returns the specified number of cards 
        /// from the top of the deck</returns>
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
