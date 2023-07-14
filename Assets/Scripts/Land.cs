using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public enum LandStatus
    {
        Soil, Farmland,
    }

    public LandStatus landStatus;

    public Material soilMat, farmLandMat;
    new Renderer renderer;

    //The selection gameobject to enable when the player is selecting the land
    public GameObject select;

    [Header("Crops")]
    //The crop prefab to instantiate
    public GameObject cropPrefab;

    //The crop corrently planted on the land
    CropBehaviour cropPlanted = null;



    // Start is called before the first frame update
    void Start()
    {
        //Get the renderer component
        renderer = GetComponent<Renderer>();

        //Set the land to soil by default
        SwitchLandStatus(LandStatus.Soil);

        //Deselect the land by default
        Select(false);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        //Set land status accordingly
        landStatus = statusToSwitch;

        Material materialToSwitch = soilMat;

        //Decide waht material to switch to 
        switch (statusToSwitch)
        {
            case LandStatus.Soil:
                //Switch to the sail material
                materialToSwitch = soilMat;
                break;
            case LandStatus.Farmland:
                //Switch to farmland material
                materialToSwitch = farmLandMat;

                break;

        }

        //Get the renderer to apply the changes
        renderer.material = materialToSwitch;
    }
    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }
    //When the player presses the intetact button whýle selecting this land
    public void Interact()
    {
        //Interaaction
        SwitchLandStatus(LandStatus.Farmland);

        {
            //Instantiate the crop object parented to the land
            GameObject cropObject = Instantiate(cropPrefab, transform);
            //Move the crop object to the top of the land gameobjevt
            cropObject.transform.position = new Vector3(transform.position.x, 51, transform.position.z);

            //Access the CropBehaviour of the crop we're going to plant
            cropPlanted = cropObject.GetComponent<CropBehaviour>();
            //Plant it
        }

    }

    public void ClockUpdate()
    {
        //Grow the planted crop, if any
        if (cropPlanted != null)
        {
            cropPlanted.Grow();
        }
    }
}
