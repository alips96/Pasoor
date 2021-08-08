using UnityEngine;
using UnityEngine.UI;

namespace Pasoor.Dealer
{
    public class CardsEffects : MonoBehaviour
    {
        private GameObject previousCard; // it is used to select and deselect the button

        public void SwitchPlayerCardEffect(GameObject currentCard)
        {
            if(previousCard != null)
                SetOffPreviousCardEffect();

            if (previousCard != currentCard)
            {
                SetOnEffect(currentCard);
                previousCard = currentCard;
            }
            else
                previousCard = null;
        }

        private void SetOnEffect(GameObject currentCard)
        {
            currentCard.GetComponent<Image>().color = Color.red;
        }

        private void SetOffPreviousCardEffect()
        {
            previousCard.GetComponent<Image>().color = Color.white;
        }

        public void SwitchDeckCardEffect(GameObject instantiatedCard)
        {
            Color CurrentCardColor = instantiatedCard.GetComponent<Image>().color;

            if (CurrentCardColor == Color.white)
                SetOnEffect(instantiatedCard);
            else
                SetOffEffect(instantiatedCard);
        }

        public void SetOffEffect(GameObject card)
        {
            card.GetComponent<Image>().color = Color.white;
        }
    }
}

