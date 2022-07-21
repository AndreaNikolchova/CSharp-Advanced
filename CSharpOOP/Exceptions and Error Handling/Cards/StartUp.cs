using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public class Card
    {
        private string[] faceValidation = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string[] suitValidation = new string[] { "S", "H", "D", "C" };
        private string face;
        private string suit;
        public string Face
        {
            get { return this.face; }
            private set 
            {
                if (!faceValidation.Contains(value))
                    throw new ArgumentException("Invalid card!");
                else
                    this.face = value;

            }
        }
        public string Suit
        {
            get { return this.suit; }
            private set
            {
                if (!suitValidation.Contains(value))
                    throw new ArgumentException("Invalid card!");
                else
                    this.suit = value;
            }
        }
        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }
        public override string ToString()
        {
            if (this.suit == "S")
                return $"[{this.Face}\u2660]";
            else if (this.suit == "H")
                return $"[{this.Face}\u2665]";
            else if (this.suit == "D")
                return $"[{this.Face}\u2666]";
            else if (this.suit == "C")
                return $"[{this.Face}\u2663]";
            
                return null;
        }
    }

   public class StartUp
    {
        static void Main(string[] args)
        {
            string[] cards = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<Card> cardsList = new List<Card>();
            for (int i = 0; i < cards.Length; i+=2)
            {
                try
                {
                    cardsList.Add(new Card(cards[i], cards[i + 1]));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);

                }
            }
            Console.WriteLine(String.Join(" ",cardsList));
        }
    }
}
