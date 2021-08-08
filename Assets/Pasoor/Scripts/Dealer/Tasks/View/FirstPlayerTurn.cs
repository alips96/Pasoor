using System.Collections.Generic;
using UnityEngine;
using Pasoor.Cards;
using UnityEngine.UI;
using Zenject;

namespace Pasoor.Dealer
{
    public class FirstPlayerTurn : MonoBehaviour
    {
        public List<ICard> myCards = new List<ICard>();
        public List<ICard> deckCards = new List<ICard>();
        public GameObject dropButton;

        int test = 0;
        bool isDoneCalculation = false;

        PlaceInHands placeInHandsScript;
        CardsEffects cardsEffectsScript;
        DropActions dropActionsScript;
        BonusCalculator bonusCalculatorScript;
        DealerMaster dealerMaster;

        [Inject]
        void SetInitialReferences(
            PlaceInHands _placeInHands,
            CardsEffects _cardsEffects,
            DropActions _dropActions,
            BonusCalculator _bonusCal,
            DealerMaster _dMaster)
        {
            placeInHandsScript = _placeInHands;
            cardsEffectsScript = _cardsEffects;
            dropActionsScript = _dropActions;
            bonusCalculatorScript = _bonusCal;
            dealerMaster = _dMaster;

            if(placeInHandsScript != null)
            {
                deckCards = placeInHandsScript.deckCardsList;
            }
            else
            {
                Debug.LogWarning("Place in hands script is null!");
            }
        }

        public void ActivateCardClick(GameObject go)
        {
            go.GetComponent<Button>().onClick.AddListener(delegate { ClickedButtonActions(go); });
        }

        GameObject SelectedCard;
        public LinkedList<GameObject> SelectedCardsList = new LinkedList<GameObject>();

        private void ClickedButtonActions(GameObject instantiatedCard)
        {
            CardsInfo currentCardInfo = instantiatedCard.GetComponent<CardsInfo>(); //Extract Cards Info

            if (currentCardInfo.isPlayerCard) //if it was a player card
            {
                cardsEffectsScript.SwitchPlayerCardEffect(instantiatedCard);

                if (instantiatedCard != SelectedCard)
                {
                    SelectedCard = instantiatedCard;
                    dropButton.SetActive(true);
                    ActivateDropButtonClick(SelectedCard);

                    if (CanWinCards())
                    {
                        dealerMaster.CallEventAvtivateSecondPlayer();
                        dropButton.SetActive(false);
                    }
                }
                else
                {
                    SelectedCard = null;
                    dropButton.SetActive(false);
                }
            }
            else // if it was a deck card
            {
                cardsEffectsScript.SwitchDeckCardEffect(instantiatedCard);
                currentCardInfo.isSelected = !currentCardInfo.isSelected;

                if (currentCardInfo.isSelected)
                {
                    SelectedCardsList = AddToSelectedCards(instantiatedCard, SelectedCardsList);

                    if (CanWinCards())
                    {
                        dealerMaster.CallEventAvtivateSecondPlayer();
                        dropButton.SetActive(false);
                    }
                        
                }
                else
                {
                    SelectedCardsList = RemoveFromSelectedCards(instantiatedCard, SelectedCardsList);

                    if (CanWinCards())
                    {
                        dealerMaster.CallEventAvtivateSecondPlayer();
                        dropButton.SetActive(false);
                    }
                }
            }
        }

        private bool CanWinCards()
        {
            if (SelectedCard != null)
            {
                if (SelectedCardsList.Count > 0)
                {
                    CardsInfo selectedCardInfo = SelectedCard.GetComponent<CardsInfo>();

                    if (selectedCardInfo.Value.CompareTo('J') != 0) //if it was not a jack
                    {
                        if (selectedCardInfo.Value.CompareTo('K') == 0 ||
                            selectedCardInfo.Value.CompareTo('Q') == 0) //if the card was king or queen
                        {
                            if (SelectedCardsList.Count == 1)
                            {
                                GameObject listElement = SelectedCardsList.First.Value;
                                char someChar = listElement.GetComponent<CardsInfo>().Value;

                                if (selectedCardInfo.Value.CompareTo(someChar) == 0)
                                {
                                    dropActionsScript.ThrowTheCard(selectedCardInfo, SelectedCardsList, SelectedCard);
                                    return true;
                                }
                            }
                        }
                        else //if the card was a pip card
                        {
                            if (CouldPickupCards(selectedCardInfo, SelectedCardsList))
                            {
                                dropActionsScript.ThrowTheCard(selectedCardInfo, SelectedCardsList, SelectedCard);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool CouldPickupCards(CardsInfo cardInfo, LinkedList<GameObject> cardsList)
        {
            int playerCardValue = (int) char.GetNumericValue(cardInfo.Value);

            if (playerCardValue.Equals(0))
                playerCardValue = 10;

            int sum = playerCardValue;

            foreach (GameObject item in SelectedCardsList)
            {
                int deckCardValue = (int) char.GetNumericValue (item.GetComponent<CardsInfo>().Value);

                if (deckCardValue < 0 && deckCardValue > 9)
                    return false;
                else
                {
                    if (deckCardValue.Equals(0))
                        deckCardValue = 10;

                    sum += deckCardValue;
                }
            }

            if (sum.Equals(11))
                return true;

            return false;
        }

        private void ActivateDropButtonClick(GameObject card)
        {
            dropButton.GetComponent<Button>().onClick.RemoveAllListeners();
            dropButton.GetComponent<Button>().onClick.AddListener(delegate { dropActionsScript.DropCurrentCard(card); });
        }

        private LinkedList<GameObject> RemoveFromSelectedCards(GameObject card, LinkedList<GameObject> someList)
        {
            someList.Remove(card);
            return someList;
        }

        private LinkedList<GameObject> AddToSelectedCards(GameObject card, LinkedList<GameObject> someLinkedList)
        {
            someLinkedList.AddLast(card);
            return someLinkedList;
        }
    }
}

