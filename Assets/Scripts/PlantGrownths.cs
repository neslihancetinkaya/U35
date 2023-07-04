using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrownths : MonoBehaviour
{
    private int curretProgression = 0;
    public int timeBetweenGrownths;
    public int maxGrownht;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Grownth", timeBetweenGrownths, timeBetweenGrownths);
    }

    // Update is called once per frame
    void Update()
    {
        if (curretProgression != maxGrownht)
        {
            gameObject.transform.GetChild(curretProgression).gameObject.SetActive(true);
        }
        if (curretProgression > 0 && curretProgression < maxGrownht)
        {
            gameObject.transform.GetChild(curretProgression - 1).gameObject.SetActive(false);
        }
        if (curretProgression < maxGrownht)
        {
            curretProgression++;
        }
    }
}
