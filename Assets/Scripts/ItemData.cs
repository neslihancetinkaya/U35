using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item")]
public class �temData : ScriptableObject
{

    public string description;

    // �conn to be displayed in UI (a��klama ve simge)
    public Sprite thumbnail;

    // GameObjeck to be shown in the scere (oyun i�i model)
    public GameObject gameModel;
}


