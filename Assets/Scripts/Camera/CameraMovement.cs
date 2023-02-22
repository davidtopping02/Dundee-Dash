using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Moves the camera forward at the same rate as the player
        transform.Translate(Vector3.forward * Time.deltaTime * PlayerMovement.moveSpeed, Space.World);

        // Smoothly move the camera to the player's position
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
