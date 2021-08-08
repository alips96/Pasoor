using UnityEngine;

namespace Pasoor.Dealer
{
    public class DealerMaster : MonoBehaviour
    {
        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventAvtivateSecondPlayer;
        public event GeneralEventHandler EventPlaceInHands;

        public void CallEventAvtivateSecondPlayer()
        {
            EventAvtivateSecondPlayer.Invoke();
        }

        public void CallEventPlaceInHands()
        {
            EventPlaceInHands.Invoke();
        }
    }
}

