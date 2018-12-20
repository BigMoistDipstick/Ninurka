using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    Camera cam;                     //declare cam var as camera
    public LayerMask movementMask;  //declare movementMask var as layermask
    PlayerMovement movement;        //declare movement var as playermovement

    public Interactable focus;      //declare focus var (used to know what object is currently focused) (used with functions from interactable script)

	void Start ()
    {
        cam = Camera.main;                          //link cam variable to main camera in unity
        movement = GetComponent<PlayerMovement>();  //link movement variable to PlayerMovement script
	}
	
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))                             //if left mouse button is clicked
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);    //create ray var (called ray) from camera at position of mouse
            RaycastHit hit;                                         //create raycasthit var (called hit)
            

            if (Physics.Raycast(ray, out hit, 1000, movementMask))                 //if the ray hits, parameters (ray, raycasthit, range, mask)
            {
                Debug.Log("TEST");
                movement.MoveToPoint(hit.point);                    //calls movetopoint function from playermovement script (moves player towards the point that was clicked) (converts hit var to point argument???)
                RemoveFocus();                                      //call RemoveFocus function (removes focused object from focus var)
            }
        }

        if (Input.GetMouseButtonDown(1))                                                //if right mouse button is clicked
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);                        //create ray var (called ray) from camera at position of mouse
            RaycastHit hit;                                                             //create raycasthit var (called hit)

            if (Physics.Raycast(ray, out hit, 100))                                     //if the ray hits, parameters (ray, raycasthit, range, mask)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();  //links interactable var (called interactable) to interactable script (and associates the object that was clicked)?
                if (interactable != null)                                               //if an interactable object is clicked (interactable object is not nothing)
                {
                    SetFocus(interactable);                                             //call SetFocus method with interactable argument?
                }
            }

        }
    }

    void SetFocus (Interactable newFocus)       //create setfocus function with newFocus parameter
    {
        if (newFocus != focus)                  //if newly focused object is different (newly focused object is not the same as the currently focused object)
        {
            if (focus != null)                  //if you are currently focused on something (currently focused object is not nothing)
            {
            focus.OnDefocused();                //call ondefocused function from interactable script (isFocused = false)
            }
            focus = newFocus;                   //set current focus to the newly focused object
            movement.FollowTarget(newFocus);    //calls followtarget function from playermovement script (walks up to it and looks at it)
        }

        newFocus.OnFocused(transform);          //call onfocused function from interactable script (isFocused = true)
    }

    void RemoveFocus()                  //create removefocus function 
    {
        if (focus != null)              //if you are currently focused on something (currently focused object is not nothing)
        {
            focus.OnDefocused();        //call ondefocused function from interactable script (isFocused = false)
        }
        focus = null;                   //remove any object from focus var
        movement.StopFollowingTarget(); //calls stopfollowingtarget function from playermovement script (removes current target and thus stops following)
        //focus.OnDefocused();            //call ondefocused function from interactable script (isFocused = false)
    }
}
