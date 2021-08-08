using Pasoor.BehaviorTree;
using UnityEngine;

namespace Pasoor.Tasks
{
    public class RestartHandler : BehaviorNode, ITask
    {
        [Input]
        public bool input;

        public bool ExecuteTask()
        {
            //Debug.Log("i am restart handler");
            return true;
        }
    }
}

