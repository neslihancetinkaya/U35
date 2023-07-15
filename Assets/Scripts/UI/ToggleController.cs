using UnityEngine;

namespace UI
{
    public class ToggleController : MonoBehaviour
    {
        
        [SerializeField] private GameObject BG;
        [SerializeField] private GameObject Check;

        public void OnToggle(bool flag)
        {
            BG.SetActive(!flag);
            Check.SetActive(flag);
        }
    }
}