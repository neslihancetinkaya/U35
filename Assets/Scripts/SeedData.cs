using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Seed")]
public class SeedData : ÝtemData
{
    // time it takes before the seed matures into a crop
    // tohumun ürüne dönüþmesi için geçen süre
    public int daysToGrow;

    // the crop the seed will yield 
    // tohumun vereceði mahsul
    public ÝtemData cropToYield;

    // the seedling GameObject
    public GameObject seedling;
}

