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
            if (other.CompareTag("Player"))
            {
                // Add score or trigger other actions
                TrashCollector.Instance.CollectTrash();
                Destroy(gameObject);
            }
        }
    }

    void OnDestroy() {
        if (transform.position.z < -20) {
            Destroy(gameObject);
        }
    }
}
