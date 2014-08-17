using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.CardGameElements
{
    enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public class Card
    {
        private int value;
        private Suit suit_value;

        public Card(int num)
        {
            value = num%13;
            suit_value = (Suit) (num/13);
        }

        public Card(int init_value, Suit init_suit_value)
        {
            value = init_value;
            suit_value = init_suit_value;
        }

        public int Value
        {
            get { return value; }
        }

        public Suit Suit
        {
            get { return suit_value; }
        }
    }
}
