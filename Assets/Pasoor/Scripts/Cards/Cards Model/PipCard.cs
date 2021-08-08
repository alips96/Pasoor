using UnityEngine;

namespace Pasoor.Cards
{
    [CreateAssetMenu(fileName = "New Pip Card", menuName = "PipCard")]
    public class PipCard : ScriptableObject, ICard
    {
        public char value;
        public char type;
        public Sprite artWork;
        public byte bonus;

        public char GetCardValue
        {
            get
            {
                return value;
            }
        }

        public char GetCardType
        {
            get
            {
                return type;
            }
        }

        public Sprite GetCardSprite
        {
            get
            {
                return artWork;
            }
        }

        public byte GetCardBonus
        {
            get
            {
                return bonus;
            }
        }
    }
}