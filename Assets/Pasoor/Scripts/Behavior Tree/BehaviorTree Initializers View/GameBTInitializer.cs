using UnityEngine;
using Pasoor.BehaviorTree;
using Zenject;
using Pasoor.Tasks;

namespace Pasoor
{
    public class GameBTInitializer : MonoBehaviour
    {
        SequenceNode mainSequenceNode;

        [Inject]
        void SetInitialRefrences(SequenceNode _seqNode)
        {
            mainSequenceNode = _seqNode;
        }

        public void FillOutSequenceTask() //Called by Start Game button.
        {
            mainSequenceNode.TasksQueue.Enqueue(ScriptableObject.CreateInstance<WaitForDealer>());
            mainSequenceNode.TasksQueue.Enqueue(ScriptableObject.CreateInstance<RestartHandler>());

            mainSequenceNode.RunAllChildrenNodes(); //Start behavior tree. 
        }
    }
}

