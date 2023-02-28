using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundGenerator groundGenerator;
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        groundGenerator = GameObject.FindObjectOfType<GroundGenerator>();

        int obstacleSpawnPointIndex = Random.Range(2, 5);

        // choose random spawn point
        Transform spawnPoint = transform.GetChild(obstacleSpawnPointIndex).transform;

        Debug.Log(obstacleSpawnPointIndex);

        //spwan obstacle at the random spawn point
        obstaclePrefab = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
    }

    private void OnTriggerExit(Collider other)
    {
        //spawns the next tile
        groundGenerator.spawnTile();

        //destroys the current tile 1 seconds after the player exits it
        Destroy(obstaclePrefab, 1);
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
