using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Seed")]
public class SeedData : �temData
{
    // time it takes before the seed matures into a crop
    // tohumun �r�ne d�n��mesi i�in ge�en s�re
    public int daysToGrow;

    // the crop the seed will yield 
    // tohumun verece�i mahsul
    public �temData cropToYield;

    // the seedling GameObject
    public GameObject seedling;
}

