using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

namespace AI
{
    public class Flee : AIMovement
    {
        public override SteeringOutput GetKinematic(AIAgent agent)
        {
            var output = base.GetKinematic(agent);

            // TODO: calculate linear component
            Vector3 desiredVelocity = agent.TargetPosition - agent.transform.position;
            desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;
            output.linear = -desiredVelocity;
			
            return output;
        }

        public override SteeringOutput GetSteering(AIAgent agent)
        {
            var output = base.GetSteering(agent);

            // TODO: calculate linear component
            Vector3 desiredVelocity = agent.TargetPosition - transform.position;
            desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;
            Vector3 steering = desiredVelocity - agent.Velocity;
            output.linear = -steering;
			
            return output;
        }
    }
}
