using Pasoor.Cards;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Pasoor.Dealer
{
    public class DropActions : MonoBehaviour
    {
        BonusCalculator bonusCalculatorScript;
        DealerMaster dealerMaster;
        ResetSettings resetSettingsScript;

        public struct MiddleCards
        {
            public GameObject cardObject;
            public CardsInfo cardInfo;

            public MiddleCards(GameObject cardObject, CardsInfo _info)
            {
                this.cardObject = cardObject;
                cardInfo = _info;
            }
        }

        public void DropCurrentCard(GameObject go)
        {
            GameObject[] cardsObjects = GameObject.FindGameObjectsWithTag("Card");
            List<MiddleCards> middleCardsList = new List<MiddleCards>();

            foreach (GameObject item in cardsObjects) //extract middle cards
            {
                CardsInfo cardInfo = item.GetComponent<CardsInfo>();

                if (!cardInfo.isPlayerCard)
                    middleCardsList.Add(new MiddleCards(item, cardInfo));
            }

            if(middleCardsList.Count > 0)
            {
                CardsInfo playerCardInfo = go.GetComponent<CardsInfo>(); //player info
                LinkedList<GameObject> CardsToWinList = new LinkedList<GameObject>();

                if(playerCardInfo.Value.CompareTo('J') == 0)
                {
                    foreach (MiddleCards item in middleCardsList)
                    {
                        if(item.cardInfo.Value.CompareTo('K') != 0 &&
                            item.cardInfo.Value.CompareTo('Q') != 0)
                        {
                            CardsToWinList.AddLast(item.cardObject);
                        }
                    }

                    if(CardsToWinList.Count > 0) // jack could win some cards
                    {
                        ThrowTheCard(playerCardInfo, CardsToWinList, go);
                        middleCardsList.Clear();
                    }
                    else
                    {
                        ///Throw the card on the deck only
                    }
                }
            }
            else
            {
                /// hichi nabood faghat bendaz.
            }

            resetSettingsScript.ResetCardsSettings(); ///new
            dealerMaster.CallEventAvtivateSecondPlayer();
        }

        public void ThrowTheCard(CardsInfo playrCardInfo, LinkedList<GameObject> cardsList, GameObject selectedCard)
        {
            bonusCalculatorScript.calculatePlayerBonus(playrCardInfo, cardsList);
            Destroy(selectedCard);

            foreach (GameObject item in cardsList)
            {
                Destroy(item);
            }

            cardsList.Clear();
        }

        [Inject]
        void SetInitialReferences(BonusCalculator _bonus, DealerMaster _dMaster, ResetSettings _rSettings)
        {
            bonusCalculatorScript = _bonus;
            dealerMaster = _dMaster;
            resetSettingsScript = _rSettings;
        }
    }
}

