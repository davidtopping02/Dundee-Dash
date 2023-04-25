using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundGenerator groundGenerator;


    // Start is called before the first frame update
    void Start()
    {
        groundGenerator = FindObjectOfType<GroundGenerator>();

    }

    // moves the tile back at a constant rate
    private void Update()
    {

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
