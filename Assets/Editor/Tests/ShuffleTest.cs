using UnityEngine;
using NUnit.Framework;
using Pasoor.Tasks;
using Pasoor.Cards;
using System.Collections.Generic;

namespace Pasoor.Test
{
    public class ShuffleTest
    {
        ShuffleHandler shuffleScript;
        CardsInstances cardsInstancesScript;
        List<ICard> mainList = new List<ICard>();

        [Test]
        public void AddItemsToTheListTest()
        {
            SetInitialRefrences();

            mainList = shuffleScript.AddItemsToTheMainList(cardsInstancesScript.faceCardsList, cardsInstancesScript.pipCardsList);

            if (mainList.Count != 52)
                Assert.Fail();
        }

        [Test]
        public void TestShuffe()
        {
            Stack<ICard> testStack = shuffleScript.Shuffle(mainList);

            if (testStack.Count != 52)
                Assert.Fail();

            for (int i = 0; i < 12; i++)
            {
                ICard item = testStack.Pop();

                if (i >= 8 && i <= 11)
                {
                    if (item is FaceCard)
                    {
                        if (item.GetCardType.CompareTo(0) == 0) //if it is a jack
                        {
                            Assert.Fail();
                        }
                    }
                }
                Assert.Pass();
            }
        }

        private void SetInitialRefrences()
        {
            shuffleScript = ScriptableObject.CreateInstance<ShuffleHandler>();
            cardsInstancesScript = GameObject.Find("SceneContext").GetComponent<CardsInstances>();
        }
    }
}

