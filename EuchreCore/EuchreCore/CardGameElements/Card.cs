using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.CardGameElements
{
    public enum Suit
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
            value = num%13 + 1;
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

        public override string ToString()
        {
            return ConvertSuitToStr(suit_value) + ConvertValueToStr(value);
        }

        private static string ConvertValueToStr(int i)
        {
            if (i == 1)
            {
                return "A";
            }
            else if (i == 11)
            {
                return "J";
            }
            else if (i == 12)
            {
                return "Q";
            }
            else if (i == 13)
            {
                return "K";
            }
            
            return i.ToString();
        }

        private static string ConvertSuitToStr(Suit suitValue)
        {
            switch (suitValue)
            {
                case Suit.Clubs:
                    return "C";
                case Suit.Hearts:
                    return "H";
                case Suit.Diamonds:
                    return "D";
                case Suit.Spades:
                    return "S";
                default:
                    throw new Exception("bad type exception");
            }
        }

        public static Suit ConvertStrToSuit(string suitStr)
        {
            switch (suitStr.ToUpper())
            {
                case "C":
                    return Suit.Clubs;
                case "H" :
                    return Suit.Hearts;
                case "D":
                    return Suit.Diamonds;
                case "S":
                    return Suit.Spades;
                default:
                    throw new Exception("bad type exception");
            }            
        }
    }
}
