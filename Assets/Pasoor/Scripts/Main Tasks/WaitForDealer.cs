using Pasoor.BehaviorTree;
using System;
using UnityEngine;

namespace Pasoor.Tasks
{
    /// <summary>
    /// in this class we were not able to use constructor injection due to the xNode
    /// Nor we were able to use method injection since it is not a monobehavior.
    /// so we stick to the old way of injection(new)!
    /// </summary>
    public class WaitForDealer : BehaviorNode, ITask
    {
        [Input]
        public bool input;
        private SequenceNode dealerSequenceNode;

        public bool ExecuteTask()
        {
            dealerSequenceNode = new SequenceNode();

            if (dealerSequenceNode != null)
            {
                RunBehaviorTreeWithTasks();
            }
            else
            {
                throw new Exception("dealerSequenceNode is null");
            }

            return true;
        }

        void RunBehaviorTreeWithTasks()
        {
            dealerSequenceNode.TasksQueue.Enqueue(CreateInstance<ShuffleHandler>());
            dealerSequenceNode.TasksQueue.Enqueue(CreateInstance<Play>());
            dealerSequenceNode.RunAllChildrenNodes();
        }
    }
}

