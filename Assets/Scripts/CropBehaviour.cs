using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropBehaviour : MonoBehaviour
{
    //Information on what the crop will grow into (Mahsulün neye dönüþeceði hakkýnda bilgi)
    SeedData seedToGrow;

    [Header("Strages of Life")]
    public GameObject seed;
    private GameObject seedling;
    private GameObject harvestable;

    //The growht points of the crop
    int growth;
    //How many growth points it takes before it becomes harvestable
    int maxGrowth;
    public enum CropState
    {
        Seed, Seedling, Harvestable
    }
    //The current stage in the crops growth
    public CropState cropState;

    //Initialisation for the crop GameOBject (Kýrpma GameOBject için baþlatma)
    //Called when the player plants a seed (Oyuncu bir tohum ektiðinde çaðrýlýr)
    public void Plant(SeedData seedToGrow)
    {
        //Save the seed information (Tohum bilgilerini kaydet)
        this.seedToGrow = seedToGrow;

        //Instantiate the seedling and harvestable GameOBjects
        seedling = Instantiate(seedToGrow.seedling, transform);

        //Access the crop item data
        ÝtemData cropToYield = seedToGrow.cropToYield;

        //Instantiate the harvestable crop
        harvestable = Instantiate(cropToYield.gameModel, transform);

        //Convert Days To Grow into mýnutes
        maxGrowth = seedToGrow.daysToGrow;

        //int hoursToGrow = GameTimestamp.DaysToHours(seedToGrow.daysToGrow);
        //Convert it to minutes
        //maxGrowth = GameTimesstamp.HoursToMinutes(hoursToGrow);



        //Set the initial state to Seed
        SwitchState(CropState.Seed);
    }

    //The crop will grow when watered
    public void Grow()
    {
        //Increase the growth point by 1
        growth++;

        //Hte seed will sprout into a seedling when the growth s at 50%
        if (growth >= maxGrowth / 2 && cropState == CropState.Seed)
        {
            SwitchState(CropState.Seedling);
        }

        //Grow from seedling to harvestable
        if (growth >= maxGrowth && cropState == CropState.Seedling)
        {
            SwitchState(CropState.Harvestable);
        }
    }


    void SwitchState(CropState stateToSwitch)
    {
        //Reset everything and set all GameObeject to inactice
        seed.SetActive(false);
        seedling.SetActive(false);
        harvestable.SetActive(false);

        switch (stateToSwitch)
        {
            case CropState.Seed:
                //Enable the Seed GameObject
                seed.SetActive(true);
                Debug.Log("Crop state changed to: Seed");
                break;
            case CropState.Seedling:
                //Enable the Seedling GameObject
                seedling.SetActive(true);
                Debug.Log("Crop state changed to: Seedling");
                break;
            case CropState.Harvestable:
                //Enable the Harvestable GameObject
                harvestable.SetActive(true);
                Debug.Log("Crop state changed to: Harvestable");
                //Unparent it to the crop
                harvestable.transform.parent = null;

                Destroy(gameObject);
                break;


        }

        //Set the current crop state to the state we're switching to
        cropState = stateToSwitch;
    }
}
