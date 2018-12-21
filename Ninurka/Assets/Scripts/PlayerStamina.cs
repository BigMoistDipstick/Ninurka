using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class PlayerStamina : MonoBehaviour
{
    public float stamina = 100f;
    bool isActivated = false;
    PlayerMovement movement;
    public Button indicator;
    public Color test;

	void Start ()
    {
        movement = GetComponent<PlayerMovement>();
	}

	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R was pressed");
            if (!isActivated && stamina > 0)
            {
                isActivated = true;
                movement.PlayerRun();
                if (isActivated)
                {
                    //indicator.colors
                }
            }
            else
            {
                isActivated = false;
                movement.PlayerWalk();
            }
        }

        if (stamina <= 0)
        {
            isActivated = false;
            movement.PlayerWalk();
        }

        if (isActivated)
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
        //Debug.Log("Stamina: " + Mathf.Round(stamina));
    }

    public void StaminaRecharge()
    {
        if (stamina < 100f)
        {
        stamina += 0.005f;
        }
        //Debug.Log("Stamina: " + Mathf.Round(stamina));
    }
}
