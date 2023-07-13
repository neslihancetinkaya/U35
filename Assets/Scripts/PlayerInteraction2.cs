using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction2 : MonoBehaviour
{
    //New
    //Interaction components
    PlayerInteraction playerInteraction;
    //Finish

    void Start()
    {
        //New
        //Get interaction component
        playerInteraction = GetComponentInChildren<PlayerInteraction>();
        //Finish
    }

    void Update()
    {
        //New
        //Runs the function that handles all interaction
        Interact();
    }

    public void Interact()
    {
        //Tool interaction
        if (Input.GetKeyDown("f"))
        {
            //Interact
            playerInteraction.Interact();
        }

        //TODO: Set up item interaction
    }
    //Finish

}
