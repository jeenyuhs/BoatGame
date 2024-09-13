using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject trashPrefab;
    public GameObject hazardPrefab;
    public float spawnRate = 2f;  // Trash and hazards spawn every 2 seconds

    void Start()
    {
        // Repeatedly call SpawnTrash and SpawnHazard at intervals
        InvokeRepeating("SpawnHazard", 3f, spawnRate + 1);       // Hazards spawn slightly less frequently
        InvokeRepeating("SpawnTrash", 1f, spawnRate);            // Trash spawns every spawnRate seconds
    }

    void SpawnTrash()
    {
        // ensure the random x coordinate, is not within a bounding box of hazard.
        float randomX = Random.Range(-35f, 35f);
        goto start;
        start:
            foreach (GameObject hazardFab in GameObject.FindGameObjectsWithTag("Hazard")) {
                var hazard = hazardFab.GetComponent<Collider>();

                // check if the ranodm x coord is within a hazard bounding box.
                if (hazard.bounds.Contains(new Vector3(randomX, 0f, 50f))) {
                    randomX = Random.Range(-20f, 20f);
                    goto start;
                }
            }

        Vector3 spawnPosition = new Vector3(randomX, 0f, 50f); // Set the spawn position within bounds
        Quaternion spawnRotation = Quaternion.Euler(0f, 90f, 0f); // Rotate the trash 90 degrees around the Y-axis
        Instantiate(trashPrefab, spawnPosition, spawnRotation); // Spawn the trash prefab with the specified rotation
    }

    void SpawnHazard()
    {
        // ensure the random x coordinate, is not within a bounding box of trash.
        float randomX = Random.Range(-35f, 35f);
        goto start;
        start:
            foreach (GameObject trashFab in GameObject.FindGameObjectsWithTag("Trash")) {
                var trash = trashFab.GetComponent<Collider>();

                // check if the ranodm x coord is within a hazard bounding box.
                if (trash.bounds.Contains(new Vector3(randomX, 0f, 50f))) {
                    randomX = Random.Range(-20f, 20f);
                    goto start;
                }
            }

        Vector3 spawnPosition = new Vector3(randomX, 0f, 50f); // Set the spawn position within bounds
        Quaternion spawnRotation = Quaternion.Euler(0f, -90f, 0f); // Rotate the hazard -90 degrees around the Y-axis
        Instantiate(hazardPrefab, spawnPosition, spawnRotation); // Spawn the hazard prefab with the specified rotation
    }
}
