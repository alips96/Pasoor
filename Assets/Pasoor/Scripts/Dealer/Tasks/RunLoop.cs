using UnityEngine;
using Zenject;
using Pasoor.Dealer;

namespace Pasoor
{
    public class RunLoop : MonoBehaviour
    {
        PlaceInHands placeInHands;
        FirstPlayerTurn firstPlayerTurn;
        SecondPlayerTurn secondPlayerTurn;
        DealerMaster dealerMaster;

        [Inject]
        public void RunLoops(PlaceInHands place, FirstPlayerTurn fTurn, SecondPlayerTurn secTurn, DealerMaster _dMaster)
        {
            placeInHands = place;
            firstPlayerTurn = fTurn;
            secondPlayerTurn = secTurn;
            dealerMaster = _dMaster;
        }

        private void OnEnable()
        {
            dealerMaster.EventAvtivateSecondPlayer += ActivateSecondPlayerReactMethod;
            dealerMaster.EventPlaceInHands += ActivatePlaceInHandsMethod;
        }

        private void OnDisable()
        {
            dealerMaster.EventAvtivateSecondPlayer -= ActivateSecondPlayerReactMethod;
            dealerMaster.EventPlaceInHands -= ActivatePlaceInHandsMethod;
        }

        void ActivatePlaceInHandsMethod()
        {
            placeInHands.PlaceCardsInHands();
        }

        void ActivateSecondPlayerReactMethod()
        {
            secondPlayerTurn.React();
        }

        internal bool FinishedGamePlay()
        {
            ActivatePlaceInHandsMethod(); //Just for the very first time
            return true;
        }
    }
}

