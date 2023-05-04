using UnityEngine;

/**
 * Inspiration taken from the following forum
 * https://forum.unity.com/threads/why-does-rigidbody-3d-not-have-a-gravity-scale.440415/
 */
[RequireComponent(typeof(Rigidbody))]
public class PlayerGravity : MonoBehaviour
{
    public float gravityScale = 1.0f;
    public static float globalGravity = -9.81f;
    Rigidbody m_rb;

    // This method is called when the game object is enabled
    void OnEnable()
    {
        // Get the rigid body component attached to the game object
        m_rb = GetComponent<Rigidbody>();

        // Disable the use of gravity on the rigid body component
        m_rb.useGravity = false;
    }

    // This method is called every fixed framerate frame
    void FixedUpdate()
    {
        // Calculate the gravity vector based on the global gravity, gravity scale, and up direction
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;

        // Apply the gravity as a force to the rigid body component using the acceleration force mode
        m_rb.AddForce(gravity, ForceMode.Acceleration);
    }
}