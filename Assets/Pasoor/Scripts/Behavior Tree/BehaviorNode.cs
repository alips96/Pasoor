using UnityEngine;
using XNode;

namespace Pasoor.BehaviorTree
{
    [System.Serializable]
    public class BehaviorNode : Node 
	{
        public enum Status { idle, running, successful, Failed };

        public Status currentStatus = Status.idle;
    }
}

