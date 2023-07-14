using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item")]
public class ÝtemData : ScriptableObject
{

    public string description;

    // ýconn to be displayed in UI (açýklama ve simge)
    public Sprite thumbnail;

    // GameObjeck to be shown in the scere (oyun içi model)
    public GameObject gameModel;
}


