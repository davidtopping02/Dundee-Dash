using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundGenerator groundGenerator;
    float moveSpeed;
    float acceleration;
    float maxSpeed;


    // Start is called before the first frame update
    void Start()
    {
        groundGenerator = FindObjectOfType<GroundGenerator>();

    }
    // moves the tile back at a constant rate
    private void Update()
    {
        // Increase the move speed based on the elapsed time
        moveSpeed += acceleration * Time.deltaTime;

        // Cap the move speed at the maximum value
        if (moveSpeed > maxSpeed)
        {
            moveSpeed = maxSpeed;
        }

        // Move the tile
        transform.Translate(Vector3.back * DundeeDashController.moveSpeed * Time.deltaTime);
    }


    private void OnTriggerExit(Collider other)
    {
        //spawns the next tile
        groundGenerator.spawnTile();
        groundGenerator.deleteTile();
    }
}
