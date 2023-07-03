using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="�tem/Seed")]
public class SeedData : ItemData
{
    //time it takes before the seed matures into a crop (tohum �r�ne d�n��mesi i�in ge�en s�re/zaman)
    public int daysToGrow;

    // The crop the seed will yield (tohumun verece�i mahsul)
    public ItemData cropToYield;

    // The seedling GameObject (Fide nesnesi)
    public GameObject seedling;
}
