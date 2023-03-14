using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundGenerator groundGenerator;
    int moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 30;
        groundGenerator = FindObjectOfType<GroundGenerator>();
    }

    // moves the tile back at a constant rate
    private void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerExit(Collider other)
    {
        //spawns the next tile
        groundGenerator.spawnTile();
        groundGenerator.deleteTile();
    }
}
