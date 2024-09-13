using UnityEngine;

public class SharkScript : MonoBehaviour
{
    public float fallSpeed = 5f; // Speed at which hazards fall

    void Update()
    {
        // Move the hazard downwards
        transform.Translate(Vector3.left * fallSpeed * Time.deltaTime);

        OnDestroy();
    }
    
    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            TrashCollector.Instance.score--;
            TrashCollector.Instance.UpdateScoreUI();

            Destroy(gameObject);
        }
    }

    void OnDestroy(){
        if (transform.position.z < -20)
            Destroy(gameObject);
    }
}
