using UnityEngine;

namespace AI
{
    public class Wander : AIMovement
    {
        public float wanderDegreesDelta = 45;
        [Min(0)] public float wanderInterval = 0.75f;
        protected float wanderTimer = 0;

        private Vector3 lastWanderDirection;

        public override SteeringOutput GetKinematic(AIAgent agent)
        {
            var output = base.GetKinematic(agent);
            wanderTimer += Time.deltaTime;

            Vector3 desiredVelocity = output.linear;
            // TODO: calculate linear component
            if (lastWanderDirection == Vector3.zero)
            {
                lastWanderDirection = agent.transform.forward.normalized * agent.maxSpeed;
            }

            if (desiredVelocity == Vector3.zero)
            {
                desiredVelocity = agent.transform.forward;
            }

            if (wanderTimer > wanderInterval)
            {
                float angle = (Random.value - Random.value) * wanderDegreesDelta;
                Vector3 direction = Quaternion.AngleAxis(angle, Vector3.up) * lastWanderDirection.normalized;
                Vector3 circleCentre = agent.transform.position + desiredVelocity;
                Vector3 destination = circleCentre + direction.normalized;
                desiredVelocity = destination - agent.transform.position;
                desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

                lastWanderDirection = direction;
                wanderTimer = 0;
            }

            output.linear = desiredVelocity;
			
			if (debug) Debug.DrawRay(transform.position, output.linear, Color.cyan);
			
            return output;
        }

        public override SteeringOutput GetSteering(AIAgent agent)
        {
            var output = base.GetSteering(agent);

            // TODO: calculate linear component
            output.linear = GetKinematic(agent).linear - agent.Velocity;
            

            if (debug) Debug.DrawRay(transform.position + agent.Velocity, output.linear, Color.green);

            return output;
        }
    }
}
