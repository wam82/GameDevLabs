using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    Transform mTarget;
    [SerializeField]
    float mFollowSpeed;
    [SerializeField]
    float mFollowRange;

    float mArriveThreshold = 0.05f;

    void Update ()
    {
        if(mTarget != null)
        {
            // TODO: Make the enemy follow the target "mTarget"
            //       only if the target is close enough (distance smaller than "mFollowRange")
            float distanceToTarget = Vector3.Distance(transform.position, mTarget.position);

            if (distanceToTarget < mFollowRange)
            {
                Vector3 direction = (mTarget.position - transform.position).normalized;
                transform.position += direction * mFollowSpeed * Time.deltaTime;

                if (distanceToTarget <= mArriveThreshold)
                {
                    transform.position = mTarget.position;
                }
            }
        }
    }

    public void SetTarget(Transform target)
    {
        mTarget = target;
    }
}
