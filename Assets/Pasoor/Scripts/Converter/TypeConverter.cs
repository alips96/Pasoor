using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DePasoor.Cards
{
	public class TypeConverter
	{
        public Dictionary<byte, string> typeDic = new Dictionary<byte, string>()
        {
            {0, "Spades" },
            {1, "Clubs" },
            {2, "Diamonds" },
            {3, "Hearts" }
        };

        public Dictionary<byte, string> degreeDic = new Dictionary<byte, string>()
        {
            {0, "Jack" },
            {1, "Queen" },
            {2, "King" },
        };
    }
}

