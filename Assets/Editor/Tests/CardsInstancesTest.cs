using UnityEngine;
using NUnit.Framework;
using Pasoor.Cards;

namespace Pasoor.Test
{
    public class CardsInstancesTest
    {
        CardsInstances cardsInstancesScript;

        [Test]
        public void CheckIfCardsResourcesNotEmpty()
        {
            SetInitialRefrences();

            if(cardsInstancesScript.pipCardsList.Count == 40 &&
                cardsInstancesScript.faceCardsList.Count == 12)
                Assert.Pass();

            Assert.Fail();
        }

        private void SetInitialRefrences()
        {
            cardsInstancesScript = GameObject.Find("SceneContext").GetComponent<CardsInstances>();
        }
    }
}