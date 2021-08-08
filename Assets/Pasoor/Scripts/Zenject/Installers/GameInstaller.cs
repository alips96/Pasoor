using Zenject;
using Pasoor.Players;
using Pasoor.Dealer;
using Pasoor.BehaviorTree;
using UnityEngine;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    public string player1Name;
    public string player2Name;
    public GameObject BindindsPrefab;

    public override void InstallBindings()
    {
        //Container.Bind<Player>().WithId(true).FromInstance(new HumanPlayer(player1Name)).AsTransient();
        //Container.Bind<Player>().WithId(false).FromInstance(new AIPlayer(player1Name)).AsTransient();

        //Players
        Container.Bind<HumanPlayer>().FromInstance(new HumanPlayer(player1Name)).AsSingle();
        Container.Bind<AIPlayer>().FromInstance(new AIPlayer(player2Name)).AsSingle();

        //Dealer
        Container.Bind<IDealer>().To<Dealer>().AsSingle();

        //Non Monovehavior Classes
        Container.Bind<SequenceNode>().AsTransient();
        Container.Bind<BonusCalculator>().AsSingle();
        Container.Bind<ResetSettings>().AsTransient().NonLazy();

        //Play Tasks
        Container.Bind<PlaceInHands>().FromComponentInNewPrefab(BindindsPrefab).AsSingle();
        Container.Bind<FirstPlayerTurn>().FromComponentInNewPrefab(BindindsPrefab).AsSingle();
        Container.Bind<SecondPlayerTurn>().FromComponentInNewPrefab(BindindsPrefab).AsSingle();
        Container.Bind<CardsEffects>().FromComponentInNewPrefab(BindindsPrefab).AsSingle();
        Container.Bind<DropActions>().FromComponentInNewPrefab(BindindsPrefab).AsSingle();
        Container.Bind<DealerMaster>().FromComponentInNewPrefab(BindindsPrefab).AsSingle();
    }
}