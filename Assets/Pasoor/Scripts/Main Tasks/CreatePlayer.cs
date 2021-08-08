using Pasoor.BehaviorTree;
using UnityEngine;

namespace Pasoor.Tasks
{
    public class CreatePlayer : BehaviorNode, ITask
    {
        [Input]
        public bool input;

        public bool ExecuteTask()
        {
            return true;
        }
    }
}

