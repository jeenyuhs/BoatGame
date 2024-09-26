using UnityEngine;

public class PlasticScript : MonoBehaviour
{
    public float fallSpeed = 5f; // Speed at which trash falls

    void Update()
    {
        // Move the trash downwards
        transform.Translate(Vector3.right * fallSpeed * Time.deltaTime);

        OnDestroy();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the trash collides with the player
        if (other != null) {
            // make sure it only executes when the collider is Player, aka boat.
            if (other.CompareTag("Player"))
            {
                // increment score
                TrashCollector.Instance.CollectTrash();
                Destroy(gameObject);
            }
        }
    }

    void OnDestroy() {
        // upon object reaches the boundary, it should be destroyed, to save memory.
        if (transform.position.z < -20) {
            Destroy(gameObject);
        }
    }
}
