using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundGenerator groundGenerator;
    public GameObject obstacle;
    Vector3 tilePosition;
    int obstacleStartPosition = 20;

    // Start is called before the first frame update
    void Start()
    {
        groundGenerator = FindObjectOfType<GroundGenerator>();
        tilePosition = this.transform.position;


        // only generate obstacle after certain distance reached
        if (tilePosition.z > obstacleStartPosition)
        {
            // instantiate obstacle
            int obstacleSpawnPointIndex = Random.Range(2, 5);
            Transform spawnPoint = transform.GetChild(obstacleSpawnPointIndex).transform;

            //spwan obstacle at the random spawn point
            obstacle = Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //spawns the next tile
        groundGenerator.spawnTile();

        //destroys the tile 1 second after the player exits it

        Destroy(gameObject, 1);

        // destroy the obstacle when the correct distance reached
        if (tilePosition.z > obstacleStartPosition)
        {
            Destroy(obstacle, 1);
        }
    }
}
