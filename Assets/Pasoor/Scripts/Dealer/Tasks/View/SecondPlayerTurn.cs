using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pasoor.Cards;

namespace Pasoor.Dealer
{
    public class SecondPlayerTurn : MonoBehaviour
    {
        int test = 0;
        public List<ICard> myCards = new List<ICard>();
        public void React()
        {
            Debug.Log("second player turn");
        }
    }
}

