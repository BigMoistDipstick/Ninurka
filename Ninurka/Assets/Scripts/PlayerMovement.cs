using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //import library used with navmeshagent

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;         //declare agent var as navmeshagent
    public Transform target;    //declare target var as transform (used to know where the player must walk/interact)
    PlayerStamina stamina;
    public float runSpeed = 8f;
    public float walkSpeed = 3.5f;
    DevMode setting;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();   //connect agent var to navmeshagent component in unity
        setting.DefaultNavMesh();
	}

    void Update()
    {
        if (target != null)                          //if there is a target (target is not nothing)
        {
            agent.SetDestination(target.position);  //use navmeshagent to walk towards the target position
            FaceTarget();                           //call facetarget function (looks at the target)
            Debug.Log("INTERACTABLE CLICKED");
        }
    }

    public void MoveToPoint (Vector3 point)             //create movetopoint function with point parameter
    {
        agent.SetDestination(point);                    //use navmeshagent to set the destination of the player to the point parameter?
        Debug.Log("isMoving = true");
    }

    public void PlayerRun()
    {
        Debug.Log("Running");
        agent.speed = runSpeed;
    }

    public void PlayerWalk()
    {
        Debug.Log("Walking");
        agent.speed = walkSpeed;
    }

    public void FollowTarget (Interactable newTarget)       //create followtarget function with newTarget parameter
    {
        target = newTarget.interactionTransform;            //?????????????
        agent.stoppingDistance = newTarget.radius * 0.75f;  //player stops moving when they are inside the radius (radius * 0.75)
        agent.updateRotation = false;                       //???????????
    }

    public void StopFollowingTarget()
    {
        target = null;                  //remove target var
        agent.stoppingDistance = 0f;    //remove stopping distance (player will not stop moving when inside radius)
        agent.updateRotation = true;    //????????????
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;                          //find direction towards target?
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));   //find out how we should rotate ourselves to look at the target (locks y axis)?
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);    //smoothly interpolate towards that direction
    }
}
