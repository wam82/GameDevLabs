using System.Collections.Generic;

namespace BehaviorTree
{
    public class Sequence : Node
    {
        public Sequence() : base() { }
        public Sequence(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                   case NodeState.FAILURE:
                       state = NodeState.FAILURE;
                       return state;
                   case NodeState.SUCCESS:
                       anyChildIsRunning = false;
                       continue;
                   case NodeState.RUNNING:
                       anyChildIsRunning = true;
                       continue;
                   default:
                       continue;
                }
            }

            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }

    }

}
