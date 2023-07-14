using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ýtem/Seed")]
public class SeedData : ItemData
{
    //time it takes before the seed matures into a crop (tohum ürüne dönüþmesi için geçen süre/zaman)
    public int daysToGrow;

    // The crop the seed will yield (tohumun vereceði mahsul)
    public ItemData cropToYield;

    // The seedling GameObject (Fide nesnesi)
    public GameObject seedling;
}
