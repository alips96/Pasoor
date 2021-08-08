using UnityEngine;

namespace Pasoor.Cards
{
    public class CardsInfo : MonoBehaviour
    {
        private char value;
        private char type;
        private byte bonus;
        private Sprite sprite;

        public bool isSelected;
        public bool isPlayerCard;

        public Sprite Sprite
        {
            get
            {
                return sprite;
            }
            set
            {
                sprite = value;
            }
        }

        public char Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public char Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public byte Bonus
        {
            get
            {
                return bonus;
            }
            set
            {
                bonus = value;
            }
        }
    }
}

