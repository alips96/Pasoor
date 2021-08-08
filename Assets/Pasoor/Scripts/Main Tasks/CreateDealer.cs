using Pasoor.BehaviorTree;
using System;

namespace Pasoor.Tasks
{
    public class CreateDealer : BehaviorNode, ITask
    {
        [Input]
        public bool input;

        public bool ExecuteTask()
        {
            throw new NotImplementedException();
        }
    }
}

