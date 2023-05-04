using UnityEngine;

public class coinBehaviour : MonoBehaviour
{
    private float rotationSpeed = 250f;

    // Start is called before the first frame update
    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    // destoys the coin object when a player collides with it
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.001f);
        }
    }
}
