using UnityEngine;

namespace Pasoor.Cards
{
    [CreateAssetMenu(fileName = "New Face Card", menuName = "FaceCard")]
    public class FaceCard : ScriptableObject, ICard
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

