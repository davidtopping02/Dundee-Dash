using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    public GameObject GroundTile;
    Vector3 nextSpawnPoint;

    // Spawns the next tile in the path
    public void spawnTile()
    {
        // instantiate new tile in the next spawn point with the same rotation 
        GameObject temp = Instantiate(GroundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            spawnTile();
        }
    }

}
