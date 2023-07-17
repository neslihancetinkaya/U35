using System;
using System.Collections.Generic;
using DG.Tweening;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using Utils.RefValue;
using Random = UnityEngine.Random;

namespace UI
{
    public class MainUIController : MonoBehaviour
    {
        [SerializeField] private Slider HealthBar;
        [SerializeField] private FloatRef TimeOfDay;
        [SerializeField] private IntRef DayCount;
        [SerializeField] private FloatRef Health;
        [SerializeField] private Text HealthText;
        [SerializeField] private Text DayText;
        [SerializeField] private Image TimeOfDayImage;
        [SerializeField] private List<Slider> Stats;
        [SerializeField] private List<float> StatValues;
        [SerializeField] private ThirdPersonController TPS;

        private void Update()
        {
            HealthBar.value = Health.Value / 100f;
            TimeOfDayImage.fillAmount = TimeOfDay.Value / 100f;
            DayText.text = "Day " + DayCount.Value;
        }

        public void SetHealthText()
        {
            HealthText.text = Health.Value.ToString();
        }

       public void OpenTablet()
        {
            TPS.LockCameraPosition = true;
            // tablet panel set active true
            foreach (var stat in Stats)
            {
                float value = 0;
                DOTween.To(() => value, x => value = x, StatValues[Stats.IndexOf(stat)] * Random.Range(1f , 1.5f), .25f)
                    .OnUpdate(() =>
                    {
                        stat.value = value;
                    });
            }
        }

        public void CloseTablet()
        {
            TPS.LockCameraPosition = false;
            // tablet panel set active false
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}