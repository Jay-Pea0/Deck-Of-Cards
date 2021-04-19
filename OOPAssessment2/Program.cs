using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssessment2
{
    public class Card
    {
        public enum Suites
        {
            Hearts = 0,
            Diamonds,
            Clubs,
            Spades
        }

        public int Value
        {
            get;
            set;
        }

        public Suites Suite
        {
            get;
            set;
        }

        public string SuitValue
        {
            get
            {
                string CardType = string.Empty;
                switch (Value)
                {
                    case (14):
                        CardType = "Ace";
                        break;
                    case (13):
                        CardType = "King";
                        break;
                    case (12):
                        CardType = "Queen";
                        break;
                    case (11):
                        CardType = "Jack";
                        break;
                    default:
                        CardType = Value.ToString();
                        break;
                }

                return CardType;
            }
        }

        public string CardType
        {
            get
            {
                return SuitValue + " of " + Suite.ToString();
            }
        }

        public Card(int Value, Suites Suite)
        {
            this.Value = Value;
            this.Suite = Suite;
        }
    }

    public class Deck
    {
        public List<Card> Cards = new List<Card>();
        public void CreateDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                Card.Suites suite = (Card.Suites)(Math.Floor((decimal)i / 13));
                int val = i % 13 + 2;
                Cards.Add(new Card(val, suite));
            }
        }

        public void Deal()
        {
            foreach (Card card in this.Cards)
            {
                Console.WriteLine(card.CardType);
            }
        }
        public string DealCard(int PlaceInDeck)
        {
            string[] ArrayOfDeck = new string[52];
            int i = 0;
            foreach (Card card in this.Cards)
            {
                ArrayOfDeck[i] = card.CardType;
                i++;
            }
            return ArrayOfDeck[PlaceInDeck];
        }
        public void Shuffle()
        {
            Random rand = new Random();
            Card temp;
            for (int TimesShuffled = 0; TimesShuffled < 100; TimesShuffled++)
            {
                for (int i = 0; i < 52; i++)
                {
                    int ShuffledCard = rand.Next(13);
                    temp = Cards[i];
                    Cards[i] = Cards[ShuffledCard];
                    Cards[ShuffledCard] = temp;
                }
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            bool validInput = false;
            Deck deck = new Deck();
            Console.WriteLine("Creating Deck");
            deck.CreateDeck();
            Console.WriteLine("Deck Created");
            Console.WriteLine("Shuffling Deck");
            deck.Shuffle();
            Console.WriteLine("Deck Shuffled");
            int i = 0;

            while (validInput == false)
            {
                Console.WriteLine("What would you like to do?\n[1] Deal A Card\n[2] Deal The Deck\n[3] Reshuffle\n[4] End Program");
                string response = Console.ReadLine();
                if((response == "1")&&(i<52) )
                {
                    Console.WriteLine(deck.DealCard(i));
                    i++;
                }
                else if ((response == "1") && (i >= 52))
                {
                    Console.WriteLine("End of deck\nPlease reshuffle for new card");
                }
                else if (response == "2")
                {
                    deck.Deal();
                }
                else if (response == "3")
                {
                    deck.Shuffle();
                    i = 0;
                }
                else if (response == "4")
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid Response");
                }
            }
        }
    }
}
