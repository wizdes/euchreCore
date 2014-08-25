using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.CardGameElements
{
    internal class Deck
    {
        private IList<Card> cards;

        public Deck()
        {
            reset();
        }

        public void shuffle()
        {
            Shuffle(cards);
        }

        public static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public Card deal()
        {
            Card cardToReturn = cards.ElementAt(0);
            cards.RemoveAt(0);
            return cardToReturn;
        }

        public void reset()
        {
            cards = new List<Card>();
            for (int i = 0; i < 52; i++)
            {
                cards.Add(new Card(i));
            }            
        }

        public void filterDeck(int[] valuesToRemove, Suit[] suitsToRemove)
        {
            List<Card> cardsToRemove = new List<Card>();
            foreach (Card c in cards)
            {
                if(valuesToRemove.Contains(c.Value) || suitsToRemove.Contains(c.Suit))
                {
                    cardsToRemove.Add(c);
                }
            }

            foreach (Card c in cardsToRemove)
            {
                cards.Remove(c);
            }
        }
    }
}
