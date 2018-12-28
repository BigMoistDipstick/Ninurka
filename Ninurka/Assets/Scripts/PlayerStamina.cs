using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //

public class PlayerStamina : MonoBehaviour
{
    public float stamina = 100f;
    bool isRunning = false;
    PlayerMovement movement;
    NavMeshAgent agent;
    public bool isMoving;

	void Start ()
    {
        movement = GetComponent<PlayerMovement>();
        agent = GetComponent<NavMeshAgent>();
	}

	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R was pressed");
            if (!isRunning && stamina > 0)
            {
                isRunning = true;
                movement.PlayerRun();
            }
            else
            {
                isRunning = false;
                movement.PlayerWalk();
            }
        }

        if (agent.remainingDistance <= agent.stoppingDistance + 0.1f)
        {
            isMoving = false;
            if (!isMoving)
            {
                Debug.Log("isMoving = false");
                StaminaRecharge();
            }
        }


        if (stamina <= 0)
        {
            isRunning = false;
            movement.PlayerWalk();
        }

        if (isRunning && isMoving)
        {
            StaminaDepletion();
        }
        else
        {
            StaminaRecharge();
        }
    }

    public void StaminaDepletion()
    {
        stamina -= 0.01f;
    }

    public void StaminaRecharge()
    {
        if (stamina < 100f)
        {
        stamina += 0.005f;
        }
    }
}
