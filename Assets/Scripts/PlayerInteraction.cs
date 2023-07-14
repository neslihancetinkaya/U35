using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    CharacterController characterController;

    //The land the player is currently selecting
    Land selectedLand = null;

    // Start is called before the first frame update
    void Start()
    {
        characterController = transform.parent.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            OnInteractableHit(hit);
        }
    }

    //Handles what happens when the interaction raycast hits something interactable
    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        //Check if the player is going to interact with land
        if (other.tag == "Land")
        {
            //Get the land component
            Land land = other.GetComponent<Land>();
            SelectLand(land);
            return;
        }

        //Deselect the land if the player is not standing on any land at the moment
        if (selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }

    }

    //Handles the selection process
    void SelectLand(Land land)
    {
        //Set the previously selected land to false (if any)
        if (selectedLand != null)
        {
            selectedLand.Select(false);
        }

        //Select the now selected land to the land we're selecting now.
        selectedLand = land;
        land.Select(true);
    }
    //Triggered when the player presses the tool button
    public void Interact()
    {
        //Cehch if the player is selecting and land
        if (selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }

        Debug.Log("Not on any land!");
    }
}
