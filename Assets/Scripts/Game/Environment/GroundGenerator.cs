using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject EmptyTile;
    LinkedList<GameObject> allTiles = new();
    GameObject currentTile;
    public GameObject[] tileConfigs;

    // Start is called before the first frame update
    void Start()
    {
        // spawns the initial tiles for the path
        for (int i = 0; i < 5; i++)
        {
            spawnTile();
        }
    }

    private GameObject newTile(Vector3 spawnCoordinates)
    {

        // selects random tile from the list
        int index = Random.Range(0, tileConfigs.Length);
        GameObject tileToInstantiate = tileConfigs[index];

        // randomly select one of the game tile objects
        return Instantiate(tileToInstantiate, spawnCoordinates, Quaternion.identity);
    }

    // Spawns the next tile in the path
    public void spawnTile()
    {
        // spawns the very first tile
        if (currentTile == null)
        {
            currentTile = Instantiate(EmptyTile, new Vector3(0, 0, 0), Quaternion.identity);

        }
        else
        {
            currentTile = newTile(new Vector3(currentTile.transform.position.x, currentTile.transform.position.y, currentTile.transform.position.z + 100));
        }

        allTiles.AddLast(currentTile);
    }

    // Deleted tile at the start of the list
    public void deleteTile()
    {
        GameObject tileToRemove = allTiles.First.Value;

        if (tileToRemove != null)
        {
            Destroy(tileToRemove, 2);
            allTiles.RemoveFirst();
        }
    }


}

