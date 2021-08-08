using Pasoor.BehaviorTree;
using UnityEngine;

namespace Pasoor.Tasks
{
    public class Play : BehaviorNode, ITask
    {
        RunLoop runLoop;
        [Input]
        public bool input;

        public bool ExecuteTask()
        {
            runLoop = GameObject.Find("SceneContext").GetComponent<RunLoop>();
            //Debug.Log("i am play script");
            if (runLoop.FinishedGamePlay())
                return true;

            return false;
        }
    }
}

