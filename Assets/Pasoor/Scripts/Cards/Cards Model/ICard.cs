using UnityEngine;

namespace Pasoor.Cards
{
    public interface ICard
	{
        char GetCardValue { get; }
        char GetCardType { get; }
        Sprite GetCardSprite { get; }
        byte GetCardBonus { get; }
    }
}

