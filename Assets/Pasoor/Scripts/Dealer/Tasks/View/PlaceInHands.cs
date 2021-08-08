using Pasoor.Cards;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pasoor.Dealer
{
    public class PlaceInHands : MonoBehaviour
    {
        FirstPlayerTurn firstPlayer;
        SecondPlayerTurn secondPlayer;
        bool isFirstRound = true;
        bool isFirstPlayerTurn = true;

        //Sprites
        public Sprite cardBackSprite;

        //vectors
        public Vector3 firstCardOnDeckPos;
        public byte deckHorizontalDistance;
        public Vector3 firstCardOnPlayer1Pos;
        public Vector3 firstCardOnPlayer2Pos;
        public Vector3 cardsOnDeckPos;

        public Transform parentOfCards;

        public List<ICard> deckCardsList = new List<ICard>();

        public void PlaceCardsInHands()
        {
            if (isFirstRound)
            {
                PlaceCardsOnDeck(firstCardOnPlayer1Pos,isFirstPlayerTurn);
                PlaceCardsOnDeck(firstCardOnPlayer2Pos, !isFirstPlayerTurn);

                if (isFirstRound)
                    PlaceCardsOnDeck(cardsOnDeckPos, true);
                isFirstRound = false;
            }
        }

        //positioning
        readonly byte difference = 14;
        byte stepDifference = 0;

        private void PlaceCardsOnDeck(Vector3 firstCardPos, bool isFirstPlayerTurn)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    //instantiate
                    GameObject instantiatedCard = Instantiate(Resources.Load("CardPrefab"),
                            new Vector3(firstCardPos.x + (stepDifference * difference),
                                        firstCardPos.y,
                                        firstCardPos.z),
                                        Quaternion.identity) as GameObject;

                    stepDifference++;
                    instantiatedCard.transform.SetParent(parentOfCards);

                    ICard currentCard = PopItemFromTheStack();

                    //Setup Sprites
                    if (isFirstPlayerTurn)
                        instantiatedCard.GetComponent<Image>().sprite = currentCard.GetCardSprite; //set sprite
                    else
                        instantiatedCard.GetComponent<Image>().sprite = cardBackSprite;

                    //Setup Info
                    CardsInfo currentCardInfo = instantiatedCard.GetComponent<CardsInfo>();
                    currentCardInfo.Value = currentCard.GetCardValue;
                    currentCardInfo.Type = currentCard.GetCardType;
                    currentCardInfo.Bonus = currentCard.GetCardBonus;
                    currentCardInfo.Sprite = currentCard.GetCardSprite;

                    if (firstCardPos == firstCardOnPlayer1Pos ||
                        firstCardPos == firstCardOnPlayer2Pos)
                        currentCardInfo.isPlayerCard = true;
                    else
                        currentCardInfo.isPlayerCard = false;

                    if (isFirstPlayerTurn)
                        firstPlayer.ActivateCardClick(instantiatedCard);                 
                }
            }
        }

        private ICard PopItemFromTheStack()
        {
            return CardsStack.mainCardsStack.Pop(); //Pop the last element of stack
        }

        [Inject]
        void SetInitialRefrences(FirstPlayerTurn fTurn, SecondPlayerTurn secTurn)
        {
            firstPlayer = fTurn;
            secondPlayer = secTurn;
        }
    }

}
