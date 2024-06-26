using UnityEngine;
using TMPro;
using Utils.RefValue;

public class LightingManager : MonoBehaviour
{
    // Scene References
    [SerializeField] private Light DirectionalLight;
   

    // Day Counter References
    [SerializeField] private IntRef DayCount;
    [SerializeField] private FloatRef TimeOfDay;

    // Day Cycle Variables
    public float dayDuration = 30f;
    private float dayTimer;

    // Night Cycle Variables
    public float nightDuration = 30f;
    private float nightTimer;

    private void Update()
    {
        if (Application.isPlaying)
        {
            dayTimer += Time.deltaTime;
            if (dayTimer >= dayDuration)
            {
                dayTimer = 0f;
                DayCompleted();
            }

            nightTimer += Time.deltaTime;

            if (nightTimer >= nightDuration)
            {
                nightTimer = 0f;
            }
        }

        UpdateLighting();
    }

    private void UpdateLighting()
    {
        // If the directional light is set then rotate and set its color
        if (DirectionalLight != null)
        {
            TimeOfDay.Value = (dayTimer / dayDuration * 95f) + 5f;
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((dayTimer / dayDuration * 170f) - (-5f), 170f, 0));
        }
    }

    public void DayCompleted()
    {
        TimeOfDay.Value = 0;
        DayCount.Value++;
    }
}
