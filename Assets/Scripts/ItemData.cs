using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item/Item")]
public class ItemData : ScriptableObject
{
    public string description;

    //�con to be displayed in UI (a��klama ve simge)
    public Sprite thumbnail;

    //GameObejeck to be shown in the scere (oyun i�i model)
    public GameObject gameModel;
}
