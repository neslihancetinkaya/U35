using UnityEngine;
using TMPro;
using Utils.RefValue;

public class LightingManagertwo : MonoBehaviour
{
    // Scene References
    [SerializeField] private Light DirectionalLight;
   

    // Day Counter References
    [SerializeField] private IntRef DayCount;

    // Day Cycle Variables
    public float dayDuration = 30f;
    private float dayTimer = 0f;

    // Night Cycle Variables
    public float nightDuration = 30f;
    private float nightTimer = 0f;

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
                DayCount.Value--;
                DayCompleted();
            }
        }

        UpdateLighting();
    }

    private void UpdateLighting()
    {
        // If the directional light is set then rotate and set its color
        if (DirectionalLight != null)
        {
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((dayTimer / dayDuration * 170f) - (-5f), 170f, 0));
        }
    }

    public void DayCompleted()
    {
        DayCount.Value++;
    }
}
