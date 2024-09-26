using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject trashPrefab;
    public GameObject hazardPrefab;
    public float spawnRate = 2f; // seconds

    void Start()
    {
        // repeatedly call SpawnTrash and SpawnHazard at intervals
        InvokeRepeating("SpawnHazard", 3f, spawnRate + 1); // spawnRate is different for hazard, so it spawns less frequent.
        InvokeRepeating("SpawnTrash", 1f, spawnRate); 
    }

    void SpawnTrash()
    {
        // random spawn position on the x axes.
        Vector3 spawnPosition = new Vector3(Random.Range(-35f, 35f), 0f, 50f); 
        Quaternion spawnRotation = Quaternion.Euler(0f, 90f, 0f);
        Instantiate(trashPrefab, spawnPosition, spawnRotation);
    }

    void SpawnHazard()
    {
        // random spawn position on the x axes.
        Vector3 spawnPosition = new Vector3(Random.Range(-35f, 35f), 0f, 50f);

        Quaternion spawnRotation = Quaternion.Euler(0f, -90f, 0f);
        Instantiate(hazardPrefab, spawnPosition, spawnRotation);

    }
}
