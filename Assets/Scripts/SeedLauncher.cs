using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedLauncher : MonoBehaviour
{
    public GameObject seedPrefab; // Tohum objesi
    public Transform launchPoint; // Fýrlatma noktasý
    public LayerMask groundLayer; // Toprak katmaný
    public float launchForce = 10f; // Fýrlatma gücü
    public GameObject launchPointObject;
    public GameObject[] plantPrefabs; // Birden çok bitki objesi
    public float plantingDepth = 0.1f; // Topraða yerleþtirme derinliði
    public float growthDuration = 5f; // Büyüme süresi

    void Start()
    {
        launchPoint = launchPointObject.transform; // launchPoint'i launchPointObject'in Transform bileþeniyle eþleþtirin
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
            Debug.Log("Tohum fýrlatýldý!");
        }

    }

    void PlantSeed(GameObject seed, Vector3 position)
    {
        // Tohumu topraða yerleþtirme
        seed.transform.position = new Vector3(position.x, position.y - plantingDepth, position.z);

        // Bitki büyümesini simüle etmek için Coroutine kullanabilirsiniz
        StartCoroutine(GrowPlant(seed));
    }

    IEnumerator GrowPlant(GameObject seed)
    {
        yield return new WaitForSeconds(growthDuration); // Belirtilen süre boyunca bekleyin

        // Rastgele bir bitki prefabý seçin
        int randomIndex = Random.Range(0, plantPrefabs.Length);
        GameObject plantPrefab = plantPrefabs[randomIndex];

        // Bitki prefabýný
    }
}