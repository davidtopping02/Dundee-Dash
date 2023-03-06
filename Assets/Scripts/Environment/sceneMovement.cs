using UnityEngine;

public class sceneMovement : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        // Moves the camera forward at the same rate as the player
        transform.Translate(Vector3.forward * Time.deltaTime * PlayerMovement.moveSpeed, Space.World);

    }
}
