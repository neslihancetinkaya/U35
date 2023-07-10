using UnityEngine;
using TMPro;

public class LightingManagertwo : MonoBehaviour
{
    // Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;

    // Day Counter References
    public TextMeshProUGUI dayText;
    private int dayCount = 1;
    private bool isFirstDay = true;

    // Day Cycle Variables
    public float dayDuration = 30f; // Gündüz döngüsünün süresi (saniye)
    private float dayTimer = 0f;

    // Night Cycle Variables
    public float nightDuration = 30f; // Gece döngüsünün süresi (saniye)
    private float nightTimer = 0f;

    private void Start()
    {
        UpdateDayText();
    }

    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            dayTimer += Time.deltaTime;

            if (dayTimer >= dayDuration)
            {
                dayTimer = 0f;
                DayCompleted();
                // Gündüz döngüsünün tamamlandýðý yerde DayCompleted() metodunu çaðýrýn.
            }

            nightTimer += Time.deltaTime;

            if (nightTimer >= nightDuration)
            {
                nightTimer = 0f;
                dayCount--;
                DayCompleted();
                // Gece döngüsünün tamamlandýðý yerde DayCompleted() metodunu çaðýrýn.
            }
        }

        // Gündüz ve gece döngüleri için gerçekleþtirilmesi gereken diðer iþlemler...

        UpdateLighting();
    }

    private void UpdateLighting()
    {
        if (Preset == null)
            return;

        // Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(dayTimer / dayDuration);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(dayTimer / dayDuration);

        // If the directional light is set then rotate and set its color
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(dayTimer / dayDuration);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((dayTimer / dayDuration * 170f) - (-5f), 170f, 0));
        }
    }

    public void DayCompleted()
    {
        dayCount++; 
        UpdateDayText();
    }

    private void UpdateDayText()
    {
        if (isFirstDay)
        {
            dayText.text = "1. gün";
            isFirstDay = false;
        }
        else
        {
            dayText.text = dayCount + ". gün";
        }
    }
}
