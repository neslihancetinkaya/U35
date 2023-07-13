using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedLauncher : MonoBehaviour
{
    public GameObject seedPrefab; // Tohum objesi
    public Transform launchPoint; // F�rlatma noktas�
    public LayerMask groundLayer; // Toprak katman�
    public float launchForce = 10f; // F�rlatma g�c�
    public GameObject launchPointObject;
    public GameObject[] plantPrefabs; // Birden �ok bitki objesi
    public float plantingDepth = 0.1f; // Topra�a yerle�tirme derinli�i
    public float growthDuration = 5f; // B�y�me s�resi

    void Start()
    {
        launchPoint = launchPointObject.transform; // launchPoint'i launchPointObject'in Transform bile�eniyle e�le�tirin
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LaunchSeed();
        }
    }

    void LaunchSeed()
    {
        Ray ray = new Ray(launchPoint.position, launchPoint.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            GameObject seed = Instantiate(seedPrefab, launchPoint.position, Quaternion.identity);
            Rigidbody rb = seed.GetComponent<Rigidbody>();
            rb.AddForce(launchPoint.forward * launchForce, ForceMode.Impulse);

            PlantSeed(seed, hit.point);
            Debug.Log("Tohum f�rlat�ld�!");
        }

    }

    void PlantSeed(GameObject seed, Vector3 position)
    {
        // Tohumu topra�a yerle�tirme
        seed.transform.position = new Vector3(position.x, position.y - plantingDepth, position.z);

        // Bitki b�y�mesini sim�le etmek i�in Coroutine kullanabilirsiniz
        StartCoroutine(GrowPlant(seed));
    }

    IEnumerator GrowPlant(GameObject seed)
    {
        yield return new WaitForSeconds(growthDuration); // Belirtilen s�re boyunca bekleyin

        // Rastgele bir bitki prefab� se�in
        int randomIndex = Random.Range(0, plantPrefabs.Length);
        GameObject plantPrefab = plantPrefabs[randomIndex];

        // Bitki prefab�n�
    }
}