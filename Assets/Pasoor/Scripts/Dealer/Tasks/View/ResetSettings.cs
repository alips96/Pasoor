using Pasoor.Cards;
using UnityEngine;

namespace Pasoor.Dealer
{
    public class ResetSettings
    {
        GameObject cardsParent;
        DropActions dropActionsScript;
        CardsEffects cardsEffectsScript;
        FirstPlayerTurn firstPlayerTurnScript;

        public ResetSettings(DropActions _dropAct, CardsEffects _cEffects, FirstPlayerTurn _fTurn)
        {
            dropActionsScript = _dropAct;
            cardsEffectsScript = _cEffects;
            firstPlayerTurnScript = _fTurn;
        }

        public void ResetCardsSettings()
        {
            GameObject[] cardsObjects = GameObject.FindGameObjectsWithTag("Card");

            foreach (GameObject item in cardsObjects)
            {
                item.GetComponent<CardsInfo>().isSelected = false;
                cardsEffectsScript.SetOffEffect(item);
            }

            firstPlayerTurnScript.SelectedCardsList.Clear();
        }
    }
}

