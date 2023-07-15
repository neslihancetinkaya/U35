using System.Collections.Generic;
using UnityEngine;
using Utils.RefValue;

namespace UI
{
    public class ToDoController : MonoBehaviour
    {
        [SerializeField] private List<BoolRef> MissionBools;
        [SerializeField] private List<ToggleController> Missions;

        public void OnCheckList()
        {
            for (int i = 0; i < Missions.Count; i++)
            {
                Missions[i].OnToggle(MissionBools[i].Value);
            }
        }

        
    }
}