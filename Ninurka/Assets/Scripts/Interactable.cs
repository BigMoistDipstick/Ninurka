using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;               //declare radius var as float (used to determine how far a player can be and still interact)
    bool isFocused = false;                 //declare isFocused var as bool (used to determine if an object is currently focused)
    public Transform player;                //declare player var as transform (used to determine the distance for radius)
    bool hasInteracted = false;             //declare hasInteracted var as bool (used to only interact once, instead of once per frame)
    public Transform interactionTransform;  //declare interactionTransform as transform (used to set specific radius zones (eg only accessible from the front of an object))

    public virtual void Interact() //
    {
        Debug.Log("Interacting with " + transform.name); //debug what you are currently interacting with
    }

    void Update()
    {
        if (isFocused && !hasInteracted)                                                        //if object is focused but player has not yet interacted (walking towards it)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);  //declare distance var as float, checks distance between player and interactionTransform object
            if (distance <= radius)                                                             //if distance (of player) is less than or equal to radius
            {
                Debug.Log("INTERACT");                                                          //debug interact
                Interact();                                                                     //call interact function ()
                hasInteracted = true;                                                           //set hasInteracted bool to true (for one tick, so it doesn't interact every tick)

            }

        }
    }

    public void OnFocused(Transform playerTransform)    //create onfocused function with playerTransform parameter
    {
        isFocused = true;                               //there is an object that is focused
        //player = playerTransform;
        hasInteracted = false;                          //turn off hasInteracted var (so it doesn't interact every tick)
    }

    public void OnDefocused()   //create ondefocused function
    {
        isFocused = false;      //there is no object that is focused
        //player = null;
        hasInteracted = false;  //turn off hasInteracted var (so it doesn't interact every tick) (this line isn't needed, but is here just in case)
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;                                    //changes gizmos colour to yellow
        Gizmos.DrawWireSphere(interactionTransform.position, radius);   //create wire sphere using the size of radius (to show interactable area)
    }
}
