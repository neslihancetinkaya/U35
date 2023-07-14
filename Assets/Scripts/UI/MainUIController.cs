using System;
using UnityEngine;
using UnityEngine.UI;
using Utils.RefValue;

namespace UI
{
    public class MainUIController : MonoBehaviour
    {
        [SerializeField] private Slider HealthBar;
        [SerializeField] private FloatRef Health;
        [SerializeField] private Text HealthText;

        private void Update()
        {
            HealthBar.value = Health.Value / 100f;
        }

        public void SetHealthText()
        {
            HealthText.text = Health.Value.ToString();
        }
    }
}