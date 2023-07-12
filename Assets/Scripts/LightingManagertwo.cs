using UnityEngine;
using TMPro;

public class LightingManagertwo : MonoBehaviour
{
    // Scene References
    [SerializeField] private Light DirectionalLight;
   

    // Day Counter References
    public TextMeshProUGUI dayText;
    private int dayCount = 1;
    private bool isFirstDay = true;

    // Day Cycle Variables
    public float dayDuration = 30f; // G�nd�z d�ng�s�n�n s�resi (saniye)
    private float dayTimer = 0f;

    // Night Cycle Variables
    public float nightDuration = 30f; // Gece d�ng�s�n�n s�resi (saniye)
    private float nightTimer = 0f;

    private void Start()
    {
        UpdateDayText();
    }

    private void Update()
    {

        if (Application.isPlaying)
        {
            dayTimer += Time.deltaTime;

            if (dayTimer >= dayDuration)
            {
                dayTimer = 0f;
                DayCompleted();
                // G�nd�z d�ng�s�n�n tamamland��� yerde DayCompleted() metodunu �a��r�n.
            }

            nightTimer += Time.deltaTime;

            if (nightTimer >= nightDuration)
            {
                nightTimer = 0f;
                dayCount--;
                DayCompleted();
                // Gece d�ng�s�n�n tamamland��� yerde DayCompleted() metodunu �a��r�n.
            }
        }

        // G�nd�z ve gece d�ng�leri i�in ger�ekle�tirilmesi gereken di�er i�lemler...

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
        dayCount++; 
        UpdateDayText();
    }

    private void UpdateDayText()
    {
        if (isFirstDay)
        {
            dayText.text = "1. g�n";
            isFirstDay = false;
        }
        else
        {
            dayText.text = dayCount + ". g�n";
        }
    }
}
