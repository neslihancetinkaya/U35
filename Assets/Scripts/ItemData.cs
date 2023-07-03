using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item/Item")]
public class ItemData : ScriptableObject
{
    public string description;

    //ýcon to be displayed in UI (açýklama ve simge)
    public Sprite thumbnail;

    //GameObejeck to be shown in the scere (oyun içi model)
    public GameObject gameModel;
}
