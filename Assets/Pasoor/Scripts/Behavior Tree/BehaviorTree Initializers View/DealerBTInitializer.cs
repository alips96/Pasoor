using Pasoor.BehaviorTree;
using Pasoor.Tasks;
using UnityEngine;
using Zenject;
/// <summary>
/// thus script is nonsense! be dard nemikhore. akahare hamoon waitfordealer call kardam niaz be in  nis
/// </summary>
namespace Pasoor
{
    public class DealerBTInitializer
    {
        SequenceNode dealerSequenceNode;

        public DealerBTInitializer(SequenceNode _SeqNode)
        {
            dealerSequenceNode = _SeqNode;
        }

        internal void RunBehaviorTreeWithTasks()
        {
            dealerSequenceNode.TasksQueue.Enqueue(ScriptableObject.CreateInstance<ShuffleHandler>());
            dealerSequenceNode.TasksQueue.Enqueue(ScriptableObject.CreateInstance<Play>());

            dealerSequenceNode.RunAllChildrenNodes();
        }
    }
}

