using System.Collections.Generic;
using Pasoor.BehaviorTree;
using Pasoor.Cards;
using Zenject;
using UnityEngine;

namespace Pasoor.Tasks
{
    public class ShuffleHandler : BehaviorNode, ITask
    {
        [Input]
        public bool input; //xNode
        List<ICard> tempCardsList = new List<ICard>();
        [Inject]
        CardsInstances cardsInstancesScript;
        public Stack<ICard> cardsStack = new Stack<ICard>();
        System.Random rng = new System.Random();

        public bool ExecuteTask()
        {
            SetInitialRefrences();
            tempCardsList = AddItemsToTheMainList(cardsInstancesScript.faceCardsList, cardsInstancesScript.pipCardsList);
            cardsStack = Shuffle(tempCardsList);

            if (cardsStack.Count == 52)
            {
                CardsStack.mainCardsStack = cardsStack;
                return true;
            }


            Debug.Log(cardsStack.Count);
            return false;
        }

        public List<ICard> AddItemsToTheMainList(List<FaceCard> list1, List<PipCard> list2)
        {
            List<ICard> returnList = new List<ICard>();

            foreach (var item in list1) //Fillout the list with pip cards first.
            {
                returnList.Add(item);
            }

            foreach (var item in list2) //Fillout the list with face cards.
            {
                returnList.Add(item);
            }

            return returnList;
        }

        public Stack<ICard> Shuffle(List<ICard> someList)
        {
            Stack<ICard> returnStack = new Stack<ICard>();
            int n = someList.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);

                ICard value = someList[k];
                someList[k] = someList[n];
                someList[n] = value;
            }

            ///Check if the cards placing on the deck are not jack. if it was
            ///it would replace it with another card
            for (int i = 40; i <= 43; i++)
            {
                if(someList[i] is FaceCard)
                {
                    if(someList[i].GetCardValue.CompareTo('J') == 0) //if it is a jack
                    {
                        int randomPosition = Random.Range(0, 39);

                        while(someList[randomPosition].GetCardValue.CompareTo('J') == 0) //if that was also a jack
                        {
                            randomPosition = Random.Range(0, 39);
                        }

                        //Replace
                        ICard temp = someList[i];
                        someList[i] = someList[randomPosition];
                        someList[randomPosition] = someList[i];
                    }
                }
            }

            //Adding to the stack
            Stack<ICard> someStack = new Stack<ICard>();

            foreach (ICard item in someList)
            {
                someStack.Push(item);
            }

            return someStack;
        }

        //[Inject]
        //void SetCardsInstanceRefrence(CardsInstances _instance) //Set initial refrences.
        //{
        //    cardsInstancesScript = _instance;
        //}

        void SetInitialRefrences()
        {
            cardsInstancesScript = GameObject.Find("SceneContext").GetComponent<CardsInstances>();
        }
    }
}

