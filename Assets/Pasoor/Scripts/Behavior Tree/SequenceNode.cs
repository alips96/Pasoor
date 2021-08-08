using Pasoor.Tasks;
using System.Collections.Generic;

namespace Pasoor.BehaviorTree
{
    [System.Serializable]
    public class SequenceNode : BehaviorNode
	{
        public Queue<ITask> TasksQueue = new Queue<ITask>();

        [Output]
        public bool output = false;
        
        public void RunAllChildrenNodes()
        {
            while (TasksQueue.Count > 0)
            {
                ITask currentTask = TasksQueue.Dequeue();
                
                if (!currentTask.ExecuteTask())
                {
                    throw new System.Exception("Error occured!"); //something bad has just happened :(
                }
            }
        }
	}
}

