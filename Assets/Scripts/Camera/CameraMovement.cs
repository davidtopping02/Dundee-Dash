using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    void Update()
    {
        // Moves the camera forward at the same rate as the player
        transform.Translate(Vector3.forward * Time.deltaTime * PlayerMovement.moveSpeed, Space.World);
    }
}
